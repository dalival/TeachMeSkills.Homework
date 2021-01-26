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
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write($"Ваше число: {number}"); // знак доллара чтобы считывать
                                                    // переменные в фигурных скобках
            Console.ReadKey(); // чтобы программа не вылетала в конце
        }
    }
}