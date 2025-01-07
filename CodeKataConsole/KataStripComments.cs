using System.Text;
using System.Text.RegularExpressions;

namespace CodeKataConsole
{
    public class KataStripComments
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            var lines = text.Split('\n');
            var textSb = new StringBuilder();
                       
            foreach (var line in lines)
            {
                int commentIndex = line.Length;
                foreach (var symbol in commentSymbols)
                {
                    var index = line.IndexOf(symbol);
                    if (index >= 0 && index < commentIndex)
                    {
                        commentIndex = index;
                        break;
                    }
                }

                textSb.AppendLine(line[..commentIndex].TrimEnd());
            }

            if (textSb.Length > 0)
            {
                textSb.Length -= Environment.NewLine.Length;
            }

            return textSb.ToString();
        }

        public static string StripCommentBestAnswer(string text, string[] commentSymbols)
        {
            string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
            lines = lines.Select(x => x.Split(commentSymbols, StringSplitOptions.None).First().TrimEnd()).ToArray();
            return string.Join("\n", lines);
        }

        public static string StripCommentsWithRegex(string text, string[] commentSymbols)
        {
            var escapedSymbols = commentSymbols.Select(Regex.Escape);
            var pattern = $"\\s*(?:{string.Join("|", escapedSymbols)}).*";
            return Regex.Replace(text, pattern, "").TrimEnd();
        }
    }
}