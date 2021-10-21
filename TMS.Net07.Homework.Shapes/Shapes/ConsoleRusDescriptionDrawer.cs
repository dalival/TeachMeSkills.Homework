using System;

namespace Shapes
{
    public class ConsoleRusDescriptionDrawer : Drawer
    {
        public override void Draw(Shape shape)
        {
            Console.Write($"{shape.GetType()} ");
            var points = shape.GetPoints();
            if (shape.GetType() == typeof(Triangle))
            {
                Console.WriteLine($" - треугольник с вершинами " +
                                  $"({points[0]},{points[1]}), " +
                                  $"({points[2]},{points[3]}), " +
                                  $"({points[4]},{points[5]})");
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                Console.WriteLine($" - прямоугольник с вершинами " +
                                  $"({points[0]},{points[1]}), " +
                                  $"({points[2]},{points[3]})");
            }
            if (shape.GetType() == typeof(Circle))
            {
                Console.WriteLine($" - круг с центром в " +
                                  $"({points[0]},{points[1]}) " +
                                  $"и радиусом R = {points[2]}");
            }
        }
    }
}