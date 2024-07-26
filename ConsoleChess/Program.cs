try
{
    ChessMatch chessmatch = new ChessMatch();

    while (!chessmatch.terminada)
    {

        Console.Clear();
        Window.PrintBoard(chessmatch.Board);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position origem = Window.lerChessPosition().toPosition();

        bool[,] posicoesPossiveis = chessmatch.Board.piece(origem).movimentosPossiveis();

        Console.Clear();
        Window.PrintBoard(chessmatch.Board, posicoesPossiveis);

        Console.WriteLine();
        Console.Write("Destino: ");
        Position destino = Window.lerChessPosition().toPosition();

        chessmatch.executaMovimento(origem, destino);
    }

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();