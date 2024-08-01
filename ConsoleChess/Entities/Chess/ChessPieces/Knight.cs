class Knight : Piece
{
    public Knight(Board board, Color color) : base(board, color) { }

    public override string ToString()
    {
        return "N"; 
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
        int[,] moves = new int[,]
        {
            {-2, -1},
            {-1, -2},
            {1, -2},
            {2, -1},
            {2, 1},
            {1, 2},
            {-1, 2},
            {-2, 1}
        };

        for (int i = 0; i < moves.GetLength(0); i++)
        {
            pos.DefineValue(Position.Row + moves[i, 0], Position.Column + moves[i, 1]);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
        }

        return mat;
    }
}
