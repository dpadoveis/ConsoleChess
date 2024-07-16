try
{
    Board board = new Board(8, 8);

    board.AddPiece(new Tower(Color.Black, board), new Position(0, 0));
    board.AddPiece(new Tower(Color.Black, board), new Position(1, 3));
    board.AddPiece(new King(Color.Black, board), new Position(0, 2));

    board.AddPiece(new Tower(Color.White, board), new Position(3, 5));

    Window.PrintBoard(board);

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
Console.ReadLine();
