using System;

namespace Shapes
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point SetX(int newX)
        {
            return new Point(newX, X);
        }
        public Point SetY(int newY)
        {
            return new Point(X, newY);
        }
        public double GetDistance(Point target)
        {
            var width = X - target.X;
            var height = Y - target.Y;

            return Math.Sqrt(width * width + height * height);
        }
    }
}
