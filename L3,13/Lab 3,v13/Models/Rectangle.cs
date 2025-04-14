using System;
using GraphicsApp.Interfaces;

namespace GraphicsApp.Models
{
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Рисуем прямоугольник.");
        }
    }
}
