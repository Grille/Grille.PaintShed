using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Grille.VPaint;

public class Decal : IDisposable
{
    public int ZIndex;

    public Vector2 Location;

    public BoundingBox Bounds;

    public Vector2 Offset;

    public Vector2 Scale;

    public float Angle;

    public Font Font;

    public string? Text;

    public Bitmap? Image;

    public Color ShapeColor;

    public Vector2 ShapeSize;

    public Color TextColor;

    public CloneMode CloneMode;

    public DecalShape Shape;

    public Vector2 Size => new Vector2(Buffer.Width, Buffer.Height);

    public void MoveBy(Vector2 offset)
    {
        Location += offset;

        UpdateBounds();
    }

    public Decal()
    {
       
        Angle = 0;
        Buffer = new Bitmap(1, 1);
        Font = new Font("consolas", 32);
        Text = "Text";
        ShapeColor = Color.Gray;
        ShapeSize = new Vector2(50, 50);
        TextColor = Color.Red;
        Scale = Vector2.One;

        CloneMode = CloneMode.SamePosition;
    }

    public void Update()
    {
        var g = Graphics.FromImage(Buffer);

        var absscale = Vector2.Abs(Scale);

        var size = absscale;

        if (Shape != DecalShape.None)
        {
            size = Vector2.Max(size, ShapeSize * 1.5f);
        }

        if (!string.IsNullOrEmpty(Text))
        {
            var textSize = ((Vector2)g.MeasureString(Text, Font)) * 1.5f * absscale;
            size = Vector2.Max(size, textSize);
        }

        if (Image != null)
        {
            var imgSize = ((Vector2)(SizeF)Image.Size) * 1.5f * absscale;
            size = Vector2.Max(size, imgSize);
        }

        var asize = size;
        size = new Vector2(MathF.Max(size.X, size.Y));
        var hsize = size * 0.5f;
        //size *= Scale;

        int width = (int)size.X;
        int height = (int)size.Y;

        if (width != Buffer.Width || height != Buffer.Height)
        {
            g.Dispose();
            Buffer.Dispose();
            Buffer = new Bitmap(width, height);
            g = Graphics.FromImage(Buffer);
        }

        g.Clear(Color.FromArgb(0, ShapeColor));

        g.TranslateTransform(Offset.X, Offset.Y);
        g.TranslateTransform((int)(hsize.X + 0.5f), (int)(hsize.Y + 0.5f));
        g.RotateTransform(Angle);

        if (Scale.X != 0 && Scale.Y != 0)
        {
            g.ScaleTransform(Scale.X, Scale.Y);
        }

        g.PixelOffsetMode = PixelOffsetMode.Half;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;

        DrawShape(g, ShapeSize);

        if (Image != null)
        {
            var rect = new Rectangle(-Image.Width / 2, -Image.Height / 2, Image.Width, Image.Height);
            if (rect.Width > 0 || rect.Height > 0)
            {
                g.DrawImage(Image, rect);
            }
        }

        if (!string.IsNullOrEmpty(Text))
        {
            var textSize = g.MeasureString(Text, Font);
            var rect = new RectangleF(-textSize.Width / 2, -textSize.Height / 2, textSize.Width, textSize.Height);
            using var brush = new SolidBrush(TextColor);
            g.DrawString(Text, Font, brush, rect);
        }

        g.Dispose();

        UpdateBounds();
    }

    void DrawShape(Graphics g, Vector2 size)
    {
        if (Shape == DecalShape.None)
        {
            return;
        }

        var rect = new RectangleF(-size.X / 2, -size.Y / 2, size.X, size.Y);
        using var brush = new SolidBrush(ShapeColor);

        if (Shape == DecalShape.Rectangle)
        {
            g.FillRectangle(brush, rect);
        }
        else if (Shape == DecalShape.Elipse)
        {
            g.FillEllipse(brush, rect);
        }
        else if (Shape == DecalShape.TextBackground)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            var textSize = g.MeasureString(Text, Font);
            var textRect = new RectangleF(-textSize.Width / 2, -textSize.Height / 2, textSize.Width, textSize.Height);
            g.FillRectangle(brush, textRect);
        }
    }

    public void UpdateBounds()
    {
        var size = new Vector2(Buffer.Width / 1.5f, Buffer.Height / 1.5f);
        var pos = Location - size / 2;
        Bounds = new BoundingBox(pos, pos + size);
    }

    public void Dispose()
    {
        Image?.Dispose();
        Buffer.Dispose();
    }

    public Bitmap Buffer { get; protected set; }
}
