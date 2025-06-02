using System;
using System.Drawing;
using System.Linq;

namespace Lab6_Variant13
{
    public abstract class Polygon : IComparable<Polygon>
    {
        public Point[] Vertices { get; protected set; }
        public string Color { get; protected set; }

        public abstract double GetArea();

        public virtual void PrintInfo(int index)
        {
            Console.ForegroundColor = TryParseColor(Color);
            Console.WriteLine($"{index,-5} {GetType().Name,-12} {GetArea():F2,-10} {Color}");
            Console.ResetColor();
        }

        public int CompareTo(Polygon other)
        {
            return this.GetArea().CompareTo(other.GetArea());
        }

        protected ConsoleColor TryParseColor(string colorName)
        {
            return Enum.TryParse(colorName, true, out ConsoleColor col) ? col : ConsoleColor.White;
        }

        protected bool IsInSameQuarter()
        {
            return Vertices.All(p => p.X > 0 && p.Y > 0) ||
                   Vertices.All(p => p.X < 0 && p.Y > 0) ||
                   Vertices.All(p => p.X < 0 && p.Y < 0) ||
                   Vertices.All(p => p.X > 0 && p.Y < 0);
        }

        public string GetQuarter()
        {
            if (Vertices.All(p => p.X > 0 && p.Y > 0)) return "I";
            if (Vertices.All(p => p.X < 0 && p.Y > 0)) return "II";
            if (Vertices.All(p => p.X < 0 && p.Y < 0)) return "III";
            if (Vertices.All(p => p.X > 0 && p.Y < 0)) return "IV";
            return "Разные";
        }

        public bool FullyInOneQuarter => IsInSameQuarter();
    }
}