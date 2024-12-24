namespace CodeKataConsole
{
    public static class KataParseIntReloaded
    {
        public static int ParseInt(string s)
        {
            var numberStringArrayEquivalent = new Dictionary<string, int>
            {
                { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 },
                { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }, { "ten", 10 },
                { "eleven", 11 }, { "twelve", 12 }, { "thirteen", 13 }, { "fourteen", 14 }, { "fifteen", 15 },
                { "sixteen", 16 }, { "seventeen", 17 }, { "eighteen", 18 }, { "nineteen", 19 }, { "twenty", 20 },
                { "thirty", 30 }, { "forty", 40 }, { "fifty", 50 }, { "sixty", 60 }, { "seventy", 70 }, { "eighty", 80 },
                { "ninety", 90 }, { "hundred", 100 }, { "thousand", 1000 }, { "million", 1000000 }
            };


            var splitChar = new char[] { ' ', '-' };
            var stringArray = s.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
            var intNumber = 0;
            var currentNumber = 0;

            foreach (var item in stringArray)
            {
                if (numberStringArrayEquivalent.TryGetValue(item.ToLower(), out int value))
                {
                    if (value >= 100) 
                    {
                        currentNumber *= value;

                        if (value >= 1000)
                        {
                            intNumber += currentNumber;
                            currentNumber = 0;
                        }
                    }
                    else
                    {
                        currentNumber += value;
                    }
                }
            }

            intNumber += currentNumber;
            return intNumber;
        }
    }
}
