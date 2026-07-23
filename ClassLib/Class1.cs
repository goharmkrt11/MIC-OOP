namespace ClassLib
{
    public readonly struct Position
    {
        public int Row { get; set; }
        public char Column { get; set; }

        public Position(int row, char column)
        {
            Row = row;
            Column = column;
        }
    }

    public enum ChessPiece
    {
        R,
        N,
        B,
        Q,
        K
    }

    public static class ChessBoard
    {
        public static char[,] CreateMatrix()
        {
            char[,] board = new char[9, 9];

            FillBoard(board);
            FillLetters(board);
            FillNumbers(board);

            return board;
        }

        private static void FillNumbers(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                board[i, 0] = (char)('1' + i);
            }
        }

        private static void FillLetters(char[,] board)
        {
            char letter = 'A';

            for (int i = 1; i < 9; i++)
            {
                board[8, i] = letter;
                letter++;
            }
        }

        private static void FillBoard(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    board[i, j] = (i + j) % 2 == 0 ? '#' : '*';
                }
            }
        }

        public static void PlacePiece(char[,] board, Position position, ChessPiece piece)
        {
            int row = position.Row - 1;
            int column = position.Column - 'A' + 1;

            board[row, column] = piece.ToString()[0];
        }
    }
}