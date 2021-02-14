using System;

namespace Shapes
{
    public class ConsoleDescriptionDrawer : Drawer
    {
        public override void Draw(Shape shape)
        {
            Console.Write($"{shape.GetType()} ");
            var points = shape.GetPoints();
            if (shape.GetType() == typeof(Triangle))
            {
                Console.WriteLine($"({points[0]},{points[1]})" +
                                  $"({points[2]},{points[3]})" +
                                  $"({points[4]},{points[5]})");
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                Console.WriteLine($"({points[0]},{points[1]})" +
                                  $"({points[2]},{points[3]})");
            }
            if (shape.GetType() == typeof(Circle))
            {
                Console.WriteLine($"({points[0]},{points[1]}), " +
                                  $"r = {points[2]}");
            }
        }
    }
}