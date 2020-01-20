using ChessGame.Board;
using ChessGame.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    class Screnn
    {
        public static void PrintBoard(Board.Board board)
        {
            for(int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
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
