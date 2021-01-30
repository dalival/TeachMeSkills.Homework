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
        static bool CheckDate(int day, int month, int year)
        {
            if (year > 0 && year < 3000)
            {
                if (month > 0 && month < 13)
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
                            if (day > 0 && day < 32)
                                return true;
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (day > 0 && day < 31)
                                return true;
                            break;
                        case 2:
                            if (year%4 == 0) //leap year
                            {
                                if (day > 0 && day < 30)
                                    return true;
                            }
                            else
                            {
                                if (day > 0 && day < 29)
                                    return true;
                            }
                            break;
                    }
                }
            }
            return false;
        }
        static int CalculateAmountOfDays(int day, int month, int year)
        {
            int amountPastYears = (365 * (year - 1)) + ((year - 1) / 4);
            int amountThisYear = 0;
            switch (month - 1)
            {
                case 0:
                    amountThisYear = day;
                    break;
                case 1:
                    amountThisYear = 31 + day;
                    break;
                case 2:
                    amountThisYear = 59 + day;
                    if (year%4 == 0)
                        amountThisYear++;
                    break;
                case 3:
                    amountThisYear = 90 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 4:
                    amountThisYear = 120 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 5:
                    amountThisYear = 151 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 6:
                    amountThisYear = 181 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 7:
                    amountThisYear = 212 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 8:
                    amountThisYear = 243 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 9:
                    amountThisYear = 273 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 10:
                    amountThisYear = 304 + day;
                    if (year % 4 == 0)
                        amountThisYear++;
                    break;
                case 11:
                    amountThisYear = 334 + day;
                    if (year % 4 == 0)
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
        static void Main(string[] args)
        {
            string dateFormat = @"[0-3]\d\.[0-1]\d\.\d{4}"; //doesn't check 100% adequacy
            while (true)
            {
                Console.WriteLine("Enter date in format DD.MM.YYYY:");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("\nThis command finish the program. Good bye!");
                    break;
                }
                if (Regex.IsMatch(input, dateFormat))
                {
                    //I can use Parse instead of TryParse because of regex above
                    int day = int.Parse(input.Substring(0, 2));
                    int month = int.Parse(input.Substring(3, 2));
                    int year = int.Parse(input.Substring(6));
                    if (CheckDate(day, month, year))
                        Console.WriteLine("\nIt's " + CalculateDayOfWeek(day, month, year) + ". Enter another date or \"exit\" to exit.\n");
                    else
                        Console.WriteLine("Incorrect input. Such date doesn't exist. If you want to exit enter \"exit\".\n");
                }
                else
                    Console.WriteLine("Incorrect input. Please follow the DD.MM.YYYY format. If you want to exit enter \"exit\".\n");
            }
            Console.ReadKey();
        }
    }
}