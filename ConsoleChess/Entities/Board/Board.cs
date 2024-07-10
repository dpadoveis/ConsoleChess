﻿class Board
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

    public void AddPiece(Piece p, Position pos)
    {
        Pieces[pos.Line, pos.Column] = p;
        p.Position = pos;
    }
}

