using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;

class ChessMatch
{
    public Board Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; private set; }
    private HashSet<Piece> Pieces { get; set; }
    private HashSet<Piece> Captured { get; set; }
    public bool Check { get; set; }

    public ChessMatch()
    {
        Board = new Board(8, 8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        Check = false;
        Pieces = new HashSet<Piece>();
        Captured = new HashSet<Piece>();
        InsertPieces();
    }

    public Piece ExecuteMove(Position origin, Position destiny)
    {
        Piece p = Board.RemovePiece(origin);
        p.IncreaseMoves();
        Piece CapturedPiece = Board.RemovePiece(destiny);
        Board.InsertPiece(p, destiny);
        if (CapturedPiece != null)
        {
            Captured.Add(CapturedPiece);
        }
        return CapturedPiece;
    }

    public void UnMakeMove(Position origin, Position destiny, Piece capturedPiece)
    {
        Piece p = Board.RemovePiece(destiny);
        p.DecreaseMoves();
        if (capturedPiece != null)
        {
            Board.InsertPiece(capturedPiece, destiny);
            Captured.Remove(capturedPiece);
        }
        Board.InsertPiece(p, origin);
    }

    public void MakeMove(Position origin, Position destiny)
    {
        Piece capturedPiece = ExecuteMove(origin, destiny);
        if (IsInCheck(CurrentPlayer))
        {
            UnMakeMove(origin, destiny, capturedPiece);
            throw new BoardException("Can't put yourself in check!");
        }
        if (IsInCheck(Opponent(CurrentPlayer)))
        {
            Check = true;
        }
        else
        {
            Check = false;
        }
        if (TestCheckMate(Opponent(CurrentPlayer)))
        {
            Finished = true;
        }
        else
        {
            Turn++;
            ChangePlayer();
        }
    }

    public void ValidateOriginPosition(Position pos)
    {
        if (Board.piece(pos) == null)
        {
            throw new BoardException("The origin don't have an piece! ");
        }
        if (CurrentPlayer != Board.piece(pos).Color)
        {
            throw new BoardException("The origin you choose is not yours!");
        }
        if (!Board.piece(pos).HavePossibleMovements())
        {
            throw new BoardException("There is not possible moves for the origin");
        }
    }

    public void ValidateDestinyPosition(Position origin, Position destiny)
    {
        if (!Board.piece(origin).PossibleMovement(destiny))
        {
            throw new BoardException("Invalid destiny position!");
        }
    }



    private void ChangePlayer()
    {
        CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
    }

    public HashSet<Piece> CapturedPieces(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece p in Captured)
        {
            if (p.Color == color)
            {
                aux.Add(p);
            }
        }
        return aux;
    }

    public HashSet<Piece> InGamePieces(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece p in Pieces)
        {
            if (p.Color == color)
            {
                aux.Add(p);
            }
        }
        aux.ExceptWith(CapturedPieces(color));
        return aux;
    }

    private Color Opponent(Color color)
    {
        return color == Color.White ? Color.Black : Color.White;
    }

    private Piece King(Color color)
    {
        foreach (Piece p in InGamePieces(color))
        {
            if (p is King)
            {
                return p;
            }
        }
        return null;
    }

    public bool IsInCheck(Color color)
    {
        Piece k = King(color);
        if (k == null)
        {
            throw new BoardException("There is not a " + color + " king in the board!");
        }
        foreach (Piece p in InGamePieces(Opponent(color)))
        {
            bool[,] array = p.PossibleMoves();
            if (array[k.Position.Row, k.Position.Column])
            {
                return true;
            }
        }
        return false;
    }

    public bool TestCheckMate(Color color)
    {
        if (!IsInCheck(color)) return false;

        foreach (Piece p in InGamePieces(color))
        {
            bool[,] array = p.PossibleMoves();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (array[i, j])
                    {
                        Position origin = p.Position;
                        Position destiny = new Position(i, j);
                        Piece capturedPiece = ExecuteMove(origin, destiny);
                        bool stillInCheck = IsInCheck(color);
                        UnMakeMove(origin, destiny, capturedPiece);
                        if (!stillInCheck)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }


    public void InsertNewPiece(char column, int row, Piece piece)
    {
        Board.InsertPiece(piece, new ChessPosition(column, row).ToPosition());
        Pieces.Add(piece);
    }
    private void InsertPieces()
    {
        
        InsertNewPiece('a', 1, new Rook(Board, Color.White));    
        InsertNewPiece('b', 1, new Knight(Board, Color.White));  
        InsertNewPiece('c', 1, new Bishop(Board, Color.White));  
        InsertNewPiece('d', 1, new Queen(Board, Color.White));   
        InsertNewPiece('e', 1, new King(Board, Color.White));    
        InsertNewPiece('f', 1, new Bishop(Board, Color.White));  
        InsertNewPiece('g', 1, new Knight(Board, Color.White));  
        InsertNewPiece('h', 1, new Rook(Board, Color.White));    

        
        for (char file = 'a'; file <= 'h'; file++)
        {
            InsertNewPiece(file, 2, new Pawn(Board, Color.White));  
        }

        
        InsertNewPiece('a', 8, new Rook(Board, Color.Black));    
        InsertNewPiece('b', 8, new Knight(Board, Color.Black));  
        InsertNewPiece('c', 8, new Bishop(Board, Color.Black));  
        InsertNewPiece('d', 8, new Queen(Board, Color.Black));   
        InsertNewPiece('e', 8, new King(Board, Color.Black));    
        InsertNewPiece('f', 8, new Bishop(Board, Color.Black));  
        InsertNewPiece('g', 8, new Knight(Board, Color.Black));  
        InsertNewPiece('h', 8, new Rook(Board, Color.Black));    

        
        for (char file = 'a'; file <= 'h'; file++)
        {
            InsertNewPiece(file, 7, new Pawn(Board, Color.Black));
        }
    }

}
