using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece Piece (int row, int column)
        {
            return Pieces[row, column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            piece.Position = position;
            Pieces[position.Row, position.Column] = piece;            
        }
    }
}
