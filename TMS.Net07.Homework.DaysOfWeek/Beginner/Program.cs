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
                            Console.WriteLine($"{Environment.NewLine}This command ends the program. Good bye!");
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
                        Console.WriteLine($"{Environment.NewLine}Понедельник");
                        break;
                    case DaysOfWeek.Tuesday:
                        Console.WriteLine($"{Environment.NewLine}Вторник");
                        break;
                    case DaysOfWeek.Wednesday:
                        Console.WriteLine($"{Environment.NewLine}Среда");
                        break;
                    case DaysOfWeek.Thursday:
                        Console.WriteLine($"{Environment.NewLine}Четверг");
                        break;
                    case DaysOfWeek.Friday:
                        Console.WriteLine($"{Environment.NewLine}Пятница");
                        break;
                    case DaysOfWeek.Saturday:
                        Console.WriteLine($"{Environment.NewLine}Суббота");
                        break;
                    case DaysOfWeek.Sunday:
                        Console.WriteLine($"{Environment.NewLine}Воскресенье");
                        break;
                }

                Console.WriteLine($"{Environment.NewLine}Ok let's do it again. Or enter \"exit\" to exit.");
            }
        }
    }
}