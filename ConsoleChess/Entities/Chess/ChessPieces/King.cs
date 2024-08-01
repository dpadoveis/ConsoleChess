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
        int[,] directions = new int[,]
        {
        {-1, 0},  
        {-1, 1},  
        {0, 1},   
        {1, 1},  
        {1, 0},   
        {1, -1},  
        {0, -1},  
        {-1, -1}  
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            pos.DefineValue(Position.Row + directions[i, 0], Position.Column + directions[i, 1]);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
        }

        return mat;

    }
}


