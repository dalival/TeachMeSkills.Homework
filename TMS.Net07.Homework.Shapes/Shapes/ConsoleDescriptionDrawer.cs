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
                Console.WriteLine($" - the triangle with vertices " +
                                  $"({points[0]},{points[1]}), " +
                                  $"({points[2]},{points[3]}), " +
                                  $"({points[4]},{points[5]})");
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                Console.WriteLine($" - the rectangle with vertices " +
                                  $"({points[0]},{points[1]}), " +
                                  $"({points[2]},{points[3]})");
            }
            if (shape.GetType() == typeof(Circle))
            {
                Console.WriteLine($" - the circle with center in " +
                                  $"({points[0]},{points[1]}) " +
                                  $"and radius R = {points[2]}");
            }
        }
    }
}