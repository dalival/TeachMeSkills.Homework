using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToText
{
    public class NumberToText
    {
        /// <summary>
        /// Переводит число в текст и единицы измерения, например "тринадцать рублей".
        /// </summary>
        /// <param name="number">Число, которое необходимо перевести в текст.</param>
        /// <param name="words">Единицы измерения (ед ч Им п, ед ч Род п, мн ч Род п).
        /// Например: доллар, доллара, долларов.</param>
        /// <returns>Строку с числом и единицей измерения в нужной форме.</returns>
        public string ToText(int number, IEnumerable<string> words)
        {
            var listWords = words.ToList();
            var answer = "";

            if (listWords.Count != 3)
            {
                throw new Exception("Неверное количество слов. Ожидалось: 3");
            }

            switch (number)
            {
                case > 1000000:
                    throw new Exception("Функция принимает значения до 1 000 000");
                case < 0:
                    answer += "минус ";
                    number = Math.Abs(number);
                    break;
                case 0:
                    return $"ноль {listWords[2]}";
                case 1000000:
                    return $"миллион {listWords[2]}";
            }


            var thousands = number / 1000;
            var hundreds = (number - thousands * 1000) / 100;
            var units = number - thousands * 1000 - hundreds * 100;

            if (thousands > 0)
            {
                answer += ThousandsToText(thousands);
            }

            if (hundreds > 0)
            {
                answer += HundredsToText(hundreds);
                answer += " ";
            }

            if (units > 0)
            {
                answer += UnitsToText(units);
                answer += " ";
            }

            answer = answer.ToLower().Trim();
            answer += " ";

            var lastNumber = number % 10;
            var penultimateNumber = number % 100 / 10;

            if (penultimateNumber == 1)
            {
                answer += listWords[2];
            }
            else
            {
                switch (lastNumber)
                {
                    case 1:
                        answer += listWords[0];
                        break;
                    case 2:
                    case 3:
                    case 4:
                        answer += listWords[1];
                        break;
                    default:
                        answer += listWords[2];
                        break;
                }
            }

            return answer;
        }

        private string ThousandsToText(int thousands)
        {
            var answer = "";

            var hundreds = thousands / 100;
            var units = thousands - hundreds * 100;

            if (hundreds > 0)
            {
                answer += HundredsToText(hundreds);
                answer += " ";
            }

            if (units > 0)
            {
                answer += UnitsToText(units, true);
                answer += " ";
            }

            return answer;
        }

        private string HundredsToText(int hundreds)
        {
            return hundreds switch
            {
                1 => "Сто",
                2 => "Двести",
                3 => "Триста",
                4 => "Четыреста",
                5 => "Пятьсот",
                6 => "Шестьсот",
                7 => "Семьсот",
                8 => "Восемьсот",
                9 => "Девятьсот",
                _ => throw new Exception("Количество сотен оказалось больше девяти.")
            };
        }

        private string TensToText(int tens)
        {
            return tens switch
            {
                0 => "",
                2 => "Двадцать",
                3 => "Тридцать",
                4 => "Сорок",
                5 => "Пятьдесят",
                6 => "Шестьдесят",
                7 => "Семьдесят",
                8 => "Восемьдесят",
                9 => "Девяносто",
                _ => throw new Exception("Количество десятков оказалось больше девяти.")
            };
        }

        private string UnitsToText(int units, bool isThousands = false)
        {
            var answer = "";

            if (units > 20)
            {
                var tens = units / 10;
                answer += TensToText(tens);
                answer += " ";
                units -= tens * 10;
            }

            switch (units)
            {
                case 0: return answer;
                case 1: answer += isThousands ? "Одна тысяча" : "Один"; break;
                case 2: answer += isThousands ? "Две тысячи" : "Два"; break;
                case 3: answer += isThousands ? "Три тысячи" : "Три"; break;
                case 4: answer += isThousands ? "Четыре тысячи" : "Четыре"; break;
                case 5: answer += "Пять"; break;
                case 6: answer += "Шесть"; break;
                case 7: answer += "Семь"; break;
                case 8: answer += "Восемь"; break;
                case 9: answer += "Девять"; break;
                case 10: answer += "Десять"; break;
                case 11: answer += "Одинадцать"; break;
                case 12: answer += "Двенадцать"; break;
                case 13: answer += "Тринадцать"; break;
                case 14: answer += "Четырнадцать"; break;
                case 15: answer += "Пятнадцать"; break;
                case 16: answer += "Шестнадцать"; break;
                case 17: answer += "Семнадцать"; break;
                case 18: answer += "Восемнадцать"; break;
                case 19: answer += "Девятнадцать"; break;
            }

            if (units > 4 && isThousands)
            {
                answer += " тысяч";
            }

            return answer;
        }
    }
}
