using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Board
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}
