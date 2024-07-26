﻿try
{
    ChessMatch chessmatch = new ChessMatch();

    while (!chessmatch.Finished)
    {
        try {
            Console.Clear();
            Window.PrintBoard(chessmatch.Board);
            Console.WriteLine();
            Console.WriteLine("Turn n° " + chessmatch.Turn);
            Console.WriteLine($"{chessmatch.CurrentPlayer}'s turn to move");

            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = Window.ReadChessPosition().ToPosition();
            chessmatch.ValidateOriginPosition(origin);

            bool[,] possiblePositions = chessmatch.Board.piece(origin).PossibleMoves();

            Console.Clear();
            Window.PrintBoard(chessmatch.Board, possiblePositions);

            Console.WriteLine();
            Console.Write("Destiny: ");
            Position destiny = Window.ReadChessPosition().ToPosition();
            chessmatch.ValidateDestinyPosition(origin, destiny);

            chessmatch.MakeMove(origin, destiny);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
        }
    

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();