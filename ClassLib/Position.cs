namespace ClassLib
{
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
}
