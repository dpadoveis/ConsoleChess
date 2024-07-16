try
{
    ChessMatch chessMatch = new ChessMatch();

    while (!chessMatch.Finished)
    {
        Console.Clear();
        Window.PrintBoard(chessMatch.Board);

        Console.WriteLine();
        Console.Write("Origin:");
        Position origin = Window.ReadChessPosition()
            .ToPosition();
        Console.Write("Destination:");
        Position destination = Window.ReadChessPosition()
            .ToPosition();
        chessMatch.MakeMove(origin, destination);
    }


}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
Console.ReadLine();
