using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Grille.VPaint.UnsafeDrawing;

using BlendFunc = Func<ArgbColor, ArgbColor, ArgbColor>;

internal static unsafe class BitmapDataOperations
{
    public static BitmapDataHandle GetDataHandle(this Bitmap bitmap)
    {
        var rect = new Rectangle(0,0,bitmap.Width,bitmap.Height);
        var data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        return new BitmapDataHandle(bitmap, data);
    }

    public static void SetColor(this BitmapDataHandle dst, BitmapDataHandle src, ArgbColor pick, ArgbColor color)
    {
        var dstPtr = (ArgbColor*)dst.Scan0;
        var srcPtr = (ArgbColor*)src.Scan0;

        int length = dst.Width*dst.Height;

        for (int i = 0; i< length; i++)
        {
            if (srcPtr[i] == pick)
            {
                dstPtr[i] = color;
            }
        }
    }

    public unsafe static void Draw(this BitmapDataHandle dst, BitmapDataHandle src,  BlendMode blend)
    {
        if (blend == BlendMode.Overwrite)
        {
            src.Span.CopyTo(dst.Span);
            return;
        }

        delegate*<ArgbColor, ArgbColor, ArgbColor> func = blend switch
        {
            BlendMode.Mix => &ArgbColor.Mix,
            BlendMode.Multiply => &ArgbColor.Multiply,
            _ => throw new NotSupportedException()
        };

        Draw(dst, src, func);
    }

    public unsafe static void Draw(this BitmapDataHandle dst, BitmapDataHandle src,  delegate*<ArgbColor, ArgbColor, ArgbColor> blend)
    {
        Draw(dst, src, blend, 0, dst.Width);
    }

    public unsafe static void Draw(this BitmapDataHandle dst, BitmapDataHandle src, delegate*<ArgbColor, ArgbColor, ArgbColor> blend, int beginX, int endX)
    {
        var dstPtr = (ArgbColor*)dst.Scan0;
        var srcPtr = (ArgbColor*)src.Scan0;

        for (int iy = 0; iy < dst.Height; iy++)
        {
            int yidx = iy * src.Width;

            for (int ix = beginX; ix < endX; ix++)
            {
                int idx = yidx + ix;

                dstPtr[idx] = blend(dstPtr[idx], srcPtr[idx]);
            }
        }
    }
}
