using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Grille.IO;
using Grille.VPaint.UnsafeDrawing;
using Grille.IO.Compression;
using System.Numerics;

namespace Grille.VPaint.IO;

public static class BinarySerializer
{
    public static void Save(string filePath, World world, bool compress)
    {
        using var stream = File.Create(filePath);
        Save(stream, world, compress);
    }

    public static void Load(string filePath, World world)
    {
        using var stream = File.OpenRead(filePath);
        Load(stream, world);
    }

    public static void Save(Stream stream, World world, bool compress)
    {
        using var bw = new BinaryViewWriter(stream);
        Save(bw, world, compress);
    }

    public static void Load(Stream stream, World world)
    {
        using var br = new BinaryViewReader(stream);
        Load(br, world);
    }

    public static void Save(BinaryViewWriter bw, World world, bool compress)
    {
        bw.WriteBoolean(compress);

        if (compress)
        {
            bw.CompressAll(CompressionType.GZip);
        }

        bw.WriteInt32(42);
        bw.WriteInt32(world.CanvasList.Count);
        bw.WriteInt32(world.DecalList.Count);
        bw.WriteInt32(world.ProjectorsList.Count);

        bw.WriteDict(world.Strings.Dict);

        foreach (var canvas in world.CanvasList)
        {
            bw.WriteCanvas(canvas);
        }

        foreach (var canvas in world.CanvasList)
        {
            bw.WriteCanvasPtr(world, canvas.Counterpart);
        }

        foreach (var decal in world.DecalList)
        {
            bw.WriteDecal(decal);
        }

        foreach (var projector in world.ProjectorsList)
        {
            bw.WriteProjector(world, projector);
        }

        bw.WriteVDirectory(world.VirtualDirectory);
    }

    public static void Load(BinaryViewReader br, World world)
    {
        world.Clear();

        bool compressed = br.ReadBoolean();
        if (compressed)
        {
            br.DecompressAll(CompressionType.GZip);
        }

        int magic = br.ReadInt32();
        int canvasCount = br.ReadInt32();
        int decalCount = br.ReadInt32();
        int projectorCount = br.ReadInt32();

        br.ReadDict(world.Strings.Dict);

        for (int i = 0; i < canvasCount; i++)
        {
            var canvas = br.ReadCanvas();
            world.CanvasList.Add(canvas);
        }

        for (int i = 0; i < canvasCount; i++)
        {
            world.CanvasList[i].Counterpart = br.ReadCanvasPtr(world);
        }

        for (int i = 0; i < decalCount; i++)
        {
            var decal = br.ReadDecal();
            world.DecalList.Add(decal);
        }

        for (int i = 0; i < projectorCount; i++)
        {
            var projector = br.ReadProjector(world);
            world.ProjectorsList.Add(projector);
        }

        world.VirtualDirectory = br.ReadVDirectory();

        world.UpdateDecalBuffers();
    }
    public static void WriteDecal(this BinaryViewWriter bw, Decal decal)
    {
        bw.Write(decal.Location);
        bw.Write(decal.Offset);
        bw.Write(decal.Scale);
        bw.Write(decal.Angle);

        bw.Write(decal.Shape);
        bw.Write(decal.ShapeSize);
        bw.Write(decal.CloneMode);
        bw.Write<ArgbColor>(decal.ShapeColor);
        bw.Write<ArgbColor>(decal.TextColor);

        bw.WriteFont(decal.Font);

        bool WriteGuard(bool value)
        {
            bw.WriteBoolean(value);
            return value;
        }

        if (WriteGuard(decal.Text != null))
        {
            bw.WriteString(decal.Text!);
        }

        if (WriteGuard(decal.Image != null))
        {
            bw.WriteBitmap(decal.Image!);
        }

    }

    public static Decal ReadDecal(this BinaryViewReader br)
    {
        var decal = new Decal();

        decal.Location = br.Read<Vector2>();
        decal.Offset = br.Read<Vector2>();
        decal.Scale = br.Read<Vector2>();
        decal.Angle = br.Read<float>();

        decal.Shape = br.Read<DecalShape>();
        decal.ShapeSize = br.Read<Vector2>();
        decal.CloneMode = br.Read<CloneMode>();
        decal.ShapeColor = br.Read<ArgbColor>();
        decal.TextColor = br.Read<ArgbColor>();

        decal.Font = br.ReadFont();

        if (br.ReadBoolean())
        {
            decal.Text = br.ReadString();
        }

        if (br.ReadBoolean())
        {
            decal.Image = br.ReadBitmap();
        }

        decal.Update();

        return decal;
    }

    public static void WriteCanvas(this BinaryViewWriter bw, Canvas canvas)
    {
        bw.WriteString(canvas.Name);
        bw.WriteInt32(canvas.Left);
        bw.WriteInt32(canvas.Top);
        bw.WriteInt32(canvas.Width);
        bw.WriteInt32(canvas.Height);

        bw.WriteBitmap(canvas.BaseBuffer);
        bw.WriteBitmap(canvas.MaskBuffer);
        bw.WriteBitmap(canvas.PaintBuffer);
    }

