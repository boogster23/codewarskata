using System.Text.RegularExpressions;

namespace CodeKataConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SpinWords("Hey fellow warriors"));
            var strValue = "Cat";
            Console.WriteLine($"{strValue} is IsoGram: {IsIsogram(strValue)}");

            Console.WriteLine("Testing PrinterError");
            var s = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
            Console.WriteLine($"PrinterError(s) : {PrinterError(s)}");

            Console.WriteLine("Testing Narcissistic Number");
            var narValue = 371;
            Console.WriteLine($"Narcissistic value {narValue} : {Narcissistic(narValue)}");

            Console.WriteLine($"Disemvowel: {Disemvowel("No offense but,\nYour writing is among the worst I've ever read")}");

            Console.WriteLine($"To JadenCase: {ToJadenCase("How can mirrors be real if our eyes aren't real")}");

            Console.WriteLine($"To Rgb String (300,101,50) : {Rgb(300, 10, -1)}");

            int[] a = { 121, 144, 19, 161, 19, 144, 19, 11 };
            int[] b = { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };

            Console.WriteLine($"Array Comp Test: {Comp(a, b)}");


            string[] a1 = ["tarp", "mice", "bull"];
            string[] a2 = ["lively", "alive", "harp", "sharp", "armstrong"];
            Console.WriteLine($"Lexicographical InArray Test: {string.Join(", ", InArray(a1, a2))}");

            int[] oddOutlierArray = [-5, 6, 6];
            int[] evenOutlierArray = [160, 3, 1719, 19, 11, 13, -21];

            Console.WriteLine($"Parity Outlier: {FindParityOutlier(oddOutlierArray)}");

            int intForRomanConversion = 588;
            Console.WriteLine($"Roman Converter ({intForRomanConversion}): {RomanConvert.Solution(intForRomanConversion)}");

            int[,] board = new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } };
            int[,] incBoard = new int[,] { { 0, 0, 2 }, { 0, 0, 0 }, { 1, 0, 1 } };
            Console.WriteLine($"TicTacToe Result: {TicTacToe.IsSolved(incBoard)}");

            Console.WriteLine($"KataIsInterestingNumber Result: {KataIsInterestingNumber.IsInteresting(
                3, [1337, 256])}");
            Console.WriteLine($"KataIsInterestingNumber Result: {KataIsInterestingNumber.IsInteresting(
                1336, [1337, 256])}");
            Console.WriteLine($"KataIsInterestingNumber Result: {KataIsInterestingNumber.IsInteresting(
                1337, [1337, 256])}");
            Console.WriteLine($"KataIsInterestingNumber Result: {KataIsInterestingNumber.IsInteresting(
                100, [1337, 256])}");
            Console.WriteLine($"KataIsInterestingNumber Result: {KataIsInterestingNumber.IsInteresting(
                110101, [1337, 256])}");
            Console.WriteLine($"KataIsInterestingNumber Result: {KataIsInterestingNumber.IsInteresting(
                99, [1337, 256])}");

            Console.WriteLine($"Kata ROT13: {KataROT13.Rot13("EBG13 rknzcyr.")}");
            Console.WriteLine($"Kata Top Words: {string.Join(", ", KataTopWords.Top3("  '''  "))}");

            Console.WriteLine($"Kata Human Readable Num: {KataHumanReadableTime.formatDuration(33243586)}");
            Console.WriteLine($"Kata Human Readable Num: {KataHumanReadableTime.formatDuration2(33243586)}");
            Console.WriteLine($"Kata Human Readable Num: {KataHumanReadableTime.formatDuration3(33243586)}");

            Console.WriteLine($"Kata Int to String Parser: {KataParseIntReloaded.ParseInt("six hundred sixty-six thousand six hundred sixty-six")}");
            Console.WriteLine($"Kata Int to String Parser: {KataParseIntReloaded.ParseInt("Two hundred Forty-six")}");
            Console.WriteLine($"Kata Int to String Parser: {KataParseIntReloaded.ParseInt("Zero")}");
        }

        public static string PrinterError(String s)
        {
            // your code
            return $"{Regex.Matches(s, "[n-zN-Z]").Count}/{s.Length}";
        }

        public static string SpinWords(string sentence)
        {
            return String.Join(" ", sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
        }

        public static bool IsIsogram(string str)
        {
            // Code on you crazy diamond!
            return str.ToLower().Distinct().Count() == str.Length;
        }

        public static bool Narcissistic(int value)
        {
            // Code me
            var intCharArray = value.ToString().ToCharArray();
            var totalInt = 0;

            foreach (var intChar in intCharArray)
            {
                totalInt += (int)Math.Pow(intChar - '0', intCharArray.Length);

                if (totalInt > value)
                {
                    return false;
                }
            }

            return totalInt == value;
        }

        public static string Disemvowel(string str)
        {
            return Regex.Replace(str, "[aeiou]", "", RegexOptions.IgnoreCase);
        }

        public static string ToJadenCase(string phrase)
        {
            return string.Join(" ", phrase.Split(" ").Select(p => $"{char.ToUpper(p[0])}{p.Substring(1)}"));
        }

        public static string Rgb(int r, int g, int b)
        {
            int limiter(int input) => Math.Clamp(input, 0, 255);
            return $"{limiter(r):X2}{limiter(g):X2}{limiter(b):X2}";
        }

        public static bool Comp(int[] a, int[] b)
        {
            // your code
            if (a is null || b is null || a.Length != b.Length)
                return false;

            return a.OrderBy(aInt => aInt)
                    .Select(aInt => aInt * aInt)
                    .SequenceEqual(b.OrderBy(bInt => bInt));
        }

        public static string[] InArray(string[] array1, string[] array2)
        {
            return array1.OrderBy(a1 => a1)
                       .Select(a1 => a1)
                       .Where(a1 => array2.Any(a2 => a2.Contains(a1)))
                       .ToArray();

            // your code
        }

        public static int FindParityOutlier(int[] integers)
        {
            return integers.GroupBy(x => x % 2, x => x)
                   .OrderBy(x => x.Count())
                   .First().First();
        }

        public static bool Alphanumeric(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            // your code here
            return Regex.IsMatch(str, @"^[a-z0-9]*$", RegexOptions.IgnoreCase);
        }
    }
}
