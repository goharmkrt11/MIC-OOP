using ClassLib;

namespace ChessConsole
{
    internal class Program
    {
        
        static void Main()
        {
                    Board chessBoard = new Board();
                    char[,] board = chessBoard.GetBoard();                
                    PrintBoard(board);
                
                    Position startPosition = ReadPosition("***Please enter start position***");
                    Piece piece = ReadChessPiece();
                    if (piece == Piece.R || piece == Piece.N || piece == Piece.K)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valid moves for this piece have not been implemented yet!!!");
                        Console.ResetColor();

                        return;
                        
                    }

                    chessBoard.PlacePiece(startPosition, piece);                
                    PrintBoard(board);

                    Position endPosition = ReadPosition("***Please enter end position***");

                    switch (piece)
                    {
                        /*case Piece.R:
                        case Piece.N:
                        case Piece.K:*/

                        case Piece.B:
                            TryMoveBishop( startPosition, endPosition, piece, chessBoard);
                            break;
                        case Piece.Q:
                            TryMoveQueen( startPosition, endPosition, piece, chessBoard);
                            break;
                    }


                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
        }

        static Position ReadPosition(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();

            int row;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Please enter a row (1-8):");
                Console.ResetColor();
            }
            while (!int.TryParse(Console.ReadLine(), out row)
                   || row < 1
                   || row > 8);

            char column;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Please enter a column (A-H):");
                Console.ResetColor();
            }
            while (!char.TryParse((Console.ReadLine() ?? "").ToUpper(), out column)                    
                       
                   || column < 'A'
                   || column > 'H');

            return new Position(row, column);
        }

        static Piece ReadChessPiece()
        {
            Piece piece;

            do
            {
                Console.WriteLine(
                    "Please enter a chess piece (R, N, B, Q, K):");
            }
            while (!Enum.TryParse((Console.ReadLine() ?? "").ToUpper(), out piece) || !Enum.IsDefined(piece));
            
            return piece;
        }

        static void PrintBoard(char[,] board)
        {

            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{8-i}|");

                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write($"{board[i, j]} ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            Console.WriteLine("  ________________");
            Console.Write("  ");

            for (char column = 'A'; column <= 'H'; column++)
            {
                Console.Write($"{column} ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
       
        static void TryMoveBishop(Position startPosition, Position endPosition, Piece piece,Board chessBoard)
        {
            if (startPosition.Column != endPosition.Column || startPosition.Row!=endPosition.Row)
            {
                bool isDiagonal = startPosition.IsDiagonalMove(endPosition);

                if (isDiagonal)
                {
                    chessBoard.MovePiece(startPosition, endPosition, piece);
                    PrintBoard(chessBoard.GetBoard());
                }

                else
                {
                    Console.WriteLine("We can't do this move!");
                }
            }
            else Console.WriteLine("The start position and end position cannot be the same!");
        }

        static void TryMoveQueen(Position startPosition, Position endPosition, Piece piece, Board chessBoard)
        {
            if (startPosition.Column != endPosition.Column || startPosition.Row != endPosition.Row)
            {
                bool isDiagonal = startPosition.IsDiagonalMove(endPosition);
                bool isStraight= startPosition.IsStraightMove(endPosition);

                if (isDiagonal || isStraight)
                {
                    chessBoard.MovePiece(startPosition, endPosition, piece);
                    PrintBoard(chessBoard.GetBoard());
                }

                else
                {
                    Console.WriteLine("We can't do this move!");
                }
            }
            else Console.WriteLine("The start position and end position cannot be the same!");
        }

    }
}
