using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Grille.VPaint.UnsafeDrawing;

namespace Grille.VPaint;

using System.Media;
using System.Numerics;

using UnsafeDrawing;

public class Canvas : IDisposable
{
    Projector? MainSurface { get; set; }

    private RenderMode _lastRenderMode;

    public Canvas? Counterpart;

    public string Name { get; }

    public int Left { get; }

    public int Top { get; }

    public int Width { get; }

    public int Height { get; }

    public int Length => Width * Height;

    public readonly BoundingBox Bounds;

    public Vector2 Position => new Vector2(Left, Top);

    public Rectangle ImageBounds => new Rectangle(0, 0, Width, Height);

    public Bitmap BaseBuffer { get; }
     
    public Bitmap MaskBuffer { get; }
     
    public Bitmap PaintBuffer { get; }

    public Bitmap DecalPaintBuffer { get; }

    public Bitmap RenderBuffer { get; }

    public DecalLayer[] DecalLayers { get; }

    public TimeSpan FinalBufferUpdateTime { get; private set; }

    public Canvas(string name, int left, int top, int width, int height)
    {
        Name = name;

        Left = left;
        Top = top;

        Width = width;
        Height = height;

        Bounds = new BoundingBox(Left, Top, Left + Width, Top + Height);

        BaseBuffer = CreateBuffer();
        MaskBuffer = CreateBuffer();
        PaintBuffer = CreateBuffer();
        DecalPaintBuffer = CreateBuffer();
        RenderBuffer = CreateBuffer();

        var modes = Enum.GetValues<BlendMode>();
        DecalLayers = new DecalLayer[modes.Length];
        for (int i = 0; i < modes.Length; i++)
        {
            DecalLayers[i] = new DecalLayer(width, height, modes[i]);
        }

        using (var g = Graphics.FromImage(PaintBuffer))
        {
            g.Clear(Color.White);
        }

        Invalidate();
    }

    public Canvas(string name, Bitmap bitmap, int left, int top) : this(name, left, top, bitmap.Width, bitmap.Height)
    {
        SubBaseImage(bitmap);
    }

    public void SubBaseImage(Image image)
    {
        using var g = Graphics.FromImage(BaseBuffer);
        g.DrawImage(image, ImageBounds);
        Invalidate();
    }

    public void SubMaskImage(Image image)
    {
        using var g = Graphics.FromImage(MaskBuffer);
        g.DrawImage(image, ImageBounds);
        Invalidate();
    }

    public void SubPaintImage(Image image)
    {
        using var g = Graphics.FromImage(PaintBuffer);
        g.DrawImage(image, ImageBounds);
        Invalidate();
    }

    public void BeginDecalProjection()
    {
        foreach (var buffer in DecalLayers)
        {
            buffer.BeginEdit();
        }
    }

    public bool TryAddDecal(Decal decal, out Vector2 location)
    {
        if (!Bounds.IsInside(decal.Location))
        {
            location = Vector2.Zero;
            return false;
        }
        location = decal.Location - Position;
        return true;
    }

    public void AddDecal(Decal decal, Vector2 location)
    {
        AddDecal(decal.Buffer, location);
    }

    public void AddDecal(Image image, Vector2 location)
    {
        var layer = DecalLayers[0];
        var size = new Vector2(image.Width, image.Height);
        var pos = location - size * 0.5f;
        layer.Graphics!.DrawImage(image, new Point((int)pos.X, (int)pos.Y));
        layer.Count += 1;
    }

    public void AddProjectorAsDecal(Projector projector)
    {
        var image = projector.Source.DecalLayers[0].Buffer;

        var layer = DecalLayers[0];
        var g = layer.Graphics;

        var size = new Vector2(image.Width, image.Height);

        var pos = size * 0.5f + projector.Position;


        g.TranslateTransform(pos.X, pos.Y);
        g.ScaleTransform(projector.Scale.X, projector.Scale.Y);

        AddDecal(image, Vector2.Zero);

        g.ResetTransform();
    }


