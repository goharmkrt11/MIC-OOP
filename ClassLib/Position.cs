namespace ClassLib
{
    public readonly struct Position
    {

        public int Row { get; }
        public char Column { get; }        


        public Position(int row, char column)
        {
           if (row < 1 || row > 8)
           {
             throw new ArgumentOutOfRangeException(nameof(row));
           }

            if (column < 'A' || column > 'H')
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            Row = row;
            Column = column;
        }

        public bool IsDiagonalMove(Position endPosition)
        {
            if (Math.Abs(this.Row - endPosition.Row) == Math.Abs(this.Column - endPosition.Column))
            {
                return true;
            }
            return false;

        }

        public bool IsStraightMove(Position endPosition)
        {
            if (this.Column == endPosition.Column || this.Row == endPosition.Row)
            {
                return true;
            }
            return false;
        }
    }
     
    
    
}
