namespace CodeKataConsole
{
    public class KataNextBigNumber
    {
        public static long NextBiggerNumber(long n)
        {
            var numberCharArray = n.ToString().ToCharArray();
            int i;

            for (i = numberCharArray.Length - 2; i >= 0; i--)
            {
                if (numberCharArray[i] < numberCharArray[i + 1])
                    break;
            }

            if (i < 0)
                return -1;

            int j;
            for (j = numberCharArray.Length - 1; j > i; j--)
            {
                if (numberCharArray[j] > numberCharArray[i])
                    break;
            }

            var tempCharNumber = numberCharArray[i];
            numberCharArray[i] = numberCharArray[j];
            numberCharArray[j] = tempCharNumber;

            Array.Reverse(numberCharArray, i + 1, numberCharArray.Length - (i + 1));

            return long.TryParse(new string(numberCharArray), out long nextBigNumber) ? nextBigNumber : -1;
        }
    }
}