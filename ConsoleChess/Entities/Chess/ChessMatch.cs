class ChessMatch
{
    public Board Board { get; private set; }
    private int Turn { get; set; }
    public Color CurrentPlayer { get; set; }
    public bool Finished { get; private set; }

    public ChessMatch()
    {
        Board = new Board(8, 8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        InsertPieces();
    }

    public void MakeMove(Position origin, Position destination)
    {
        Piece p = Board.RemovePiece(origin);
        p.AddMoves();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.AddPiece(p, destination);
    }

    private void InsertPieces()
    {
        Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('c', 1)
            .ToPosition());
        Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('c', 2)
            .ToPosition());
        Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('d', 2)
            .ToPosition());
        Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('e', 2)
            .ToPosition());
        Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('e', 1)
            .ToPosition());
        Board.AddPiece(new King(Color.White, Board), new ChessPosition('d', 1)
            .ToPosition());

        Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('c', 7)
            .ToPosition());
        Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('c', 8)
            .ToPosition());
        Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('d', 7)
            .ToPosition());
        Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('e', 7)
            .ToPosition());
        Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('e', 8)
            .ToPosition());
        Board.AddPiece(new King(Color.Black, Board), new ChessPosition('d', 8)
            .ToPosition());

    }



}
