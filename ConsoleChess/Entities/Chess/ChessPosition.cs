class ChessPosition
{
    public char Column { get; set; }
    public int Row { get; set; }

    public ChessPosition(char Column, int Row)
    {
        this.Column = Column;
        this.Row = Row;
    }

    public Position ToPosition()
    {
        return new Position(8 - Row, Column - 'a');
    }

    public override string ToString()
    {
        return "" + Column + Row;
    }
}

