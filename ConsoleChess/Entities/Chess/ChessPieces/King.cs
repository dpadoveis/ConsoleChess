using System.Runtime.ConstrainedExecution;

class King : Piece
{
    private ChessMatch ChessMatch { get; set; }

    public King(Board Board, Color Color, ChessMatch chessMatch) : base(Board, Color)
    {
        ChessMatch = chessMatch;
    }

    public override string ToString()
    {
        return "K";
    }

    private bool CanMove(Position pos)
    {
        Piece p = Board.piece(pos);
        return p == null || p.Color != Color;
    }

    private bool CastlingRookTest(Position pos)
    {
        Piece p = Board.piece(pos);
        return p != null &&
               p is Rook &&
               p.Color == Color && 
               p.Moves == 0;
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

        // Special moves = Castling
        if (Moves == 0 && !ChessMatch.Check)
        {
            // Short castling
            Position posT1 = new Position(Position.Row, Position.Column + 3);
            if (CastlingRookTest(posT1))
            {
                Position p1 = new Position(Position.Row, Position.Column + 1);
                Position p2 = new Position(Position.Row, Position.Column + 2);
                if (Board.piece(p1) == null && Board.piece(p2) == null)
                {
                    mat[Position.Row, Position.Column + 2] = true;
                }
            }

            // Long castling
            Position posT2 = new Position(Position.Row, Position.Column - 4);
            if (CastlingRookTest(posT2))
            {
                Position p1 = new Position(Position.Row, Position.Column - 1);
                Position p2 = new Position(Position.Row, Position.Column - 2);
                Position p3 = new Position(Position.Row, Position.Column - 3);
                if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                {
                    mat[Position.Row, Position.Column - 2] = true;
                }
            }
        }

            return mat;

    }
}


