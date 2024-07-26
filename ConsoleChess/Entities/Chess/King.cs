using System.Runtime.ConstrainedExecution;

class King : Piece
{

    public King(Board Board, Color Color) : base(Board, Color)
    {
    }

    public override string ToString()
    {
        return "R";
    }

    private bool CanMove(Position pos)
    {
        Piece p = Board.piece(pos);
        return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[Board.Rows, Board.Columns];

        Position pos = new Position(0, 0);

        // acima
        pos.DefineValue(Position.Row - 1, Position.Column);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // ne
        pos.DefineValue(Position.Row - 1, Position.Column + 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // diKingta
        pos.DefineValue(Position.Row, Position.Column + 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // se
        pos.DefineValue(Position.Row + 1, Position.Column + 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // abaixo
        pos.DefineValue(Position.Row + 1, Position.Column);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // so
        pos.DefineValue(Position.Row + 1, Position.Column - 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // esquerda
        pos.DefineValue(Position.Row, Position.Column - 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        // no
        pos.DefineValue(Position.Row - 1, Position.Column - 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Row, pos.Column] = true;
        }
        return mat;
    }
}


