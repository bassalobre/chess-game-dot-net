using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Game
{
    class ChessMatch
    {
        public Board.Board Board { get; private set; }
        private int Round { get; set; }
        private Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board.Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            StartMatch();
        }

        public void ExecuteMovement(Position from, Position to)
        {
            var piece = Board.RemovePiece(from);
            piece.AddNumberOfMovements();

            var catchedPiece = Board.RemovePiece(to);

            Board.PutPiece(piece, to);
        }

        private void StartMatch()
        {
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('d', 1).ToPosition());
        }
    }
}
