using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        //https://gist.github.com/nathankoop/3874698
        public int Add(string numbers)
        {
            List<string> correctNumbers = new List<string>();
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;


            if (numbers.Length == 1 && int.TryParse(numbers, out _))
                correctNumbers.Add(numbers);

            char[] delimiterChars = {  ',', '\n'  };
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Substring(2);
                char delimiter = numbers[0];
                if (delimiter == '[')
                {
                    var pattern = @"\[(.*?)\]";
                    var tempDelimiter =Regex.Matches(numbers, pattern); 
                    foreach (Match item in tempDelimiter)
                    { 
                        numbers =numbers.Replace(item.Groups[1].ToString(), ",");
                    }
                    addDelimiterChars(ref delimiterChars, ']');
                }
                addDelimiterChars(ref delimiterChars, delimiter); 
            }
            if (numbers.IndexOfAny(delimiterChars) != -1)
            {
                correctNumbers = numbers.Split(delimiterChars,delimiterChars.Length==2? StringSplitOptions.None: StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            } 
            if (correctNumbers.Any(s => s == ""))
                throw new Exception("NOT ok");

            if (correctNumbers.Any(s => int.Parse(s)<0))
                throw new Exception("negatives not allowed");

            return correctNumbers.Select(s=> s.Length>3?0: int.Parse(s)).Sum();
        }

        public void addDelimiterChars(ref char[] delimiterChars, char delimiter)
        {
            if (!delimiterChars.Any(w=>w==delimiter))
            {
                Array.Resize(ref delimiterChars, delimiterChars.Length + 1);
                delimiterChars[delimiterChars.Length-1] = delimiter;
            }
        }
    } 
}
