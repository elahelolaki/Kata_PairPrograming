using System;
using System.Linq;
using System.Text;

namespace Roman
{
    public static class RomanNumber
    {
        public static string ConvertToRoman(int number)
        {
            int tousands = (number / 1000) % 10;
            int hundreds = (number / 100) % 10;  
            int tens = (number / 10) % 10;
            int ones = number % 10;

            string result = string.Empty;
            if (tousands > 0)
                result += SymbolHundredss.M.ToString();
            result += PositionNumber(hundreds, typeof(SymbolHundredss));
            result += PositionNumber(tens, typeof(SymbolTens));
            result += PositionNumber(ones, typeof(SymbolOnes));
            if (String.IsNullOrEmpty(result))
            {
                throw new ArgumentException("Value can't be converted");
            }
            return result;
        }


        public static string PositionNumber(int digit, Type t)
        {
            string final = "";
            StringBuilder result = new StringBuilder();
            result.Clear();
            if (digit <= 3)
            {
                final += string.Concat(Enumerable.Repeat((t as Type).GetEnumName(1), digit));  
            }
            else if (digit == 4)
            {
                final += (t as Type).GetEnumName(1) + (t as Type).GetEnumName(5);
                  // result.Append(symbol.one + symbol.five);
            }
            else if (digit == 5)
            {
                final += (t as Type).GetEnumName(5);
                //result.Append(symbol.five);
            }
            else if (digit >= 6 && digit <= 8)
            {
                final += (t as Type).GetEnumName(5) + string.Concat(Enumerable.Repeat((t as Type).GetEnumName(1), digit-5));
                //result.Append(symbol.five + RepeatLiteral(number - 5, symbol.one));
            }
            else if (digit == 9)
            {
                final += (t as Type).GetEnumName(1) + (t as Type).GetEnumName(10);
                //result.Append(symbol.one + symbol.ten);
            }
            //return result.ToString();
            return final;
        }
    }
}
