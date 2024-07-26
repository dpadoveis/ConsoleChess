using System.Runtime.ConstrainedExecution;

class ChessMatch
{
    public Board Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; private set; }

    public ChessMatch()
    {
        Board = new Board(8, 8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        InsertPieces();
    }

    public void executaMovimento(Position origin, Position destiny)
    {
        Piece p = Board.retirarPeca(origin);
        p.incrementarQteMovimentos();
        Piece pecaCapturada = Board.retirarPeca(destiny);
        Board.InsertPiece(p, destiny);
    }

    public void MakeMove(Position origin, Position destiny) 
    {
        executaMovimento(origin,destiny);
        Turn++;
        ChangePlayer();
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
        if (!Board.piece(origin).CanMoveTo(destiny))
        {
            throw new BoardException("Invalid destiny position!");
        }
    }



    private void ChangePlayer()
    {
        CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
    }
    private void InsertPieces()
    {
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
        Board.InsertPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
        Board.InsertPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());

    }
}
