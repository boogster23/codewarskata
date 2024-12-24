using System.Runtime.CompilerServices;
using System.Text;

namespace CodeKataConsole
{
    public class KataHumanReadableTime
    {

        private static int Setup(int seconds, int timeUnitCount, string timeUnit, StringBuilder friendlyName, bool isSucceeding, bool isLast)
        {
            var quotient = seconds / timeUnitCount;
            var remainingSeconds = seconds % timeUnitCount;

            if (quotient > 0)
            {
                if (friendlyName.Length > 0 && isSucceeding)
                    friendlyName.Append(remainingSeconds > 0 && !isLast ? ", " : " and ");

                if (quotient == 1)
                    friendlyName.Append($"{quotient} {timeUnit}");
                else
                    friendlyName.Append($"{quotient} {timeUnit}s");
            }

            return remainingSeconds;
        }

        public static string formatDuration2(int seconds)
        {
            var minuteCount = 60;
            var hourCount = minuteCount * 60;
            var dayCount = hourCount * 24;
            var yearCount = dayCount * 365;

            var friendlyName = new StringBuilder();

            if (seconds <= 0) return "now";

            var remainingSeconds = Setup(seconds, yearCount, "year", friendlyName, true, false);
            remainingSeconds = Setup(remainingSeconds, dayCount, "day", friendlyName, true, false);
            remainingSeconds = Setup(remainingSeconds, hourCount, "hour", friendlyName, true, false);
            remainingSeconds = Setup(remainingSeconds, minuteCount, "minute", friendlyName, true, false);
            remainingSeconds = Setup(remainingSeconds, 1, "second", friendlyName, true, true);

            return friendlyName.ToString();
        }

        public static string formatDuration(int seconds)
        {
            var minuteCount = 60;
            var hourCount = minuteCount * 60;
            var dayCount = hourCount * 24;
            var yearCount = dayCount * 365;

            var friendlyName = new StringBuilder();

            if (seconds <= 0) return "now";

            var yearQuotient = seconds / yearCount;
            var remainingSecondsForDays = seconds % yearCount;
            var dayQuotient = remainingSecondsForDays / dayCount;
            var remainingSecondsForHours = seconds % dayCount;
            var hoursQuotient = remainingSecondsForHours / hourCount;
            var remainingSecondsForMinutes = remainingSecondsForHours % hourCount;
            var minutesQuotient = remainingSecondsForMinutes / minuteCount;
            var remainingSeconds = remainingSecondsForMinutes % minuteCount;

            if (yearQuotient > 0)
            {
                if (yearQuotient == 1)
                    friendlyName.Append($"{yearQuotient} year");
                else
                    friendlyName.Append($"{yearQuotient} years");
            }

            if (dayQuotient > 0)
            {
                if (friendlyName.Length > 0)
                    friendlyName.Append(remainingSecondsForHours > 0 ? ", " : " and ");

                if (dayQuotient == 1)
                    friendlyName.Append($"{dayQuotient} day");
                else
                    friendlyName.Append($"{dayQuotient} days");
            }

            if (hoursQuotient > 0)
            {
                if (friendlyName.Length > 0)
                    friendlyName.Append(remainingSecondsForMinutes > 0 ? ", " : " and ");

                if (hoursQuotient == 1)
                    friendlyName.Append($"{hoursQuotient} hour");
                else
                    friendlyName.Append($"{hoursQuotient} hours");
            }

            if (minutesQuotient > 0)
            {
                if (friendlyName.Length > 0)
                    friendlyName.Append(remainingSeconds > 0 ? ", " : " and ");

                if (minutesQuotient == 1)
                    friendlyName.Append($"{minutesQuotient} minute");
                else
                    friendlyName.Append($"{minutesQuotient} minutes");
            }

            if (remainingSeconds > 0)
            {
                if (friendlyName.Length > 0)
                    friendlyName.Append(" and ");

                if (remainingSeconds == 1)
                    friendlyName.Append($"{remainingSeconds} second");
                else
                    friendlyName.Append($"{remainingSeconds} seconds");
            }

            return friendlyName.ToString();
        }

        public static string formatDuration3(int seconds)
        {
            if (seconds <= 0) return "now";

            var units = new (int UnitCount, string UnitName)[]
            {
                (365 * 24 * 60 * 60, "year"),
                (24 * 60 * 60, "day"),
                (60 * 60, "hour"),
                (60, "minute"),
                (1, "second")
            };

            var friendlyName = new StringBuilder();

            void BuildDuration(int remainingSeconds, int unitIndex)
            {
                if (unitIndex >= units.Length || remainingSeconds <= 0) return;

                var (unitCount, unitName) = units[unitIndex];
                var quotient = remainingSeconds / unitCount;

                if (quotient > 0)
                {
                    if (friendlyName.Length > 0)
                        friendlyName.Append(remainingSeconds % unitCount > 0 && unitIndex < units.Length - 1 ? ", " : " and ");

                    friendlyName.Append(quotient == 1 ? $"{quotient} {unitName}" : $"{quotient} {unitName}s");
                }

                BuildDuration(remainingSeconds % unitCount, unitIndex + 1);
            }

            BuildDuration(seconds, 0);

            return friendlyName.ToString();
        }
    }
}
