using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.IO;

public class VirtualDirectory
{
    public Dictionary<string, VirtualDirectory> Directories { get; }

    public Dictionary<string, VirtualFile> Files { get; }

    public VirtualDirectory()
    {
        Directories = new(StringComparer.InvariantCultureIgnoreCase);
        Files = new(StringComparer.InvariantCultureIgnoreCase);
    }

    public void Clear()
    {
        Directories.Clear();
        Files.Clear();
    }

    public void Load(string dirPath, int recursionCounter = 4)
    {
        Clear();

        if (recursionCounter < 0)
        {
            throw new ArgumentException();
        }

        foreach (var dir in Directory.EnumerateDirectories(dirPath))
        {
            var vdir = new VirtualDirectory();
            vdir.Load(dir, recursionCounter - 1);
            Directories.Add(Path.GetFileName(dir), vdir);
        }

        foreach (var file in Directory.EnumerateFiles(dirPath))
        {
            var bytes = File.ReadAllBytes(file);
            var vfile = new VirtualFile(bytes);
            Files.Add(Path.GetFileName(file), vfile);
        }
    }

    public void Save(string dirPath)
    {
        Directory.CreateDirectory(dirPath);

        foreach (var file in Files)
        {
            var subPath = Path.Combine(dirPath, file.Key);
            File.WriteAllBytes(subPath, file.Value.Data);
        }

        foreach (var dir in Directories)
        {
            var subPath = Path.Combine(dirPath, dir.Key);
            dir.Value.Save(subPath);
        }
    }
}
