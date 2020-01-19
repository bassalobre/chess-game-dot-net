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
                var board = new Board.Board(8, 8);
                board.PutPiece(new King(board, Color.Black), new Position(0, 4));
                board.PutPiece(new King(board, Color.White), new Position(7, 4));
                board.PutPiece(new Queen(board, Color.Black), new Position(0, 3));
                board.PutPiece(new Queen(board, Color.White), new Position(7, 3));

                Screnn.PrintBoard(board);
            }
            catch(BoardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
