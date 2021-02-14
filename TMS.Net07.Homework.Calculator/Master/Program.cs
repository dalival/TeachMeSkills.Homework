using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            double firstValue = 0;
            double secondValue = 0;
            double result = 0;
            string[] operators = { "-", "+", "*", "/", "pow", "sqr", "sqrt" };
            Regex binaryOperator = new Regex(@"^(\-?\d+\.?(\d+)?)\s?(\+|\-|\*|\/|(pow))\s?\-?(\d+|(\d+\.\d+))$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            Regex unaryOperator = new Regex(@"^((sqr)|(sqrt))\s?\-?(\d+|\d+\.\d+)$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("This is a one-operator-calculator. To exit enter \"exit\". Enter an expression based on one of the templates:"
                    + Environment.NewLine + "x + y"
                    + Environment.NewLine + "x - y"
                    + Environment.NewLine + "x * y"
                    + Environment.NewLine + "x / y"
                    + Environment.NewLine + "x pow y"
                    + Environment.NewLine + "sqr x"
                    + Environment.NewLine + "sqrt x" + Environment.NewLine);
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine($"{Environment.NewLine}This command ends the program. Good bye!");
                    Console.ReadKey();
                    return;
                }

                if (binaryOperator.IsMatch(input))
                {
                    // Any operator can be a separator to identify firstValue.
                    // If we selected the wrong operator we'll try another operator.
                    int i;
                    for (i = 0; i < 5; i++)
                    {
                        int operatorPosition = input.IndexOf(operators[i].ToLower(), 1); // will become -1 if there isn't desired operator in string
                        if (operatorPosition == -1) 
                        {
                            continue;
                        }
                        if (Double.TryParse(input.Substring(0, operatorPosition), out firstValue))
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (i == 4) // if operator is "pow"
                    {
                        secondValue = Double.Parse(input.Substring(input.IndexOf(operators[i].ToLower()) + 3)); // +3 because line "pow" have 3 characters. We need substring since "w", not "p".
                    }
                    else
                    {
                        secondValue = Double.Parse(input.Substring(input.IndexOf(operators[i].ToLower(), 1) + 1));
                    }

                    switch (operators[i])
                    {
                        case "+":
                            result = firstValue + secondValue;
                            break;
                        case "-":
                            result = firstValue - secondValue;
                            break;
                        case "*":
                            result = firstValue * secondValue;
                            break;
                        case "/":
                            result = firstValue / secondValue;
                            break;
                        case "pow":
                            result = Math.Pow(firstValue, secondValue);
                            break;
                    }
                }

                else if (unaryOperator.IsMatch(input))
                {
                    if (input.Substring(0, 4) == "sqrt")
                    {
                        result = Math.Sqrt(Double.Parse(input.Substring(4)));
                    }
                    else if (input.Substring(0, 3) == "sqr")
                    {
                        result = Math.Pow(Double.Parse(input.Substring(3)), 2);
                    }
                }

                else
                {
                    Console.WriteLine("Incorrect input. Please follow the templates. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine($"Result is:  {result}");
                Console.WriteLine($"{Environment.NewLine}Press any key to count something again.");
                Console.ReadKey();
            }
        }
    }
}
