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
        
        public Piece Piece (Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public bool ThereIsAPiece(Position position)
        {
            ValidatePosition(position);

            return Piece(position) != null;
        }

        public void PutPiece(Piece piece, Position position)
        {
            if(ThereIsAPiece(position))
            {
                throw new BoardException("There is already a piece in this position !");
            }

            piece.Position = position;
            Pieces[position.Row, position.Column] = piece;            
        }

        public bool IsValidPosition(Position position)
        {
            return
                position.Row >= 0 &&
                position.Row < Rows &&
                position.Column >= 0 &&
                position.Column < Columns;
        }

        public void ValidatePosition(Position position)
        {
            if(!IsValidPosition(position))
            {
                throw new BoardException("Invalid Position !");
            }
        }
    }
}
