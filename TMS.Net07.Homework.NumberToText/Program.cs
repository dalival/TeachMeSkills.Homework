using System;
using System.Collections.Generic;

namespace NumberToText
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            var units = new List<string> { "доллар", "доллара", "долларов" };
            do
            {
                Console.Clear();
                Console.WriteLine("Введите число до 1 000 000:");

                var wasNumberEntered = int.TryParse(Console.ReadLine(), out var number);
                if (!wasNumberEntered)
                {
                    Console.WriteLine("Неверное значение.");
                }
                else if (number is > 1000000 or < -1000000)
                {
                    Console.WriteLine("Ну написано же, до 1 000 000. НЕ БОЛЬШЕ ЧЕМ ОДИН МИЛЛИОН.");
                }
                else
                {
                    var converter = new NumberToText();
                    var answer = converter.ToText(number, units);
                    Console.WriteLine($"Ответ: {answer}");
                }

                Console.WriteLine("\nНажми куда-нибудь, чтобы стартануть заново. Или 'Q' чтобы выйти.");
                key = Console.ReadKey().Key;
            }
            while (key != ConsoleKey.Q);
        }
    }
}
