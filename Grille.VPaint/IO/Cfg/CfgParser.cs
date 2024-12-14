using System;
using System.Collections.Generic;
using System.IO;

namespace Grille.VPaint.IO.Cfg;

public static class CfgParser
{
    static public CfgObject Parse(string config)
    {
        var obj = new CfgObject();
        Parse(config, obj);
        return obj;
    }

    static public void Parse(string config, CfgObject obj)
    {
        var tokens = CfgLexer.Tokenize(config);
        int pos = 0;
        ParseObject(tokens, ref pos, obj);
    }

    static private CfgObject ParseObject(List<CfgToken> tokens, ref int pos)
    {
        var obj = new CfgObject();
        ParseObject(tokens, ref pos, obj);
        return obj;
    }

    static private void ParseObject(List<CfgToken> tokens, ref int pos, CfgObject obj)
    {
        while (pos < tokens.Count - 1)
        {
            var token = tokens[pos++];
            var nexttoken = tokens[pos];
            if (token.Value == "}")
            {
                break;
            }
            else if (token.Type == TokenType.Identifier && nexttoken.Type != TokenType.Identifier)
            {
                var key = token.Value;
                var value = tokens[pos++];
                try
                {
                    if (value.Value == "{")
                    {
                        obj.Objects[key] = ParseObject(tokens, ref pos);
                    }
                    else
                    {
                        obj.Properties[key] = value.Value;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"{e.Message}\n{token.Line}: {key} = {value.Value}{e.StackTrace}");
                }
            }
        }
    }
}
