using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grille.VPaint.UnsafeDrawing;

namespace Grille.VPaint;

public class DecalLayer : IDisposable
{
    public Bitmap Buffer { get; }
    public Graphics? Graphics { get; private set; }
    public BlendMode Mode { get; }

    public int Count;

    public DecalLayer(int width, int height, BlendMode mode)
    {
        Buffer = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        Mode = mode;
    }

    public void BeginEdit()
    {
        Graphics = Graphics.FromImage(Buffer);
        if (Count > 0)
        {
            Graphics.Clear(Color.Transparent);
            Count = 0;
        }

        Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
    }

    public void EndEdit()
    {
        Graphics!.Dispose();
    }

    public void Dispose() => Buffer.Dispose();
}
