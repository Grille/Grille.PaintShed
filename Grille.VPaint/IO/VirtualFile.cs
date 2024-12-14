using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grille.VPaint.IO.Cfg;

namespace Grille.VPaint.IO;

public class VirtualFile
{
    public byte[] Data { get; set; }

    public VirtualFile(byte[] data)
    {
        Data = data;
    }

    public Stream OpenStream()
    {
        return new MemoryStream(Data);
    }

    public string ReadAllText()
    {
        using var stream = OpenStream();
        using var reader = new StreamReader(stream, leaveOpen: true);
        return reader.ReadToEnd();
    }

    public void WriteAllText(string text)
    {
        using var stream = new MemoryStream();
        using var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
        writer.Write(text);
        writer.Flush();
        Data = stream.ToArray();
    }

    public CfgObject ReadConfig()
    {
        return CfgParser.Parse(ReadAllText());
    }

    public void WriteConfig(CfgObject cfg)
    {
        WriteAllText(cfg.Serialize());
    }
}
