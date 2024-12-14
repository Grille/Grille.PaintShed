using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.IO.Cfg;

public static class CfgFile
{
    public static CfgObject Read(string path)
    {
        return CfgParser.Parse(File.ReadAllText(path));
    }

    public static void Write(string path, CfgObject cfg)
    {
        File.WriteAllText(path, cfg.Serialize());
    }
}
