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
                    Console.Clear();
                    Screnn.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("From: ");
                    var from = Screnn.GetChessPosition().ToPosition();
                    Console.Write("To: ");
                    var to = Screnn.GetChessPosition().ToPosition();

                    match.ExecuteMovement(from, to);
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
