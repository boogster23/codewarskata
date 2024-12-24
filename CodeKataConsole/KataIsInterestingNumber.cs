using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeKataConsole
{
    public static class KataIsInterestingNumber
    {
        /// <summary>
        /// Any digit followed by all zeros: 100, 90000
        /// Every digit is the same number: 1111
        /// The digits are sequential, incementing†: 1234
        /// The digits are sequential, decrementing‡: 4321
        /// The digits are a palindrome: 1221 or 73837
        /// The digits match one of the values in the awesomePhrases array
        /// </summary>
        /// <param name="number"></param>
        /// <param name="awesomePhrases"></param>
        /// <returns></returns>
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            var numberString = number.ToString();

            Console.WriteLine($"number: {number}");
            Console.WriteLine($"awesomePhrases: {string.Join(", ", awesomePhrases)} ");
            // Happy Coding :)

            // check for palindrome
            if (numberString.SequenceEqual(numberString.Reverse()))
            {
                return 2;
            }

            if (awesomePhrases.Contains(number))
            {
                return 2;
            }

            if (awesomePhrases.Any(ap => ap == number + 1 || ap == number - 1))
            {
                return 1;
            }

            if (number % 100 == 0)
            {
                return 2;
            }

            if (number % 100 == 1 || number % 100 == 99 || number % 100 == 9)
            {
                return 1;
            }

            var index = 0;
            while (index < numberString.Length - 1)
            {
                if((int)numberString[index] + 1 ==  (int)numberString[index + 1])
                {

                }

                index++;
            }

            return 0;
        }
    }
}
