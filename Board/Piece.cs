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

        public void AddNumberOfMovements()
        {
            NumberOfMovements ++;
        }

        protected bool CanMove(Position position)
        {
            var piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }

        public abstract bool[,] PossibleMovements();
    }
}
