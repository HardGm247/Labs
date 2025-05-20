using System;
using GraphicsApp.Interfaces;

namespace GraphicsApp.Models
{
    public class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Рисуем треугольник.");
        }
    }
}
