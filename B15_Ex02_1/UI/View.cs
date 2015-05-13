// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UI.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.UI
{
    using System;

    public class View
    {
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

        /**
         * Gets the player's move
         */
        public static string ScanPlayerMove(string io_PlayerName)
        {
            Console.WriteLine(
@"{0}'s Move:
",
 io_PlayerName);
            return Console.ReadLine();
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
         * Prints end of game
         */
        public static void PrintGameOver(int io_Player1Points, int io_Player2Points, string i_Victor, string io_Player2)
        {
            Console.WriteLine(
@"The game has finished!

{0} is the victor with {1} points!
And {2} with {3} points!
",
 i_Victor,
 io_Player1Points,
 io_Player2,
 io_Player2Points);       
        }

        public void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}
