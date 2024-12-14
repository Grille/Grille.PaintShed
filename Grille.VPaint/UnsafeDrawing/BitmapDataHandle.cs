using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.UnsafeDrawing;

public unsafe record struct BitmapDataHandle(Bitmap Bitmap, BitmapData Data) : IDisposable
{
    public int Width => Data.Width;

    public int Height => Data.Height;

    public int Length => Width * Height;

    public IntPtr Scan0 => Data.Scan0;

    public Span<ArgbColor> Span => new Span<ArgbColor>((ArgbColor*)Scan0, Length);

    public void Dispose()
    {
        Bitmap.UnlockBits(Data);
    }
}
