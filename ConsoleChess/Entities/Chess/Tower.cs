class Tower : Piece
{
    public Tower() { }

    public Tower(Color color, Board board) : base(color, board)
    {

    }

    public override string ToString()
    {
        return "T";
    }
}

