﻿using System;
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
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}