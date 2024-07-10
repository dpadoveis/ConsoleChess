try
{
    ChessPosition position = new ChessPosition('c',7);
    Console.WriteLine(position);
    Console.WriteLine(position.ToPosition());

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}