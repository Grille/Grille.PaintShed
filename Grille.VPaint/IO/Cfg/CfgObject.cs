using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.IO.Cfg;

public class CfgObject
{
    public Dictionary<string, CfgObject> Objects { get; }
    public Dictionary<string, string> Properties { get; }

    public CfgObject()
    {
        Objects = new();
        Properties = new();
    }

    public string Serialize()
    {
        using var sb = new StringWriter();
        Serialize(sb);
        var text = sb.ToString();
        return text;
    }

    public void Serialize(TextWriter writer)
    {
        foreach (var prop in Properties)
        {
            writer.Write(prop.Key);
            writer.Write(" ");
            writer.Write(prop.Value);

            writer.WriteLine();
        }

        foreach (var obj in Objects)
        {
            writer.Write(obj.Key);
            writer.WriteLine(" {");
            obj.Value.Serialize(writer);
            writer.WriteLine("}");
        }
    }
}
