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
                
                    chessBoard.PlacePiece(startPosition, piece);
                
                    PrintBoard(board);

                    Position endPosition = ReadPosition("***Please enter end position***");

            //TODO: stugel qary, u taki exacy petqa tanel petqa ogtagorcel switch case u yst dra kanchel

                    bool isDiagonal = startPosition.IsDiagonalMove(endPosition);

                    if (isDiagonal)
                    {

                        chessBoard.MovePiece(startPosition, endPosition, piece);       
                        PrintBoard(board);
                    }

                    else
                    {
                        Console.WriteLine("We can't do this move!");
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
                Console.Write($"{i + 1}|");

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

        

    }
}
