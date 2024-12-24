using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKataConsole
{
    public static class KataROT13
    {
        public static string Rot13(string input)
        {
            var result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    var offset = char.IsUpper(c) ? 'A' : 'a';
                    Console.WriteLine($"((c - offset + 13) % 26): {((c - offset + 13) % 26)}");
                    result.Append((char)(((c - offset + 13) % 26) + offset));
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
