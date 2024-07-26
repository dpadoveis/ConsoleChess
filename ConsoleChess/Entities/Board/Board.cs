class Board
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    private Piece[,] pieces;

    public Board(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        pieces = new Piece[Rows, Columns];
    }

    public Piece piece(int linha, int coluna)
    {
        return pieces[linha, coluna];
    }

    public Piece piece(Position pos)
    {
        return pieces[pos.Row, pos.Column];
    }

    public bool InsertPiece(Position pos)
    {
        ValidatePosition(pos);
        return piece(pos) != null;
    }

    public void InsertPiece(Piece p, Position pos)
    {
        if (InsertPiece(pos))
        {
            throw new BoardException("Já existe uma peça nessa posição!");
        }
        pieces[pos.Row, pos.Column] = p;
        p.Position = pos;
    }

    public Piece retirarPeca(Position pos)
    {
        if (piece(pos) == null)
        {
            return null;
        }
        Piece aux = piece(pos);
        aux.Position = null;
        pieces[pos.Row, pos.Column] = null;
        return aux;
    }

    public bool ValidPosition(Position pos)
    {
        if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
        {
            return false;
        }
        return true;
    }

    public void ValidatePosition(Position pos)
    {
        if (!ValidPosition(pos))
        {
            throw new BoardException("Posição inválida!");
        }
    }
}

