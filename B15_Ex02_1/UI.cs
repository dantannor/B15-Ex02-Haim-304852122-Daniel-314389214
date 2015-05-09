// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UI.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1
{
    using System;

    public class UI
    {
        public static void Main()
        {
            Board board = new Board(8);
            board.drawBoard(board);
            System.Console.ReadLine();
        }



        /*
         * Scans player name
         */
        public static string ScanPlayerName()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter player name:");
            return Console.ReadLine();
        }

        public static void PrintInvalidInput(string invalidInputMsg)
        {
            Console.WriteLine(invalidInputMsg);
        }

        /*
         * Asks who the player wants to play against
         */
        public static string AskPlayerType()
        {
            Console.WriteLine();
            Console.WriteLine(
@"Choose your opponent:

1. Player
2. PC");

             return Console.ReadKey().KeyChar.ToString();
        }

        // TODO: gets the player's move
        public static void ScanPlayerMove()
        {
            throw new NotImplementedException();
        }

        /*
         * Scans board size
         */
        public static string AskBoardSize()
        {
            Console.WriteLine();
            Console.WriteLine(
@"Choose board size:

1. 6x6
2. 8x8");

            return Console.ReadKey().KeyChar.ToString();
        }

        /*
         * TODO: Prints end of game
         */
        public static void PrintGameOver(int io_Player1Points, int io_Player2Points, int i_Victor)
        {
        }
    }
}
