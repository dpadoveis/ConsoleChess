class Board
{
    public int Lines { get; set; }
    public int Columns { get; set; }
    public Piece[,] Pieces { get; protected set; }

    public Board() { }

    public Board(int lines, int columns)
    {
        Lines = lines;
        Columns = columns;
        Pieces = new Piece[Lines, Columns];
    }
    
    public bool PieceExists (Position pos)
    {
        ValidatePosition(pos);
        return piece(pos) != null;
    }

    public void AddPiece(Piece p, Position pos)
    {
        if (PieceExists(pos)) 
            throw new BoardException("Already exists a piece in this position!");
        Pieces[pos.Line, pos.Column] = p;
        p.Position = pos;
    }

    private bool ValidPosition(Position pos)
    {
        if (pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column>=Columns) return false;
        return true;
    }

    public void ValidatePosition(Position pos)
    {
        if (!ValidPosition(pos)) 
            throw new BoardException("Invalid Position!");
    }


    public Piece piece (Position pos) { return Pieces[pos.Line, pos.Column]; }

}

