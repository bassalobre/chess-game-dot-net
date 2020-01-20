namespace ChessGame.Board
{
    class Piece
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
    }
}
