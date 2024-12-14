using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint;

public class Projector
{
    public Canvas Source { get; }
    public Canvas Target { get; }
    public Vector2 Position { get; }
    public Vector2 Scale { get; }

    public BoundingBox Bounds { get; }

    public Projector(Canvas source, Canvas target, Vector2 position, Vector2 scale)
    {
        Source = source;
        Target = target;
        Position = position;
        Scale = scale;

        var size = new Vector2(source.Width, source.Height);

        var pos = target.Position + position;

        Bounds = new BoundingBox(pos.X, pos.Y, pos.X + size.X, pos.Y + size.Y);
    }
}
