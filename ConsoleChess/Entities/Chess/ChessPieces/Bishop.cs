class Bishop : Piece
{
    public Bishop(Board board, Color color) : base(board, color)
    {

    }
    public override string ToString()
    {
        return "B";
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
        int[,] directions = new int[,]
        {
        {-1, 1},  
        {1, 1},   
        {1, -1},  
        {-1, -1}  
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            pos.DefineValue(Position.Row, Position.Column);
            int rowDirection = directions[i, 0];
            int colDirection = directions[i, 1];

            
            pos.DefineValue(pos.Row + rowDirection, pos.Column + colDirection);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValue(pos.Row + rowDirection, pos.Column + colDirection);
            }
        }

        return mat;
    }

}

