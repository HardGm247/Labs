using System.Collections.Generic;
using GraphicsApp.Interfaces;

namespace GraphicsApp.Services
{
    public class ShapeDrawer
    {
        private readonly IEnumerable<IShape> _shapes;

        public ShapeDrawer(IEnumerable<IShape> shapes)
        {
            _shapes = shapes;
        }

        public void DrawAll()
        {
            foreach (IShape shape in _shapes)
            {
                shape.Draw();
            }
        }
    }
}
