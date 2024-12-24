namespace CodeKataConsole
{
    public static class KataFactorialTrailingZeroes
    {
        public static int TrailingZeros(int n)
        {
            int trailingZeroesCount = 0;

            for (int power = 5; n / power > 0; power *= 5)
            {
                trailingZeroesCount += n / power;
            }

            return trailingZeroesCount;
        }
    }
}
