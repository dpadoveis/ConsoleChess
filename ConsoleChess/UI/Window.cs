using System.Runtime.ConstrainedExecution;

class Window
{

    public static void PrintMatch(ChessMatch chessmatch)
    {
        PrintBoard(chessmatch.Board);
        Console.WriteLine();
        PrintCapturedPieces(chessmatch);
        Console.WriteLine();
        Console.WriteLine("Turn n° " + chessmatch.Turn);
        if (!chessmatch.Finished)
        {
            Console.WriteLine($"{chessmatch.CurrentPlayer}'s turn to move");
            if (chessmatch.Check)
            {
                Console.WriteLine("You are in check!");
            }
        }
        else
        {
            Console.WriteLine("CHECKMATE!");
            Console.WriteLine("Winner: " + chessmatch.CurrentPlayer);
        }
    }

    public static void PrintCapturedPieces(ChessMatch chessmatch)
    {
        Console.WriteLine("Captured Pieces:");
        Console.Write("White:");
        PrintSet(chessmatch.CapturedPieces(Color.White));
        Console.Write("Black:");
        PrintSet(chessmatch.CapturedPieces(Color.Black));
    }

    public static void PrintSet(HashSet<Piece> set)
    {
        Console.Write("[");
        foreach( Piece p in set)
        {
            Console.Write(p + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }

    public static void PrintBoard(Board Board)
    {

        for (int i = 0; i < Board.Rows; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < Board.Columns; j++)
            {
                PrintPiece(Board.piece(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void PrintBoard(Board Board, bool[,] posicoePossiveis)
    {

        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < Board.Rows; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < Board.Columns; j++)
            {
                if (posicoePossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = fundoOriginal;
                }
                PrintPiece(Board.piece(i, j));
                Console.BackgroundColor = fundoOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = fundoOriginal;
    }

    public static ChessPosition ReadChessPosition()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");
        return new ChessPosition(coluna, linha);
    }

    public static void PrintPiece(Piece peca)
    {

        if (peca == null)
        {
            Console.Write("- ");
        }
        else
        {
            if (peca.Color == Color.White)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }
    }

}