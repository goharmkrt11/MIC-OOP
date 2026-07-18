using System;

namespace homework_1607
{
    class chess
    {
        static void Main()
        {
            CreateMatrix();
        }
        public static void CreateMatrix()
        {
            char[,] board = new char[9, 9];

            FillBoard(board);
            FillLetters(board);
            FillNumbers(board);
            PrintBoard(board);
        }
        static void FillNumbers(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                board[i, 0] = (char)('1' + i);
            }
        }
        static void FillLetters(char[,] board)
        {
            char letter = 'A';

            for (int i = 1; i < 9; i++)
            {
                board[8, i] = letter;
                letter++;
            }
        }
        static void FillBoard(char[,] board)
        {
            for (int i = 0; i <8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        board[i, j] = '#';
                    }
                    else board[i, j] = '*';                    
                }
            }

        }
        static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                        Console.Write($"{board[i, j]}|");
                    else
                        Console.Write($"{board[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("  ________________");

            for (int j = 0; j < 9; j++)
            {
                Console.Write($"{board[8, j]} ");
            }
        }
        static void GetValues()
        {
            Console.WriteLine("Please enter a coordinate!(a1-h8)");

        }

    }

}
