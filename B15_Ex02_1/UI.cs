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
    }
}
