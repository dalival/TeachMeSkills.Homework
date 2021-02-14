using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Point A { get; }
        public Point B { get; }
        public Rectangle(Point a, Point b)
        {
            A = a ?? throw new ArgumentNullException(nameof(a));
            A = b ?? throw new ArgumentNullException(nameof(b));
            if(a.X == b.X || a.Y == b.Y)
            {
                throw new Exception("Two diagonally opposite points cannot be on the same line");
            }
        }
        public override double GetPerimeter()
        {
            return (GetWidth() + GetHeight()) * 2;
        }
        public override double GetSquare()
        {
            return GetWidth() * GetHeight();
        }
        public override int[] GetPoints()
        {
            int[] points = { A.X, A.Y, B.X, B.Y };
            return points;
        }
        private int GetWidth()
        {
            return Math.Abs(A.X - B.X);
        }
        private int GetHeight()
        {
            return Math.Abs(A.Y - B.Y);
        }
    }
}