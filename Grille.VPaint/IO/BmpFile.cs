using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grille.IO;
using Grille.VPaint.UnsafeDrawing;

namespace Grille.VPaint.IO;

public static class BmpFile
{
    public static void Save(string filePath, Bitmap bitmap)
    {
        using var stream = File.Create(filePath);
        Save(stream, bitmap);
    }

    public static void Save(Stream stream, Bitmap bitmap)
    {
        using var bw = new BinaryViewWriter(stream);
        Save(bw, bitmap);
    }

    public static void Save(BinaryViewWriter bw, Bitmap bitmap)
    {
        if (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        {
            throw new NotImplementedException();
        }
        using var handle = bitmap.GetDataHandle();
        Save(bw, handle);
    }

    public unsafe static void Save(BinaryViewWriter bw, BitmapDataHandle data)
    {
        // BMP file header
        bw.WriteUInt16(0x4D42); // Signature 'BM'
        bw.WriteUInt32((uint)(54 + data.Length)); // File size
        bw.WriteUInt32(0); // Reserved
        bw.WriteUInt32(54); // Offset to pixel array

        // DIB header (BITMAPINFOHEADER)
        bw.WriteUInt32(40); // Header size
        bw.WriteUInt32((uint)data.Width); // Image width
        bw.WriteUInt32((uint)data.Height); // Image height
        bw.WriteUInt16(1); // Planes
        bw.WriteUInt16(24); // Bits per pixel (24-bit RGB)
        bw.WriteUInt32(0); // Compression (none)
        bw.WriteUInt32((uint)data.Length); // Image size
        bw.WriteUInt32(0); // Horizontal resolution (pixels/meter)
        bw.WriteUInt32(0); // Vertical resolution (pixels/meter)
        bw.WriteUInt32(0); // Colors in palette (0 = all colors)
        bw.WriteUInt32(0); // Important colors (0 = all)

        // Write pixel data
        var ptr = (ArgbColor*)data.Scan0;
        for (int iy = data.Height - 1; iy >= 0; iy--)
        {
            for (int ix = 0; ix < data.Width; ix++)
            {
                int i = ix + iy * data.Width;
                bw.WriteByte(ptr[i].B);
                bw.WriteByte(ptr[i].G);
                bw.WriteByte(ptr[i].R);
            }
        }

    }
}
