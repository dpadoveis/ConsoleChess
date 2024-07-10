Board board = new Board(8, 8);
board.AddPiece(new Tower(Color.Black,board), new Position(0, 0));
board.AddPiece(new Tower(Color.Black, board), new Position(1, 3));
board.AddPiece(new King(Color.Black, board), new Position(2, 4));
Window.PrintBoard(board);
Console.WriteLine();