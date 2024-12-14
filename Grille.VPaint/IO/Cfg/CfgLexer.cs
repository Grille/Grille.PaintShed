using System;
using System.Collections.Generic;
using System.IO;

namespace Grille.VPaint.IO.Cfg;

public static class CfgLexer
{
    static public List<CfgToken> Tokenize(string input)
    {
        var tokens = new List<CfgToken>();
        int begin = 0;
        int line = 1;
        var mode = TokenType.None;
        var next = TokenType.Identifier;
        for (int i = 0; i < input.Length; i++)
        {
            int length = i - begin;
            char ch = input[i];

            bool IsString() => ch == '"';
            bool IsWhitespace() => ch == ' ' || ch == '\t';
            bool IsNewLine() => ch == '\n' || ch == '\r';

            switch (mode)
            {
                case TokenType.None:
                    if (IsString())
                    {
                        begin = i;
                        mode = TokenType.String;
                    }
                    else if (IsNewLine())
                    {
                        next = TokenType.Identifier;
                        line += 1;
                    }
                    else if (!IsWhitespace())
                    {
                        begin = i;
                        mode = next;
                    }
                    break;
                case TokenType.String:
                    if (IsString())
                    {
                        string value = input.Substring(begin, length + 1);
                        tokens.Add(new CfgToken(line, mode, value));
                        next = TokenType.Value;
                        mode = TokenType.None;
                    }
                    break;
                case TokenType.Value:
                    if (IsWhitespace() || IsNewLine())
                    {
                        string value = input.Substring(begin, length);
                        tokens.Add(new CfgToken(line, mode, value));
                        mode = TokenType.None;
                    }
                    break;
                case TokenType.Identifier:
                    if (IsWhitespace() || IsNewLine())
                    {
                        string value = input.Substring(begin, length);
                        tokens.Add(new CfgToken(line, mode, value));
                        next = TokenType.Value;
                        mode = TokenType.None;
                    }
                    break;
            }
        }
        return tokens;
    }
}
