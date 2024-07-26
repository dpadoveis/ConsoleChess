﻿using System.Runtime.ConstrainedExecution;

abstract class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int Moves { get; protected set; }
    public Board Board { get; protected set; }

    public Piece(Board board, Color color)
    {
        Position = null;
        Board = board;
        Color = color;
        Moves = 0;
    }

    public void incrementarQteMovimentos()
    {
        Moves++;
    }

    public abstract bool[,] movimentosPossiveis();

}

