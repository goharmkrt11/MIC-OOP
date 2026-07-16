using System;

namespace ConsoleApp3
{
    internal class Program
    {
        enum Direction
        {
            Bottom,
            Top,
            Left,
            Right
        }

        static void Main()
        {
            int size = ReadSize();
            Direction direction = ReadDirection();

            char[,] triangle = CreateTriangle(size);

            PrintTriangle(triangle, direction);
        }

        static int ReadSize()
        {
            int size;

            do
            {
                Console.Write("Enter triangle base size (2-15): ");
            }
            while (!int.TryParse(Console.ReadLine(), out size) || size < 2 || size > 15);
            {
                return size;
            }

        }

        static Direction ReadDirection()
        {
            Direction direction;

            do
            {
                Console.Write("Enter direction (Bottom, Top, Left, Right): ");
            }
            while (!Enum.TryParse(Console.ReadLine(), ignoreCase: true, out direction));
            {
                return direction;
            }
        }

        static char[,] CreateTriangle(int size)
        {
            int height = size;
            int width = 2 * size - 1;

            char[,] triangle = new char[height, width];

            FillWithSpaces(triangle);

            int left = size - 1;
            int right = size - 1;

            for (int row = 0; row < height; row++)
            {
                for (int column = left; column <= right; column += 2)
                {
                    triangle[row, column] = '*';
                }

                left--;
                right++;
            }

            return triangle;
        }

        static void FillWithSpaces(char[,] triangle)
        {
            for (int row = 0; row < triangle.GetLength(0); row++)
            {
                for (int column = 0; column < triangle.GetLength(1); column++)
                {
                    triangle[row, column] = ' ';
                }
            }
        }

        static void PrintTriangle(
            char[,] triangle,
            Direction direction)
        {
            switch (direction)
            {
                case Direction.Bottom:
                    PrintBottom(triangle);
                    break;

                case Direction.Top:
                    PrintTop(triangle);
                    break;

                case Direction.Left:
                    PrintLeft(triangle);
                    break;

                case Direction.Right:
                    PrintRight(triangle);
                    break;
            }
        }

        static void PrintBottom(char[,] triangle)
        {
            for (int row = 0; row < triangle.GetLength(0); row++)
            {
                for (int column = 0; column < triangle.GetLength(1); column++)
                {
                    Console.Write(triangle[row, column]);
                }

                Console.WriteLine();
            }
        }

        static void PrintTop(char[,] triangle)
        {
            for (int row = triangle.GetLength(0) - 1;
                 row >= 0;
                 row--)
            {
                for (int column = 0; column < triangle.GetLength(1); column++)
                {
                    Console.Write(triangle[row, column]);
                }

                Console.WriteLine();
            }
        }

        static void PrintLeft(char[,] triangle)
        {
            for (int column = 0; column < triangle.GetLength(1); column++)
            {
                for (int row = triangle.GetLength(0) - 1;
                     row >= 0;
                     row--)
                {
                    Console.Write(triangle[row, column]);
                }

                Console.WriteLine();
            }
        }

        static void PrintRight(char[,] triangle)
        {
            for (int column = triangle.GetLength(1) - 1; column >= 0; column--)
            {
                for (int row = 0;
                     row < triangle.GetLength(0);
                     row++)
                {
                    Console.Write(triangle[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}