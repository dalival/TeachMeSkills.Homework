using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginner
{
    class Program
    {
        // National Bank of The Republic of Belarus (07.02.2021)
        const double BYNtoUSD = 0.3805;
        const double BYNtoEUR = 0.318;
        const double BYNtoRUB = 28.5527;
        const double USDtoBYN = 2.6282;
        const double USDtoEUR = 0.8357;
        const double USDtoRUB = 75.0421;
        const double EURtoBYN = 3.1448;
        const double EURtoUSD = 1.1966;
        const double EURtoRUB = 89.7924;
        const double RUBtoBYN = 0.035023;
        const double RUBtoUSD = 0.013326;
        const double RUBtoEUR = 0.011137;

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Supported currencies: BYN, USD, EUR, RUB", Environment.NewLine);
                string source;
                Console.WriteLine($"{Environment.NewLine}Input source currency:");
                Console.Write("-> ");
                while (true)
                {
                    source = Console.ReadLine().ToUpper();
                    if (source != "BYN" && source != "USD" && source != "EUR" && source != "RUB")
                    {
                        Console.WriteLine($"{Environment.NewLine}Invalid input. Please input supported currency:");
                        Console.Write("-> ");
                        continue;
                    }
                    break;
                }

                string target;
                Console.WriteLine($"{Environment.NewLine}Input target currency:");
                Console.Write("-> ");
                while (true)
                {
                    target = Console.ReadLine().ToUpper();
                    if (target != "BYN" && target != "USD" && target != "EUR" && target != "RUB")
                    {
                        Console.WriteLine($"{Environment.NewLine}Invalid input. Please input supported currency:");
                        Console.Write("-> ");
                        continue;
                    }
                    if (target == source)
                    {
                        Console.WriteLine($"{Environment.NewLine}You can't convert from {source} to {target}. Please input another currency:");
                        Console.Write("-> ");
                        continue;
                    }
                    break;
                }

                double amount;
                Console.WriteLine($"{Environment.NewLine}Input amount:");
                Console.Write("-> ");
                while (true)
                {
                    if (!Double.TryParse(Console.ReadLine(), out amount))
                    {
                        Console.WriteLine($"{Environment.NewLine}Invalid input. Please input the correct value:");
                        Console.Write("-> ");
                        continue;
                    }
                    if (amount < 0)
                    {
                        Console.WriteLine($"{Environment.NewLine}Amount can not be negative. Please input the correct value:");
                        Console.Write("-> ");
                        continue;
                    }
                    break;
                }

                double coefficient = 0;
                switch (source)
                {
                    case "BYN":
                        switch (target)
                        {
                            case "USD":
                                coefficient = BYNtoUSD;
                                break;
                            case "EUR":
                                coefficient = BYNtoEUR;
                                break;
                            case "RUB":
                                coefficient = BYNtoRUB;
                                break;
                        }
                        break;
                    case "USD":
                        switch (target)
                        {
                            case "BYN":
                                coefficient = USDtoBYN;
                                break;
                            case "EUR":
                                coefficient = USDtoEUR;
                                break;
                            case "RUB":
                                coefficient = USDtoRUB;
                                break;
                        }
                        break;
                    case "EUR":
                        switch (target)
                        {
                            case "BYN":
                                coefficient = EURtoBYN;
                                break;
                            case "USD":
                                coefficient = EURtoUSD;
                                break;
                            case "RUB":
                                coefficient = EURtoRUB;
                                break;
                        }
                        break;
                    case "RUB":
                        switch (target)
                        {
                            case "BYN":
                                coefficient = RUBtoBYN;
                                break;
                            case "USD":
                                coefficient = RUBtoUSD;
                                break;
                            case "EUR":
                                coefficient = RUBtoEUR;
                                break;
                        }
                        break;
                }

                double result = Math.Round(amount * coefficient, 4);
                amount = Math.Round(amount, 4);
                Console.WriteLine($"{Environment.NewLine}{amount} {source} is equal to {result} {target}");
                Console.WriteLine($"{Environment.NewLine}Do you want to convert again? Press Y or N.");
                string yesOrNo;
                while (true)
                {
                    yesOrNo = Console.ReadKey(true).Key.ToString().ToLower();
                    if (yesOrNo == "y" || yesOrNo == "n")
                    {
                        break;
                    }
                }
                if (yesOrNo == "n")
                {
                    Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Ok, good bye!");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}