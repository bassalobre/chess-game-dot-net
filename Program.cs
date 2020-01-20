using ChessGame.Board;
using ChessGame.Game;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var match = new ChessMatch();

                while(!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screnn.PrintBoard(match.Board);
                        Console.WriteLine();
                        Console.WriteLine("Round: " + match.Round);
                        Console.WriteLine("Waiting move: " + match.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write("From: ");
                        var from = Screnn.GetChessPosition().ToPosition();
                        match.ValidateFromPosition(from);

                        var possiblePositions = match
                            .Board
                            .Piece(from)
                            .PossibleMovements();
                        Console.Clear();
                        Screnn.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("To: ");
                        var to = Screnn.GetChessPosition().ToPosition();
                        match.ValidateToPosition(from, to);

                        match.PerformMove(from, to);
                    }
                    catch(BoardException exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(BoardException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
