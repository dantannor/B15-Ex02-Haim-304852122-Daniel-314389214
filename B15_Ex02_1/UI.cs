using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
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
            Console.WriteLine(@"Choose your opponent:
                                 1. Player
                                 2. PC");
             return Console.ReadLine();
        }
    }
}
