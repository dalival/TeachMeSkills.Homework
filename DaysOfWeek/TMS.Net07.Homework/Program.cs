using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Net07.Homework
{
    enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            DaysOfWeek d;
            string day;

            while (true)
            {
                Console.WriteLine("Enter a day of the week in English. I will translate it to Russian.");
                while (true)
                {
                    day = Console.ReadLine().ToLower(); // so user can enter either "Monday" or "monday" or even "MONDAY"
                    switch (day)
                    {
                        case "monday":
                            d = DaysOfWeek.Monday;
                            break;
                        case "tuesday":
                            d = DaysOfWeek.Tuesday;
                            break;
                        case "wednesday":
                            d = DaysOfWeek.Wednesday;
                            break;
                        case "thursday":
                            d = DaysOfWeek.Thursday;
                            break;
                        case "friday":
                            d = DaysOfWeek.Friday;
                            break;
                        case "saturday":
                            d = DaysOfWeek.Saturday;
                            break;
                        case "sunday":
                            d = DaysOfWeek.Sunday;
                            break;
                        case "exit":
                            Console.WriteLine("\nThis command ends the program. Good bye!");
                            Console.ReadKey();
                            return;
                        default:
                            Console.WriteLine("It isn't a day of the week. Try again.");
                            continue;
                    }
                    break;
                }

                switch (d)
                {
                    case DaysOfWeek.Monday:
                        Console.WriteLine("\nПонедельник");
                        break;
                    case DaysOfWeek.Tuesday:
                        Console.WriteLine("\nВторник");
                        break;
                    case DaysOfWeek.Wednesday:
                        Console.WriteLine("\nСреда");
                        break;
                    case DaysOfWeek.Thursday:
                        Console.WriteLine("\nЧетверг");
                        break;
                    case DaysOfWeek.Friday:
                        Console.WriteLine("\nПятница");
                        break;
                    case DaysOfWeek.Saturday:
                        Console.WriteLine("\nСуббота");
                        break;
                    case DaysOfWeek.Sunday:
                        Console.WriteLine("\nВоскресенье");
                        break;
                }

                Console.WriteLine("\nOk let's do it again. Or enter \"exit\" to exit.");
            }
        }
    }
}