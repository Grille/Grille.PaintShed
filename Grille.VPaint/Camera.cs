using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint
{
    public class Camera
    {
        public Vector2 Position;
        public float Scale;

        private Vector2 lastLocation;

        public Vector2 ScreenSize;

        public Vector2 HalfScreenSize => ScreenSize * 0.5f;

        public void MouseScrollEventHandler(MouseEventArgs e, float scrollFactor)
        {
            var location = new Vector2 (e.X, e.Y);
            var oldWorldPos = ScreenToWorldSpace(location);
            if (e.Delta > 0)
                Scale *= scrollFactor;
            else
                Scale /= scrollFactor;

            if (Scale < 0.5)
                Scale = 0.5f;

            if (Scale > 128)
                Scale = 128;

            var newWorldPos = ScreenToWorldSpace(location);
            Position += oldWorldPos - newWorldPos;
        }

        public void MouseMoveEventHandler(MouseEventArgs e, bool move)
        {
            var location = new Vector2(e.X, e.Y);
            if (move)
            {
                Position += (lastLocation - location) / Scale;
            }
            lastLocation = location;
        }

        public Vector2 ScreenToWorldSpace(Vector2 screenPos)
        {
            return (screenPos - HalfScreenSize) / Scale + Position;
        }

        public Vector2 WorldToScreenSpace(Vector2 worldPos)
        {
            return (worldPos - Position) * Scale + HalfScreenSize;
        }
    }
}
