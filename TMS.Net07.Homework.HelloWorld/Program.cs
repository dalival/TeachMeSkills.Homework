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
            int number = 0; // мне говорили, что лучше присваивать начальное значение. Безопаснее.
            while (true)
            {
                Console.Write("Введите целое число: ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out number))
                        break;
                    else
                        Console.WriteLine("Введите корректное число!");
                }
                if (number == 0)
                {
                    Console.WriteLine("\nВвод нуля прекращает выполнение программы. До новых встреч!");
                    break;
                }
                Console.WriteLine($"\nВаше число: {number}." +
                    "\nМожете ввести еще одно, мы можем делать это до бесконечности." +
                    "\nЕсли надоело, введите 0.\n");
            }
            Console.ReadKey(); // чтобы программа не вылетала в конце
        }
    }
}

//TODO: что если пользователь сразу введет 0? Программа вылетит, а он не поймет почему.
//UPD: добавил сообщение о выходе из программы. Так хоть понятно будет почему вылетело.