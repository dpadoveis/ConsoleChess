class Board
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public Piece[,] Pieces { get; protected set; }

    public Board() { }

    public Board(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Pieces = new Piece[Rows, Columns];
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
        Pieces[pos.Row, pos.Column] = p;
        p.Position = pos;
    }

    public Piece RemovePiece(Position pos)
    {
        if (!PieceExists(pos))
        {
            return null;
        }
        Piece temp = piece(pos);
        temp.Position = null;
        Pieces[pos.Row,pos.Column] = null;
        return temp;
    }

    private bool ValidPosition(Position pos)
    {
        if (pos.Row<0 || pos.Row>=Rows || pos.Column<0 || pos.Column>=Columns) return false;
        return true;
    }

    public void ValidatePosition(Position pos)
    {
        if (!ValidPosition(pos)) 
            throw new BoardException("Invalid Position!");
    }


    public Piece piece (Position pos) { return Pieces[pos.Row, pos.Column]; }

}

