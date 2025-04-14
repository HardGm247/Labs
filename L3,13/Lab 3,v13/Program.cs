using System;
using System.Collections.Generic;
using GraphicsApp.Interfaces;
using GraphicsApp.Models;
using GraphicsApp.Services;

namespace GraphicsApp
{
    public class Program
    {
        public static void Main()
        {
            var shapes = new List<IShape>
            {
                new Circle(),
                new Rectangle(),
                new Triangle()
            };

            var drawer = new ShapeDrawer(shapes);
            drawer.DrawAll();
        }
    }
}
