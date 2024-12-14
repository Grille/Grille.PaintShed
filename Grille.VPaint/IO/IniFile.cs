using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.IO;

internal static class IniFile
{
    public static Dictionary<string, string> Load(string filePath)
    {
        using var stream = File.OpenRead(filePath);
        return Load(stream);
    }

    public static Dictionary<string, string> Load(Stream stream)
    {
        using var reader = new StreamReader(stream, leaveOpen:true);
        return Load(reader);
    }

    public static Dictionary<string, string> Load(TextReader reader)
    {
        var dict = new Dictionary<string, string>();
        while (true)
        {
            var line = reader.ReadLine();
            if (line == null) break;
            if (line.StartsWith("//")) continue;
            var split = line.Split('=', 2);
            var key = split[0];
            var value = split.Length == 2 ? split[1] : "true";
            dict[key] = value;
        }
        return dict;
    }
}