    public void EndDecalProjection()
    {
        foreach (var buffer in DecalLayers)
        {
            buffer.EndEdit();

            Invalidate();
        }
    }

    private Bitmap CreateBuffer()
    {
        return new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
    }

    unsafe record struct DataHandle(Bitmap Bitmap, BitmapData Data) : IDisposable
    {
        public void Dispose()
        {
            Bitmap.UnlockBits(Data);
        }

        public static implicit operator BitmapData(DataHandle a) => a.Data;
    }

    DataHandle LockBits(Bitmap bitmap)
    {
        var data = bitmap.LockBits(ImageBounds, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        return new DataHandle(bitmap, data);
    }

    public ArgbColor GetPickColor(Vector2 location)
    {
        int x = (int)location.X;
        int y = (int)location.Y;

        return MaskBuffer.GetPixel(x, y);
    }

    public ArgbColor GetPaintColor(Vector2 location)
    {
        int x = (int)location.X;
        int y = (int)location.Y;

        return PaintBuffer.GetPixel(x, y);
    }

    public ArgbColor GetFinalColor(Vector2 location)
    {
        int x = (int)location.X;
        int y = (int)location.Y;

        return RenderBuffer.GetPixel(x, y);
    }

    public void SetPaintByPick(ArgbColor pick, ArgbColor color)
    {
        using var pickBuffer = MaskBuffer.GetDataHandle();
        using var paintBuffer = PaintBuffer.GetDataHandle();

        paintBuffer.SetColor(pickBuffer, pick, color);

        Invalidate();
    }

    public void ReplacePaint(ArgbColor pick, ArgbColor color)
    {
        using var paintBuffer = PaintBuffer.GetDataHandle();

        paintBuffer.SetColor(paintBuffer, pick, color);

        Invalidate();
    }

    public void Render(RenderMode mode)
    {
        var timestamp = DateTime.Now;

        using var baseBuffer = BaseBuffer.GetDataHandle();
        using var maskBuffer = MaskBuffer.GetDataHandle();
        using var paintBuffer = PaintBuffer.GetDataHandle();
        using var decalPaintBuffer = DecalPaintBuffer.GetDataHandle();
        using var renderBuffer = RenderBuffer.GetDataHandle();

        switch (mode)
        {
            case RenderMode.Default:
            {
                decalPaintBuffer.Draw(paintBuffer, BlendMode.Overwrite);

                foreach (var layer in DecalLayers)
                {
                    if (layer.Count == 0)
                    {
                        continue;
                    }
                    using var handle = layer.Buffer.GetDataHandle();
                    decalPaintBuffer.Draw(handle, BlendMode.Mix);
                }

                renderBuffer.Draw(baseBuffer, BlendMode.Overwrite);
                renderBuffer.Draw(decalPaintBuffer, BlendMode.Multiply);

                break;
            }
            case RenderMode.Base:
            {
                renderBuffer.Draw(baseBuffer, BlendMode.Overwrite);
                break;
            }
            case RenderMode.Mask:
            {
                renderBuffer.Draw(maskBuffer, BlendMode.Overwrite);
                break;
            }
            case RenderMode.Paint:
            {
                renderBuffer.Draw(paintBuffer, BlendMode.Overwrite);
                break;
            }
        }

        FinalBufferUpdateTime = DateTime.Now - timestamp;

        _lastRenderMode = mode;
    }

    public void Invalidate()
    {
        _lastRenderMode = RenderMode.None;
    }

    public Image GetImage(RenderMode mode = RenderMode.Default)
    {
        if (_lastRenderMode != mode)
        {
            Render(mode);
        }
        return RenderBuffer;
    }

    public void Dispose()
    {
        BaseBuffer.Dispose();
        MaskBuffer.Dispose();
        PaintBuffer.Dispose();
        RenderBuffer.Dispose();

        foreach (var buffer in DecalLayers)
        {
            buffer.Dispose();
        }
    }
}
