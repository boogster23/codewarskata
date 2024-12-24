using System;
using System.Text;

namespace CodeKataConsole
{
    public class RomanConvert
    {
        public static string Solution(int n)
        {
            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[n / 1000] +
                   hundreds[(n % 1000) / 100] +
                   tens[(n % 100) / 10] +
                   units[n % 10];
        }
    }
}
