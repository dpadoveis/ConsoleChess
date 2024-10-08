﻿class Pawn : Piece
{
    private ChessMatch ChessMatch { get; set; }
    public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color)
    {
        ChessMatch = chessMatch;
    }

    public override string ToString()
    {
        return "P";
    }

    private bool IsThereOpponent(Position pos)
    {
        Piece p = Board.piece(pos);
        return p != null && p.Color != Color;
    }

    private bool IsEmpty(Position pos)
    {
        return Board.piece(pos) == null;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[Board.Rows, Board.Columns];

        Position pos = new Position(0, 0);

        if (Color == Color.White)
        {

            pos.DefineValue(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && IsEmpty(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValue(Position.Row - 2, Position.Column);
            Position pos2 = new Position(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && IsEmpty(pos) && Board.ValidPosition(pos2) && IsEmpty(pos2) && Moves == 0)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValue(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && IsThereOpponent(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValue(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && IsThereOpponent(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Special moves: En Passant
            if (Position.Row == 3)
            {
                Position left = new Position(Position.Row, Position.Column - 1);
                if (Board.ValidPosition(left) && IsThereOpponent(left) && Board.piece(left) == ChessMatch.EnPassantVulnerable)
                {
                    mat[Position.Row - 1, Position.Column - 1] = true;
                }
                Position right = new Position(Position.Row, Position.Column + 1);
                if (Board.ValidPosition(right) && IsThereOpponent(right) && Board.piece(right) == ChessMatch.EnPassantVulnerable)
                {
                    mat[Position.Row - 1, Position.Column + 1] = true;
                }
            }
        }
        else
        {

            pos.DefineValue(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && IsEmpty(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValue(Position.Row + 2, Position.Column);
            Position pos2 = new Position(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && IsEmpty(pos) && Board.ValidPosition(pos2) && IsEmpty(pos2) && Moves == 0)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValue(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && IsThereOpponent(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValue(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && IsThereOpponent(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Special moves: En Passant
            if (Position.Row == 4)
            {
                Position left = new Position(Position.Row, Position.Column - 1);
                if (Board.ValidPosition(left) && IsThereOpponent(left) && Board.piece(left) == ChessMatch.EnPassantVulnerable)
                {
                    mat[Position.Row + 1, Position.Column - 1] = true;
                }
                Position right = new Position(Position.Row, Position.Column + 1);
                if (Board.ValidPosition(right) && IsThereOpponent(right) && Board.piece(right) == ChessMatch.EnPassantVulnerable)
                {
                    mat[Position.Row + 1, Position.Column + 1] = true;
                }
            }
        }

        return mat;
    }
}
