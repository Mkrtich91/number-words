using System.Globalization;
using System.Linq;
using System.Text;
using static System.Math;

namespace NumberWords
{
    public static class Converter
    {
        /// <summary>
        /// Returns the string representation of the <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        /// <returns>The string representation of the <paramref name="number"/>.</returns>
        public static string ConvertInteger(int number)
        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string result = string.Empty;

            if (number == 0)
            {
                result = words[0];
            }
            else if (number < 0)
            {
                result = "minus " + ConvertInteger(-number);
            }
            else
            {
                while (number > 0)
                {
                    int digit = number % 10;
                    result = words[digit] + " " + result;
                    number /= 10;
                }
            }

            return result.Trim();
        }

        /// <summary>
        /// Writes the string representation of the <paramref name="number"/> to the <paramref name="stringBuilder"/>.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        public static void ConvertDecimal(decimal number, StringBuilder stringBuilder)
        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "point" };
            string numberString = number.ToString(CultureInfo.InvariantCulture);
            _ = new StringBuilder(string.Empty);

            if (number == decimal.MinValue || number == decimal.MaxValue)
            {
                numberString += ".0";
            }

            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] == '.')
                {
                    stringBuilder.Append(words[10]).Append(' ');
                }
                else if (numberString[i] == '-')
                {
                    stringBuilder.Append("minus").Append(' ');
                }
                else
                {
                    int digit = int.Parse(numberString[i].ToString(), CultureInfo.InvariantCulture);
                    if (i == numberString.Length - 1)
                    {
                        stringBuilder.Append(words[digit]);
                    }
                    else
                    {
                        stringBuilder.Append(words[digit]).Append(' ');
                    }
                }
            }
        }

        /// <summary>
        /// Returns the string representation of the <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        /// <returns>The string representation of the <paramref name="number"/>.</returns>
        public static string ConverDouble(double number)
        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "point", "minus", "epsilon", "E", "plus" };
            StringBuilder sb = new StringBuilder();
            string ChooseNumber(char character)
            {
                string l = string.Empty;
                switch (character)
                {
                    case '0':
                        l = words[0] + ' ';
                        break;
                    case '1':
                        l = words[1] + ' ';
                        break;
                    case '2':
                        l = words[2] + ' ';
                        break;
                    case '3':
                        l = words[3] + ' ';
                        break;
                    case '4':
                        l = words[4] + ' ';
                        break;
                    case '5':
                        l = words[5] + ' ';
                        break;
                    case '6':
                        l = words[6] + ' ';
                        break;
                    case '7':
                        l = words[7] + ' ';
                        break;
                    case '8':
                        l = words[8] + ' ';
                        break;
                    case '9':
                        l = words[9] + ' ';
                        break;
                    case '.':
                        l = words[10] + ' ';
                        break;
                    case '-':
                        l = words[11] + ' ';
                        break;
                    case 'E':
                        l = words[13] + ' ';
                        break;
                    case '+':
                        l = words[14] + ' ';
                        break;
                    case (char)double.Epsilon:
                        l = words[15] + ' ';
                        break;
                }

                return l;
            }

            string FirstCharToUpperStringCreate(string input)
            {
                return $"{char.ToUpper(input[0], CultureInfo.InvariantCulture)}{input[1..]}";
            }

            string numberStr = number.ToString(CultureInfo.InvariantCulture);

            if (double.IsNaN(number))
            {
                sb.Append("NaN");
            }
            else if (number == 4.94065645841247E-324)
            {
                sb.Append("Double epsilon");
            }
            else if (double.IsNegativeInfinity(number))
            {
                sb.Append("-∞");
            }
            else if (double.IsPositiveInfinity(number))
            {
                sb.Append("+∞");
            }
            else
            {
                for (int i = 0; i < numberStr.Length; i++)
                {
                    if (i == 0)
                    {
                        if (numberStr.Length == 1)
                        {
                            _ = sb.Append(FirstCharToUpperStringCreate(ChooseNumber(numberStr[i])).Trim());
                        }
                        else
                        {
                            _ = sb.Append(FirstCharToUpperStringCreate(ChooseNumber(numberStr[i])));
                        }
                    }
                    else if (i == numberStr.Length - 1)
                    {
                        _ = sb.Append(ChooseNumber(numberStr[i]).Trim());
                    }
                    else
                    {
                        _ = sb.Append(ChooseNumber(numberStr[i]));
                    }
                }
            }

            return sb.ToString();
        }
    }
}
