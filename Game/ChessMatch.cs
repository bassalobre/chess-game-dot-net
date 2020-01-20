using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Game
{
    class ChessMatch
    {
        public Board.Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board.Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            StartMatch();
        }

        private void ExecuteMovement(Position from, Position to)
        {
            var piece = Board.RemovePiece(from);
            piece.AddNumberOfMovements();

            var catchedPiece = Board.RemovePiece(to);

            Board.PutPiece(piece, to);
        }

        public void PerformMove(Position from, Position to)
        {
            ExecuteMovement(from, to);
            Round ++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            var newPlayer = Color.White;

            if (CurrentPlayer == Color.White)
            {
                newPlayer = Color.Black;
            }

            CurrentPlayer = newPlayer;
        }

        public void ValidateFromPosition(Position position)
        {
            if(Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in from position chosen!");
            }

            if(CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The chosen from piece is not your!");
            }

            if(!Board.Piece(position).ThereArePossibleMovements())
            {
                throw new BoardException("There are no possible movements to chosen from piece!");
            }
        }

        public void ValidateToPosition(Position from, Position to)
        {
            if (!Board.Piece(from).CanMoveToPosition(to))
            {
                throw new BoardException("Invalid to position!");
            }
        }

        private void StartMatch()
        {
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());

            Board.PutPiece(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('f', 1).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('f', 2).ToPosition());
        }
    }
}
