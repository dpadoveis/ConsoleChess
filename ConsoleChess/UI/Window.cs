﻿using System;
using System.Collections.Generic;

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
        Console.Write("White: ");
        PrintSet(chessmatch.CapturedPieces(Color.White));
        Console.Write("Black: ");
        PrintSet(chessmatch.CapturedPieces(Color.Black));
    }

    public static void PrintSet(HashSet<Piece> set)
    {
        Console.Write("[");
        foreach (Piece p in set)
        {
            Console.Write(p + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }

    public static void PrintBoard(Board board)
    {
        ConsoleColor[] colors = { ConsoleColor.Gray, ConsoleColor.DarkGreen };

        for (int i = 0; i < board.Rows; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < board.Columns; j++)
            {
                Console.BackgroundColor = colors[(i + j) % 2];
                PrintPiece(board.piece(i, j));
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public static void PrintBoard(Board board, bool[,] possiblePositions)
    {
        ConsoleColor bgOriginal = Console.BackgroundColor;
        ConsoleColor bgAltered = ConsoleColor.DarkYellow;

        for (int i = 0; i < board.Rows; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < board.Columns; j++)
            {
                if (possiblePositions[i, j])
                {
                    Console.BackgroundColor = bgAltered;
                }
                else
                {
                    Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.DarkGreen;
                }
                PrintPiece(board.piece(i, j));
                Console.BackgroundColor = bgOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = bgOriginal;
    }

    public static ChessPosition ReadChessPosition()
    {
        string s = Console.ReadLine();
        if (s.Length != 2 || !char.IsLetter(s[0]) || !char.IsDigit(s[1]))
        {
            throw new BoardException("Wrong format! Write the letter+number (Ex: d4)");
        }
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");
        return new ChessPosition(coluna, linha);
    }

    public static void PrintPiece(Piece piece)
    {
        if (piece == null)
        {
            Console.Write("  ");
        }
        else
        {
            ConsoleColor originalForeground = Console.ForegroundColor;

            if (piece.Color == Color.White)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(piece + " ");
            Console.ForegroundColor = originalForeground;
        }
    }
}
