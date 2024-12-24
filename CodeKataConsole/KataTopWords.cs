using System.Text.RegularExpressions;

namespace CodeKataConsole
{
    public class KataTopWords
    {
        public static List<string> Top3(string s)
        {
            var wordRegexPattern = @"[^a-zA-Z']+";
            var groupedWordArray = Regex.Split(s, wordRegexPattern)
                 .GroupBy(word => word.ToLower())
                 .Where(group => !string.IsNullOrWhiteSpace(group.Key) && group.Key.Any(char.IsLetter) && group.Count() > 0)
                 .Select(group => new { Word = group.Key, Count = group.Count() });

            return groupedWordArray.OrderByDescending(g => g.Count).Select(g => g.Word).Take(3).ToList();
        }

        public static List<string> Top3Too(string s) {
            return Regex.Matches(s.ToLowerInvariant(), @"('*[a-z]'*)+")
           .GroupBy(match => match.Value)
           .OrderByDescending(g => g.Count())
           .Select(p => p.Key)
           .Take(3)
           .ToList();
        }
    }
}