    public static Canvas ReadCanvas(this BinaryViewReader br)
    {
        string name = br.ReadString();
        int left = br.ReadInt32();
        int top = br.ReadInt32();
        int width = br.ReadInt32();
        int height = br.ReadInt32();

        var canvas = new Canvas(name, left, top, width, height);


        using (var image = br.ReadBitmap())
        {
            canvas.SubBaseImage(image);
        }

        using (var image = br.ReadBitmap())
        {
            canvas.SubMaskImage(image);
        }

        using (var image = br.ReadBitmap())
        {
            canvas.SubPaintImage(image);
        }

        return canvas;
    }

    public static void WriteProjector(this BinaryViewWriter bw, World world, Projector projector)
    {
        bw.WriteCanvasPtr(world, projector.Source);
        bw.WriteCanvasPtr(world, projector.Target);

        bw.Write(projector.Position);
        bw.Write(projector.Scale);
    }

    public static Projector ReadProjector(this BinaryViewReader br, World world)
    {
        var source = br.ReadCanvasPtr(world)!;
        var target = br.ReadCanvasPtr(world)!;

        var position = br.Read<Vector2>();
        var scale = br.Read<Vector2>();

        return new Projector(source, target, position, scale);
    }


    public static void WriteCanvasPtr(this BinaryViewWriter bw, World world, Canvas? canvas)
    {
        int idx = canvas == null ? -1 : world.CanvasList.IndexOf(canvas);
        bw.WriteInt32(idx);
    }

    public static Canvas? ReadCanvasPtr(this BinaryViewReader br, World world)
    {
        var idx = br.ReadInt32();
        return idx == -1 ? null : world.CanvasList[idx];
    }

    public unsafe static void WriteBitmap(this BinaryViewWriter bw, Bitmap bitmap)
    {
        bw.WriteInt32(bitmap.Width);
        bw.WriteInt32(bitmap.Height);
        bw.Write(bitmap.PixelFormat);

        using var handle = bitmap.GetDataHandle();
        int length = handle.Data.Stride * handle.Height;
        var ptr = (byte*)handle.Scan0;

        for (int i = 0; i < length; i++)
        {
            bw.WriteByte(ptr[i]);
        }
    }

    public unsafe static Bitmap ReadBitmap(this BinaryViewReader br)
    {
        int width = br.ReadInt32();
        int height = br.ReadInt32();
        var format = br.Read<PixelFormat>();

        var bitmap = new Bitmap(width, height, format);

        using var handle = bitmap.GetDataHandle();
        int length = handle.Data.Stride * handle.Height;
        var ptr = (byte*)handle.Scan0;

        for (int i = 0; i < length; i++)
        {
            ptr[i] = br.ReadByte();
        }

        return bitmap;
    }

    public static void WriteFont(this BinaryViewWriter bw, Font font)
    {
        bw.WriteString(font.Name);
        bw.WriteSingle(font.Size);
        bw.WriteInt32((int)font.Style);
        bw.WriteString(font.Unit.ToString());
    }

    public static Font ReadFont(this BinaryViewReader br)
    {
        string name = br.ReadString();
        float size = br.ReadSingle();
        FontStyle style = (FontStyle)br.ReadInt32();
        GraphicsUnit unit = (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), br.ReadString());
        return new Font(name, size, style, unit);
    }

    public static void WriteVFile(this BinaryViewWriter bw, VirtualFile file)
    {
        bw.WriteArray(file.Data);
    }

    public static VirtualFile ReadVFile(this BinaryViewReader br)
    {
        var data = br.ReadArray<byte>();
        return new VirtualFile(data);
    }

    public static void WriteVDirectory(this BinaryViewWriter bw, VirtualDirectory dir)
    {
        bw.WriteInt32(dir.Directories.Count);
        bw.WriteInt32(dir.Files.Count);

        foreach (var pair in dir.Directories)
        {
            bw.WriteString(pair.Key);
            bw.WriteVDirectory(pair.Value);
        }

        foreach (var pair in dir.Files)
        {
            bw.WriteString(pair.Key);
            bw.WriteVFile(pair.Value);
        }
    }

    public static VirtualDirectory ReadVDirectory(this BinaryViewReader br)
    {
        var dirCount = br.ReadInt32();
        var fileCount = br.ReadInt32();

        var dir = new VirtualDirectory();

        for (int i = 0; i < dirCount; i++)
        {
            var key = br.ReadString();
            var value = br.ReadVDirectory();
            dir.Directories.Add(key, value);
        }

        for (int i = 0; i < fileCount; i++)
        {
            var key = br.ReadString();
            var value = br.ReadVFile();
            dir.Files.Add(key, value);
        }

        return dir;
    }

    public static void WriteDict(this BinaryViewWriter bw, IDictionary<string, string> dict)
    {
        bw.WriteInt32(dict.Count);
        foreach (var pair in dict)
        {
            bw.WriteString(pair.Key);
            bw.WriteString(pair.Value);
        }
    }

    public static void ReadDict(this BinaryViewReader bw, IDictionary<string, string> dict)
    {
        dict.Clear();
        int count = bw.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            var key = bw.ReadString();
            var value = bw.ReadString();
            dict[key] = value;
        }
    }
}
