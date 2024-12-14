using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.UnsafeDrawing;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ArgbColor
{
    public byte B, G, R, A;

    public ArgbColor(byte r, byte g, byte b, byte a = 255)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public static ArgbColor Multiply(ArgbColor a, ArgbColor b)
    {
        return a * b;
    }

    public static ArgbColor Mix(ArgbColor vec1, ArgbColor vec2)
    {
        return Mix(vec1, vec2, vec2.A / 255f);
    }

    public static ArgbColor Mix(ArgbColor vec1, ArgbColor vec2, float factor)
    {
        return (ArgbColor)Mix((Vector4)vec1, (Vector4)vec2, factor);
    }

    public static Vector4 Mix(Vector4 vec1, Vector4 vec2, float factor)
    {
        return vec1 * (1 - factor) + vec2 * factor;
    }

    public static ArgbColor operator *(ArgbColor color1, ArgbColor color2)
    {
        var vec1 = (Vector4)color1;
        var vec2 = (Vector4)color2;

        var vec3 = vec1 * vec2;
        vec3.W = vec1.W;

        return (ArgbColor)Mix(vec1, vec3, vec2.W);
    }

    public static implicit operator Vector4(ArgbColor color) => new Vector4
    (
        color.R / 255f,
        color.G / 255f,
        color.B / 255f,
        color.A / 255f
    );

    public static explicit operator ArgbColor(Vector4 vector) => new ArgbColor
    (
        (byte)(vector.X * 255),
        (byte)(vector.Y * 255),
        (byte)(vector.Z * 255),
        (byte)(vector.W * 255)
    );

    public static bool operator ==(ArgbColor color1, ArgbColor color2) => (int)color1 == (int)color2;

    public static bool operator !=(ArgbColor color1, ArgbColor color2) => (int)color1 != (int)color2;

    public static implicit operator int(ArgbColor color) => Unsafe.As<ArgbColor, int>(ref color);

    public static implicit operator ArgbColor(Color color) => new ArgbColor(color.R, color.G, color.B, color.A);

    public static implicit operator Color(ArgbColor color) => Color.FromArgb(color.A, color.R, color.G, color.B);

    public override string ToString() => ((Color)this).ToString();
}
