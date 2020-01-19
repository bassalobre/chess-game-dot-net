using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Game
{
    class Queen : Piece
    {
        public Queen(Board.Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
