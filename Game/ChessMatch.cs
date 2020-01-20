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
        private HashSet<Piece> Pieces { get; set; }
        private HashSet<Piece> CatchedPieces { get; set; }
        public bool InCheck { get; private set; }

        public ChessMatch()
        {
            Board = new Board.Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            CatchedPieces = new HashSet<Piece>();
            InCheck = false;
            StartMatch();
        }

        private Piece ExecuteMovement(Position from, Position to)
        {
            var piece = Board.RemovePiece(from);
            piece.AddNumberOfMovements();

            var catchedPiece = Board.RemovePiece(to);
            if(catchedPiece != null)
            {
                CatchedPieces.Add(catchedPiece);
            }

            Board.PutPiece(piece, to);

            return catchedPiece;
        }

        private void UndoMovement(Position from, Position to, Piece catchedPiece)
        {
            var piece = Board.RemovePiece(to);
            piece.ReduceNumberOfMovements();

            if(catchedPiece != null)
            {
                Board.PutPiece(catchedPiece, to);
                CatchedPieces.Remove(catchedPiece);
            }

            Board.PutPiece(piece, from);
        }

        public void PerformMove(Position from, Position to)
        {
            var catchedPiece = ExecuteMovement(from, to);

            if(IsInCheck(CurrentPlayer))
            {
                UndoMovement(from, to, catchedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            InCheck = IsInCheck(Opponent(CurrentPlayer));
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

        private Color Opponent(Color color) => (color == Color.Black) ? Color.White : Color.Black;

        private Piece KingByColor(Color color)
        {
            foreach(Piece piece in PiecesInGameByColor(color))
            {
                if(piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool IsInCheck(Color color)
        {
            var king = KingByColor(color);
            if(king == null)
            {
                throw new BoardException("There is no " + color + " King on board!");
            }

            foreach(Piece piece in PiecesInGameByColor(Opponent(color)))
            {
                var possibleMovements = piece.PossibleMovements();
                if(possibleMovements[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public HashSet<Piece> CatchedPiecesByColor(Color color)
        {
            var pieces = new HashSet<Piece>();

            foreach(Piece piece in CatchedPieces)
            {
                if(piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }

            return pieces;
        }
        
        public HashSet<Piece> PiecesInGameByColor(Color color)
        {
            var pieces = new HashSet<Piece>();

            foreach(Piece piece in Pieces)
            {
                if(piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }

            pieces.ExceptWith(CatchedPiecesByColor(color));
            return pieces;
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

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void StartMatch()
        {
            PutNewPiece('e', 8, new King(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));

            PutNewPiece('e', 1, new King(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
        }
    }
}
