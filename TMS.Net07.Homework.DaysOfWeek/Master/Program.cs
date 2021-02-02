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
            //string dateFormat = @"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"; //doesn't check 100% adequacy
            string dateFormat = @"^(0?[1-9]|[12][0-9]|3[01])[\/\-\.](0?[1-9]|1[012])[\/\-\.](0?0?0?[1-9]|0?0?[1-9]{2}|0?[1-9]{3}|1\d{3}|2\d{3})$"; //doesn't check 100% adequacy
            while (true)
            {
                Console.WriteLine("Enter date in format DD.MM.YYYY:");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine(Environment.NewLine, "This command finish the program. Good bye!");
                    break;
                }
                if (Regex.IsMatch(input, dateFormat))
                {
                    //I can use Parse instead of TryParse because of regex above
                    int day = int.Parse(input.Substring(0, 2));
                    int month = int.Parse(input.Substring(3, 2));
                    int year = int.Parse(input.Substring(6));
                    if (CheckDate(day, month, year))
                        Console.WriteLine($"{Environment.NewLine}It's {CalculateDayOfWeek(day, month, year)}. Enter another date or \"exit\" to exit.{Environment.NewLine}");
                    else
                        Console.WriteLine($"Incorrect input. Such date doesn't exist. If you want to exit enter \"exit\".{Environment.NewLine}");
                }
                else
                    Console.WriteLine($"Incorrect input. Please follow the DD.MM.YYYY format. If you want to exit enter \"exit\".{Environment.NewLine}");
            }
            Console.ReadKey();
        }
        static bool CheckDate(int day, int month, int year)
        {
            if (month == 4 || month == 6 || month == 9 || month == 11) // months with 30 days, not 31
                if (day > 30)
                    return false;
            if (month == 2) // February
            {
                if (year % 4 == 0 && !(year % 100 == 0 && year % 400 != 0)) // year is leap; year isn't 100/200/300/500 (such years are divisible by 4, but aren't leap years)
                {
                    if (day > 29)
                        return false;
                }
                else if (day > 28)
                    return false;
            }
            return true;
        }
        static int CalculateAmountOfDays(int day, int month, int year)
        {
            int amountPastYears = (365 * (year - 1)) + ((year - 1) / 4) - (year / 100 - year / 400);
            int amountThisYear = 0;
            switch (month)
            {
                case 1: // if entered month is January
                    amountThisYear = day;
                    break;
                case 2: // February
                    amountThisYear = 31 + day;
                    break;
                case 3:
                    amountThisYear = 59 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 4:
                    amountThisYear = 90 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 5:
                    amountThisYear = 120 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 6:
                    amountThisYear = 151 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 7:
                    amountThisYear = 181 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 8:
                    amountThisYear = 212 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 9:
                    amountThisYear = 243 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 10:
                    amountThisYear = 273 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 11:
                    amountThisYear = 304 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
                case 12:
                    amountThisYear = 334 + day;
                    if (year % 4 == 0)
                        if (!(year % 100 == 0 && year % 400 != 0))
                            amountThisYear++;
                    break;
            }
            return (amountPastYears + amountThisYear);
        }
        static string CalculateDayOfWeek(int day, int month, int year)
        {
            switch (CalculateAmountOfDays(day, month, year) % 7)
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
                    break;
            }
            return "Error";
        }
    }
}