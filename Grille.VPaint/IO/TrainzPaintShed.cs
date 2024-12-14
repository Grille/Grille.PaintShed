using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Grille.VPaint.IO.Cfg;
using Grille.VPaint.WinForms;

namespace Grille.VPaint.IO;

public static class TrainzPaintShed
{
    public static void LoadBase(string dirPath, World world)
    {


        world.Clear();

        Canvas Canvas(string name, int left, int top)
        {
            var filePath = $"{dirPath}/{name}.bmp";
            using var baseBitmap = new Bitmap(filePath);
            var canvas = new Canvas(name, baseBitmap, left, top);
            world.CanvasList.Add(canvas);

            return canvas;
        }

        var trainDirPath = $"{dirPath}/train";
        if (!Directory.Exists(trainDirPath)) throw new ArgumentException("Selected folder must contain 'train' subfolder.");
        world.VirtualDirectory.Load(trainDirPath);
        world.Strings.Pull(world.VirtualDirectory.Files["config.txt"].ReadConfig());

        var front = Canvas("Front", 0, 0);
        var rear = Canvas("Rear", 0, (int)front.Bounds.EndY);
        var top = Canvas("Top", front.Width, 0);
        var left = Canvas("Left", (int)front.Bounds.EndX, (int)top.Bounds.EndY);
        var right = Canvas("Right", (int)rear.Bounds.EndX, (int)left.Bounds.EndY);
        var preview = Canvas("Preview", (int)top.Bounds.EndX, 0);
        var consist = Canvas("Consist", (int)top.Bounds.EndX, (int)preview.Bounds.EndY);
        var main = Canvas("Main", (int)preview.Bounds.EndX, 0);

        Projector Projector(Canvas source)
        {
            var filePath = $"{dirPath}/{source.Name}.txt";
            var dict = IniFile.Load(filePath);

            int x = int.Parse(dict["x"]);
            int y = int.Parse(dict["y"]);
            bool flipped = dict.ContainsKey("flipped");

            var position = flipped ? new Vector2(main.Width - x - source.Width, main.Height- y- source.Height) : new Vector2(x, y);
            var scale = flipped ? -Vector2.One : Vector2.One;

            var projector = new Projector(source, main, position, scale);
            world.ProjectorsList.Add(projector);

            return projector;
        }

        front.Counterpart = rear;
        rear.Counterpart = front;

        left.Counterpart = right;
        right.Counterpart = left;

        Projector(front);
        Projector(rear);

        Projector(left);
        Projector(right);

        Projector(top);
    }

    public static void LoadMask(string dirPath, World world)
    {
        foreach (var canvas in world.CanvasList)
        {
            var name = canvas.Name;
            var filePath = $"{dirPath}/{name}_mask.bmp";
            if (File.Exists(filePath))
            {
                using var bitmap = new Bitmap(filePath);
                canvas.SubMaskImage(bitmap);
            }
        }
    }

    public static void Export(string dirPath, World world)
    {
        world.VirtualDirectory.Save(dirPath);

        var configfile = Path.Combine(dirPath, "config.txt");
        var config = CfgFile.Read(configfile);
        world.Strings.Push(config);
        CfgFile.Write(configfile, config);

        var name = world.Strings.Name.Value;

        void ExportImage(string name, string filePath)
        {
            var image = world.GetCanvasByName(name)!.GetImage();
            var format = ImageFormat.Bmp;

            BmpFile.Save(Path.Combine(dirPath, filePath), (Bitmap)image);
        }

        ExportImage("Main", "main.bmp");
        ExportImage("Consist", $"{name}_art/consist.bmp");
        ExportImage("Preview", $"{name}_art/preview.bmp");
    }
}
