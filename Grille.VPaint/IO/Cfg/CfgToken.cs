namespace Grille.VPaint.IO.Cfg;

public enum TokenType { None, Identifier, Value, String }
public struct CfgToken
{
    public int Line;
    public string Value;
    public TokenType Type;
    public CfgToken(int line, TokenType typ, string value)
    {
        Line = line;
        Value = value;
        Type = typ;
    }


    public static bool operator ==(CfgToken c1, CfgToken c2)
    {
        return c1.Equals(c2);
    }
    public static bool operator !=(CfgToken c1, CfgToken c2)
    {
        return !c1.Equals(c2);
    }
    public override bool Equals(object obj)
    {
        var token = (CfgToken)obj;
        return Value == token.Value && Type == token.Type;
    }
}
