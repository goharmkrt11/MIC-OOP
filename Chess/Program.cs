using ClassLib;

namespace ChessConsole
{
    internal class Program
    {
        static void Main()
        {
            char[,] board = ChessBoard.CreateMatrix();

            PrintBoard(board);

            Position position = ReadPosition();
            ChessPiece piece = ReadChessPiece();

            ChessBoard.PlacePiece(board, position, piece);

            PrintBoard(board);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static Position ReadPosition()
        {
            int row;

            do
            {
                Console.WriteLine("Please enter a row (1-8):");
            }
            while (!int.TryParse(Console.ReadLine(), out row)
                   || row < 1
                   || row > 8);

            char column;

            do
            {
                Console.WriteLine("Please enter a column (A-H):");
            }
            while (!char.TryParse(
                       (Console.ReadLine() ?? "").ToUpper(),
                       out column)
                   || column < 'A'
                   || column > 'H');

            return new Position(row, column);
        }

        static ChessPiece ReadChessPiece()
        {
            ChessPiece piece;

            do
            {
                Console.WriteLine(
                    "Please enter a chess piece (R, N, B, Q, K):");
            }
            while (!Enum.TryParse(
                       (Console.ReadLine() ?? "").ToUpper(),
                       out piece)
                   || !Enum.IsDefined(piece));

            return piece;
        }

        static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        Console.Write($"{board[i, j]}|");
                    }
                    else
                    {
                        Console.Write($"{board[i, j]} ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("  ________________");
            Console.Write("  ");

            for (int j = 1; j < 9; j++)
            {
                Console.Write($"{board[8, j]} ");
            }

            Console.WriteLine();
        }
    }
}