using System;
using System.Drawing;

namespace Lab6_Variant13
{
    public class Triangle : Polygon
    {
        public Triangle(string color, int[] coords)
        {
            Color = color;
            Vertices = new Point[3];
            for (int i = 0; i < 3; i++)
                Vertices[i] = new Point(coords[i * 2], coords[i * 2 + 1]);
        }

        public override double GetArea()
        {
            var (a, b, c) = (Vertices[0], Vertices[1], Vertices[2]);
            return 0.5 * Math.Abs(a.X * (b.Y - c.Y) +
                                  b.X * (c.Y - a.Y) +
                                  c.X * (a.Y - b.Y));
        }
    }
}