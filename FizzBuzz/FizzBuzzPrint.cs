using System;

namespace FizzBuzz
{
    public static class FizzBuzzPrint
    {
        public static string Print(int digit)
        {
            string result = string.Empty;
            if (digit % 3 == 0)
                result += "Fizz";

            if (digit % 5 == 0)
                result += "Buzz";

            if (result == string.Empty)
                result = digit.ToString();

            return result;
        }
    }
}
