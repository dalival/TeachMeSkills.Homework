using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program is working...");

            var drawer = new ConsoleDescriptionDrawer();
            var circle = new Circle(new Point(10, 5), 3);
            var triangle = new Triangle(new Point(1, 1), new Point(3, 1), new Point(2, 3));
            var rectangle = new Rectangle(new Point(4, 1), new Point(6, 4));
            
            drawer.Draw(rectangle);
            drawer.Draw(triangle);
            drawer.Draw(circle);

            Console.ReadLine();
        }
    }
}