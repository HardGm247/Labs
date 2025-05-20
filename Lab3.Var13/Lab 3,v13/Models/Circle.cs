using System;
using GraphicsApp.Interfaces;

namespace GraphicsApp.Models
{
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Рисуем круг.");
        }
    }
}
