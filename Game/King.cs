using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Game
{
    class King : Piece
    {
        public King(Board.Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
