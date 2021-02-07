using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


//to check if git pull works
namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            // our program is for dates from 01.01.0001 to 31.12.2999
            string dateFormat = @"^(0?[1-9]|[12][0-9]|3[01])[\/\-\.](0?[1-9]|1[012])[\/\-\.](0?0?0?[1-9]|0?0?[1-9]{2}|0?[1-9]{3}|1\d{3}|2\d{3})$"; //doesn't check 100% adequacy
            while (true)
            {
                Console.WriteLine("Enter date in format DD.MM.YYYY:");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine($"{Environment.NewLine}This command finish the program. Good bye!");
                    break;
                }
                if (Regex.IsMatch(input, dateFormat))
                {
                    //I can use Parse instead of TryParse because of regex above
                    int day = int.Parse(input.Substring(0, 2));
                    int month = int.Parse(input.Substring(3, 2));
                    int year = int.Parse(input.Substring(6));
                    if (CheckDate(day, month, year))
                    {
                        Console.WriteLine($"{Environment.NewLine}It's {GetDayOfWeek(day, month, year)}. Enter another date or \"exit\" to exit.{Environment.NewLine}");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect input. Such date doesn't exist. If you want to exit enter \"exit\".{Environment.NewLine}");
                    }
                }
                else
                {
                    Console.WriteLine($"Incorrect input. Please follow the DD.MM.YYYY format. If you want to exit enter \"exit\".{Environment.NewLine}");
                }
            }
            Console.ReadKey();
        }
        static bool CheckDate(int day, int month, int year)
        {
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30) // months with 30 days, not 31
            {
                return false;
            }
            if (month == 2) // February
            {
                if (day > 29)
                {
                    return false;
                }
                if (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0)) // if year isn't leap OR year is 100/200/300/500 (such years are divisible by 4, but aren't leap)
                {
                    if (day > 28)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static int GetNumberOfDays(int day, int month, int year)
        {
            int numberInPastYears = (365 * (year - 1)) + ((year - 1) / 4) - (year / 100 - year / 400);
            int numberInCurrentYear = 0;
            for (int i = 1; i < month; i++)
            {
                numberInCurrentYear += GetNumberOfDays(i, year);
            }
            numberInCurrentYear += day;
            return (numberInPastYears + numberInCurrentYear);
        }
        static int GetNumberOfDays(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (year % 4 == 0 && !(year % 100 == 0 && year % 400 != 0))
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                default:
                    return 0;
            }
        }
        static string GetDayOfWeek(int day, int month, int year)
        {
            switch (GetNumberOfDays(day, month, year) % 7)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                case 0:
                    return "Sunday";
                default:
                    return "Error";
            }
        }
    }
}
