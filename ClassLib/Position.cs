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
        public bool IsDiagonalMove( Position endPosition)
        {
            if (Math.Abs(this.Row - endPosition.Row) == Math.Abs(this.Column - endPosition.Column))
            {
                return true;
            }
            return false;

        }
    }
     
    
    
}
