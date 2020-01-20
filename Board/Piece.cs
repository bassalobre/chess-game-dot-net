using System;

namespace ChessGame.Board
{
    abstract class Piece
    {
        public Board Board { get; protected set; }
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMovements { get; protected set; }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
            Position = null;
            NumberOfMovements = 0;
        }

        public void AddNumberOfMovements() => NumberOfMovements ++;

        public void ReduceNumberOfMovements() => NumberOfMovements --;

        protected bool CanMove(Position position)
        {
            var piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }

        public bool ThereArePossibleMovements()
        {
            var matrix = PossibleMovements();

            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if(matrix[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveToPosition(Position position) => PossibleMovements()[position.Row, position.Column];

        public abstract bool[,] PossibleMovements();
    }
}
