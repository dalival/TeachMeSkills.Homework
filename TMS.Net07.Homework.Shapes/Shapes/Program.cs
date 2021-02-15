using System;
using System.Text.RegularExpressions;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter the shape name and it's points. Integers only. Available formats:" +
                              $"{Environment.NewLine}-> triangle (x,y) (x,y) (x,y)" +
                              $"{Environment.NewLine}-> rectangle (x,y) (x,y)" +
                              $"{Environment.NewLine}-> circle (x,y) r");
            
            var regexTriangle = new Regex(@"^triangle(\s?\(\s?\d+\s?,\s?\d+\s?\)){3}$",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            var regexRectangle = new Regex(@"^rectangle(\s?\(\s?\d+\s?,\s?\d+\s?\)){2}$",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            var regexCircle = new Regex(@"^circle\s?\(\s?\d+\s?,\s?\d+\s?\)\s?\d+$",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(regexTriangle.IsMatch(input) ? "Yes it is!" : "No it isn't!");
            }

            Console.ReadKey();
        }
    }
}