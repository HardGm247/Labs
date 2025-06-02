using System;
using System.Drawing;

namespace Lab6_Variant13
{
    public class Rectangle : Polygon
    {
        public Rectangle(string color, int[] coords)
        {
            Color = color;
            Vertices = new Point[4];
            Point p1 = new Point(coords[0], coords[1]);
            Point p2 = new Point(coords[2], coords[3]);
            Vertices[0] = p1;
            Vertices[1] = new Point(p2.X, p1.Y);
            Vertices[2] = p2;
            Vertices[3] = new Point(p1.X, p2.Y);
        }

        public override double GetArea()
        {
            int width = Math.Abs(Vertices[0].X - Vertices[2].X);
            int height = Math.Abs(Vertices[0].Y - Vertices[2].Y);
            return width * height;
        }
    }
}