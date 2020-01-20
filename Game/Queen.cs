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

        public override bool[,] PossibleMovements()
        {
            var matrix = new bool[Board.Rows, Board.Columns];
            var position = new Position(0, 0);

            matrix = MovementToUp(matrix, position);
            matrix = MovementToUpRightDiagonal(matrix, position);
            matrix = MovementToRight(matrix, position);
            matrix = MovementToDownRightDiagonal(matrix, position);
            matrix = MovementToDown(matrix, position);
            matrix = MovementToDownLeftDiagonal(matrix, position);
            matrix = MovementToLeft(matrix, position);
            matrix = MovementToUpLeftDiagonal(matrix, position);

            return matrix;
        }

        private bool[,] MovementToUp(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row - 1, Position.Column);
            matrix = MovementMatrix(matrix, position, -1, 0);

            return matrix;
        }

        private bool[,] MovementToUpRightDiagonal(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row - 1, Position.Column + 1);
            matrix = MovementMatrix(matrix, position, -1, 1);

            return matrix;
        }

        private bool[,] MovementToRight(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row, Position.Column + 1);
            matrix = MovementMatrix(matrix, position, 0, 1);

            return matrix;
        }

        private bool[,] MovementToDownRightDiagonal(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row + 1, Position.Column + 1);
            matrix = MovementMatrix(matrix, position, 1, 1);

            return matrix;
        }

        private bool[,] MovementToDown(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row + 1, Position.Column);
            matrix = MovementMatrix(matrix, position, 1, 0);

            return matrix;
        }

        private bool[,] MovementToDownLeftDiagonal(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row + 1, Position.Column - 1);
            matrix = MovementMatrix(matrix, position, 1, -1);

            return matrix;
        }

        private bool[,] MovementToLeft(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row, Position.Column - 1);
            matrix = MovementMatrix(matrix, position, 0, -1);

            return matrix;
        }

        private bool[,] MovementToUpLeftDiagonal(bool[,] matrix, Position position)
        {
            position.SetValues(Position.Row - 1, Position.Column - 1);
            matrix = MovementMatrix(matrix, position, -1, -1);

            return matrix;
        }

        private bool[,] MovementMatrix(bool[,] matrix, Position position, int moveRow, int moveColumn)
        {
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;

                if(Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    return matrix;
                }

                position.Row += moveRow;
                position.Column += moveColumn;
            }

            return matrix;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
