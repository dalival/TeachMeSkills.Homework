using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public Point Center { get; }
        public int Radius { get; }
        public Circle(Point center, int radius)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public override double GetSquare()
        {
            double p = GetPerimeter() / 2; // for the Heron formula
            return Math.PI * Radius * Radius;
        }
        public override int[] GetPoints()
        {
            int[] points = { Center.X, Center.Y, Radius };
            return points;
        }
    }
}
