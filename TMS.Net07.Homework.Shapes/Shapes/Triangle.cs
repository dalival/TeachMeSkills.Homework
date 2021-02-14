using System;

namespace Shapes
{
    public class Triangle : Shape
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }
        public Triangle(Point a, Point b, Point c)
        {
            A = a ?? throw new ArgumentNullException(nameof(a));
            B = b ?? throw new ArgumentNullException(nameof(b));
            C = c ?? throw new ArgumentNullException(nameof(c));
        }
        public override double GetPerimeter()
        {
            return A.GetDistance(B) +
                   B.GetDistance(C) +
                   C.GetDistance(A);
        }
        public override double GetSquare()
        {
            double p = GetPerimeter() / 2; // for the Heron formula
            return Math.Sqrt(p * (p - A.GetDistance(B)) *
                                 (p - B.GetDistance(C)) *
                                 (p - C.GetDistance(A)));
        }
        public override int[] GetPoints()
        {
            int[] points = { A.X, A.Y, B.X, B.Y, C.X, C.Y };
            return points;
        }
    }
}
