using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Lab6_Variant13
{
    class Program
    {
        private const string InputFilePath = "input.txt";
        private const int TriangleCoordCount = 6;
        private const int RectangleCoordCount = 4;

        static void Main()
        {
            if (!File.Exists(InputFilePath))
            {
                Console.WriteLine("Файл input.txt не найден.");
                return;
            }

            List<Polygon> figures = new List<Polygon>();
            string[] lines = File.ReadAllLines(InputFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string color = parts[0];
                int[] nums = parts.Skip(1).Select(int.Parse).ToArray();

                Polygon figure = null;
                if (nums.Length == TriangleCoordCount) figure = new Triangle(color, nums);
                else if (nums.Length == RectangleCoordCount) figure = new Rectangle(color, nums);
                else Console.WriteLine($"Неправильные данные: {line}");

                if (figure != null)
                    figures.Add(figure);
            }

            Console.WriteLine("Номер Вид фигуры   Площадь    Цвет");
            for (int i = 0; i < figures.Count; i++)
                figures[i].PrintInfo(i + 1);

            Console.WriteLine("\n--- Сортировка по площади ---");
            figures.Sort();
            for (int i = 0; i < figures.Count; i++)
                figures[i].PrintInfo(i + 1);

            Console.WriteLine("\n--- Фигуры в одной четверти ---");
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].FullyInOneQuarter)
                {
                    Console.WriteLine($"{i + 1,-5} {figures[i].GetType().Name,-12} {figures[i].GetQuarter()} четверть");
                }
            }

            Console.ResetColor();
        }
    }
}