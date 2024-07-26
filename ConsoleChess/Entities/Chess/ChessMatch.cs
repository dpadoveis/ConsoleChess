using System.Runtime.ConstrainedExecution;

class ChessMatch
{
    public Board Board { get; private set; }
    private int turno;
    private Color jogadorAtual;
    public bool terminada { get; private set; }

    public ChessMatch()
    {
        Board = new Board(8, 8);
        turno = 1;
        jogadorAtual = Color.White;
        terminada = false;
        InsertPieces();
    }

    public void executaMovimento(Position origin, Position destiny)
    {
        Piece p = Board.retirarPeca(origin);
        p.incrementarQteMovimentos();
        Piece pecaCapturada = Board.retirarPeca(destiny);
        Board.InsertPiece(p, destiny);
    }

    private void InsertPieces()
    {
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).toPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).toPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).toPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).toPosition());
        Board.InsertPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).toPosition());
        Board.InsertPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());

        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).toPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).toPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).toPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).toPosition());
        Board.InsertPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).toPosition());
        Board.InsertPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());

    }
}
