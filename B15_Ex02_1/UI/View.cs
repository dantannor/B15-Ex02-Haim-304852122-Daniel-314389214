// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UI.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.UI
{
    using System;
    using System.Threading;

    using B15_Ex02_1.Control;
    using B15_Ex02_1.Logic;

    public class View
    {
        /*
         * Scans player name
         */
        public static string ScanPlayerName()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter player name:");

            string playerName = Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
            return playerName;
        }

        public static void PrintInvalidInput(string invalidInputMsg)
        {
            Console.WriteLine(invalidInputMsg);
            //TODO optional: clear here then redraw in other class
            Thread.Sleep(1000);
            Ex02.ConsoleUtils.Screen.Clear();
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

            string playerType = Console.ReadKey().KeyChar.ToString();
            Ex02.ConsoleUtils.Screen.Clear();
            return playerType;
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

            string boardSize = Console.ReadKey().KeyChar.ToString();
            Ex02.ConsoleUtils.Screen.Clear();
            return boardSize;
        }


        /*
         * Draws the board
         */
        public static void DrawBoard(Board io_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            int size = io_Board.Size;
            char[] firtRowBoardSizeEight = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] firtRowBoardSizeSix = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] firtColBoardSizeEight = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
            char[] firtColBoardSizeSix = new char[] { '1', '2', '3', '4', '5', '6' };

            String LineEight = " =================================";
            String LineSix = " =========================";

            if (size == 8)
            {

                System.Console.Write("   {0}   ", firtRowBoardSizeEight[0]);
                for (int i = 1; i < size; i++)
                {
                    System.Console.Write("{0}   ", firtRowBoardSizeEight[i]);
                }
                System.Console.WriteLine();
                System.Console.Write(LineEight);

                for (int i = 0; i < size; i++)
                {
                    System.Console.WriteLine();
                    System.Console.Write(
                        "{0}| {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} |",
                        firtColBoardSizeEight[i],
                        io_Board.getCell(i, 0),
                        io_Board.getCell(i, 1),
                        io_Board.getCell(i, 2),
                        io_Board.getCell(i, 3),
                        io_Board.getCell(i, 4),
                        io_Board.getCell(i, 5),
                        io_Board.getCell(i, 6),
                        io_Board.getCell(i, 7));
                    System.Console.WriteLine();
                    System.Console.Write(LineEight);
                }
            }
            else
            {
                if (size == 6)
                {

                    System.Console.Write("   {0}   ", firtRowBoardSizeSix[0]);
                    for (int i = 1; i < size; i++)
                    {
                        System.Console.Write("{0}   ", firtRowBoardSizeSix[i]);
                    }
                    System.Console.WriteLine();
                    System.Console.Write(LineSix);

                    for (int i = 0; i < size; i++)
                    {
                        System.Console.WriteLine();
                        System.Console.Write(
                            "{0}| {1} | {2} | {3} | {4} | {5} | {6} |",
                            firtColBoardSizeEight[i],
                            io_Board.getCell(i, 0),
                            io_Board.getCell(i, 1),
                            io_Board.getCell(i, 2),
                            io_Board.getCell(i, 3),
                            io_Board.getCell(i, 4),
                            io_Board.getCell(i, 5));
                        System.Console.WriteLine();
                        System.Console.Write(LineSix);
                    }
                }
            }
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
        }

        public static void DisplayTurnSwitch(string noMovesPlayer)
        {
            Console.WriteLine(@"{0} has no moves, sorry! Turn transfer!", noMovesPlayer);
            Console.WriteLine();
        }

        public static string AskPlayAgain()
        {
            Console.WriteLine(
@"Would you like another round?
1. Yes
2. No");
            string anotherRound = Console.ReadKey().KeyChar.ToString();
            Ex02.ConsoleUtils.Screen.Clear();
            return anotherRound;
        }
    }
}
