namespace ClassLib
{
    public class Board
    {
        private readonly char[,] board;

        public Board()
        {
            board = new char[8, 8];

            FillBoard();
        }

        public char this[int row, char column]
        {
            get
            {
                return board[8-row , column - 'A'];
            }

            set
            {
                board[8-row , column - 'A'] = value;
            }
        }

        public char[,] GetBoard()
        {
            return board;
        }

        public void PlacePiece(Position position, Piece piece)
        {
            this[position.Row, position.Column] =
                piece.ToString()[0];
        }

        public void MovePiece(Position startPosition, Position endPosition, Piece piece)
        {
            PlacePiece(endPosition, piece);

            if ((startPosition.Row + startPosition.Column) % 2 == 0)
            {
                this [startPosition.Row, startPosition.Column] = '#';
            }
            else
            {
                this [startPosition.Row, startPosition.Column] = '*';
            }

        }

        private void FillBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] =
                        (i + j) % 2 == 0 ? '#' : '*';
                }
            }
        }
    }
}