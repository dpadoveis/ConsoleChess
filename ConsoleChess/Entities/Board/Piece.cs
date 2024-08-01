using System.Runtime.ConstrainedExecution;

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

    public void IncreaseMoves()
    {
        Moves++;
    }

    public void DecreaseMoves()
    {
        Moves--; 
    }
 
    public bool HavePossibleMovements()
    {
        bool[,] array = PossibleMoves();
        for (int i = 0; i < Board.Rows; i++)
        {
            for (int j = 0; j < Board.Columns; j++)
            {
                if (array[i,j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool PossibleMovement(Position pos) 
    {
        return PossibleMoves()[pos.Row, pos.Column];
    }

    public abstract bool[,] PossibleMoves();

}

