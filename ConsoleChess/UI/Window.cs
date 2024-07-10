class Window
{
    public static void PrintBoard(Board b)
    {
        for (int i = 0; i < b.Lines; i++)
        {
            for (int j = 0; j < b.Lines; j++)
            {
                if (b.Pieces[i, j] == null)
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.Write(b.Pieces[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

