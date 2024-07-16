class Window
{
    public static void PrintBoard(Board b)
    {
        ConsoleColor originalBackgroundColor = Console.BackgroundColor;
        ConsoleColor originalForegroundColor = Console.ForegroundColor;

        for (int i = 0; i < b.Lines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < b.Lines; j++)
            {               
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }

                if (b.Pieces[i, j] == null)
                {
                    Console.Write("- ");
                }
                else
                {                  
                    if ((i + j) % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    PrintPiece(b.Pieces[i, j]);
                    Console.Write(" ");
                }

                
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        Console.WriteLine("  a b c d e f g h");

        Console.BackgroundColor = originalBackgroundColor;
        Console.ForegroundColor = originalForegroundColor;
    }

    public static void PrintPiece(Piece piece)
    {
        if (piece.Color == Color.Black)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(piece);
            Console.ForegroundColor = aux;
        }
        else
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(piece);
            Console.ForegroundColor = aux;
        }

    }
}

