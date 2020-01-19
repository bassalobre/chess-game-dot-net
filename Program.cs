using ChessGame.Board;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board.Board(8, 8);

            Screnn.PrintBoard(board);
        }
    }
}
