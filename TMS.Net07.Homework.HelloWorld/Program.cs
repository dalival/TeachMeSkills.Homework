using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Net07.Homework.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0; // где-то мне говорили, что лучше всегда присваивать начальное значение. Безопаснее.
            Console.Write("Введите целое число: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                    break;
                else
                    Console.WriteLine("Введите корректное число!");
            }

            Console.Write($"\nВаше число: {number}. До свидания!"); // знак доллара чтобы считывать
                                                    // переменные в фигурных скобках
            Console.ReadKey(); // чтобы программа не вылетала в конце
        }
    }
}