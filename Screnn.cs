using ChessGame.Board;
using ChessGame.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    class Screnn
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCatchedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Round: " + match.Round);
            Console.WriteLine("Waiting move: " + match.CurrentPlayer);
        }

        public static void PrintCatchedPieces(ChessMatch match)
        {
            Console.WriteLine("Catched pieces:");

            Console.Write("White: ");
            PrintGroup(match.CatchedPiecesByColor(Color.White));
            Console.WriteLine();

            Console.Write("Black: ");
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(match.CatchedPiecesByColor(Color.Black));
            Console.ForegroundColor = oldColor;
            Console.WriteLine();
        }

        public static void PrintGroup(HashSet<Piece> pieces)
        {
            Console.Write("[ ");
            foreach(Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board.Board board)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.Write(8 - i + " ");
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        
        public static void PrintBoard(Board.Board board, bool[,] possiblePositions)
        {
            var originalBackground = Console.BackgroundColor;
            var alteredBackground = ConsoleColor.DarkGray;

            Console.WriteLine("  a b c d e f g h");
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.Write(8 - i + " ");
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    var aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition GetChessPosition()
        {
            var input = Console.ReadLine();
            var column = input[0];
            var row = int.Parse(new StringBuilder().Append(input[1]).ToString());

            return new ChessPosition(column, row);
        }
    }
}
