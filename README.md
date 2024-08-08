# Console Chess
A simple chess game implemented in C# for the console.

# Features
- All chess pieces with basic movements
- Special moves including castling, en passant, and promotion
- Legal move resolution to avoid putting oneself in check
- Detection of check and checkmate

# Handling Special Moves
- Castling:
Castling is handled automatically if the move involves the king and rook.

- En Passant:
Automatically executed if a pawn moves two squares forward and lands beside an opponent's pawn.

- Promotion:
If a pawn reaches the last rank, it is automatically promoted to a queen (or other piece if desired).

# Checking Game Status
- Check:
The game status will indicate if the current player is in check.

- Checkmate:
The game will declare a checkmate if the opponent cannot move out of check.

# Example Game Loop
```sh
while (!chessmatch.Finished)
{
    Console.Clear();
    Window.PrintMatch(chessmatch);

    Console.Write("Origin: ");
    Position origin = Window.ReadChessPosition().ToPosition();
    chessmatch.ValidateOriginPosition(origin);

    bool[,] possiblePositions = chessmatch.Board.piece(origin).PossibleMoves();

    Console.Clear();
    Window.PrintBoard(chessmatch.Board, possiblePositions);

    Console.Write("Destiny: ");
    Position destiny = Window.ReadChessPosition().ToPosition();
    chessmatch.ValidateDestinyPosition(origin, destiny);

    chessmatch.MakeMove(origin, destiny);
}
```
# Handling Exceptions
Catch BoardException to handle invalid moves and other game-related errors:

```sh
catch (BoardException e)
{
    Console.WriteLine(e.Message);
```
