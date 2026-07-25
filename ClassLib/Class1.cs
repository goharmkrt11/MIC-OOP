namespace ClassLib
{
    //TODO Separate classes
    public readonly struct Position
    {
        public int Row { get; }
        public char Column { get; }

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

    public class ChessBoard
    {
        private readonly char[,] board;

        public ChessBoard()
        {
            board = new char[9, 9];

            FillBoard();
            FillLetters();
            FillNumbers();
        }

        public char this[int row, char column]
        {
            get
            {
                return board[row - 1, column - 'A' + 1];
            }

            set
            {
                board[row - 1, column - 'A' + 1] = value;
            }
        }

        public char[,] GetBoard()
        {
            return board;
        }

        private void FillNumbers()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i, 0] = (char)('1' + i);
            }
        }

        private void FillLetters()
        {
            char letter = 'A';

            for (int i = 1; i < 9; i++)
            {
                board[8, i] = letter;
                letter++;
            }
        }

        private void FillBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    board[i, j] =
                        (i + j) % 2 == 0 ? '#' : '*';
                }
            }
        }

        public void PlacePiece(
            Position position,
            ChessPiece piece)
        {
            this[position.Row, position.Column] =
                piece.ToString()[0];
        }
    }
}
