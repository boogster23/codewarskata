namespace CodeKataConsole
{
    /// <summary>
    /// -1 if the board is not yet finished AND no one has won yet (there are empty spots),
    /// if "X" won,
    /// 2 if "O" won,
    /// 0 if it's a cat's game(i.e.a draw).
    /// </summary>
    public class TicTacToe
    {
        public static int IsSolved(int[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board.Cast<int>().Skip(i * 3).Take(3).Distinct().Count() == 1 && board[i, 0] != 0)
                {
                    return board[i, 0];
                }

                if (board.Cast<int>().Where((x, index) => index % 3 == i).Distinct().Count() == 1 && board[0, i] != 0)
                {
                    return board[0, i];
                }
            }

            var diagonal1 = new[] { board[0, 0], board[1, 1], board[2, 2] };
            var diagonal2 = new[] { board[0, 2], board[1, 1], board[2, 0] };

            if (diagonal1.Distinct().Count() == 1 && diagonal1[0] != 0)
            {
                return diagonal1[0];
            }
            if (diagonal2.Distinct().Count() == 1 && diagonal2[0] != 0)
            {
                return diagonal2[0];
            }

            if (board.Cast<int>().Any(x => x == 0))
            {
                return -1;
            }

            return 0;
        }

        public static int IsSolvedToo(int[,] board)
        {
            int d1 = 1, d2 = 1;
            bool empty = false;
            for (int i = 0; i < 3; i++)
            {
                d1 *= board[i, i];
                d2 *= board[2 - i, i];
                int row = 1, col = 1;
                for (int j = 0; j < 3; j++)
                {
                    row *= board[i, j];
                    col *= board[j, i];
                }
                if (row == 1 || col == 1) return 1;
                if (row == 8 || col == 8) return 2;
                if (row == 0 || col == 0) empty = true;
            }
            if (d1 == 1 || d2 == 1) return 1;
            if (d1 == 8 || d2 == 8) return 2;
            if (empty) return -1;

            return 0;
        }
    }
}
