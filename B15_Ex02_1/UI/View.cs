// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UI.cs" company="">
//   
// </copyright>
// <summary>
//   The view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace B15_Ex02_1.UI
{
    using System;
    using System.Threading;

    using B15_Ex02_1.Logic;

    /// <summary>
    /// The view.
    /// </summary>
    public class View
    {
        /*
         * Scans player name
         */

        /// <summary>
        /// The scan player name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ScanPlayerName()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter player name:");

            string playerName = Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
            return playerName;
        }

        /// <summary>
        /// The print invalid input.
        /// </summary>
        /// <param name="invalidInputMsg">
        /// The invalid input msg.
        /// </param>
        public static void PrintInvalidInput(string invalidInputMsg)
        {
            Console.WriteLine(invalidInputMsg);

            // TODO optional: clear here then redraw in other class
            Thread.Sleep(1000);
            Ex02.ConsoleUtils.Screen.Clear();
        }

        /*
         * Asks who the player wants to play against
         */

        /// <summary>
        /// The ask player type.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string AskPlayerType()
        {
            Console.WriteLine();
            Console.WriteLine(@"Choose your opponent:

1. Player
2. PC");

            string playerType = Console.ReadKey().KeyChar.ToString();
            Ex02.ConsoleUtils.Screen.Clear();
            return playerType;
        }

        /**
         * Gets the player's move
         */

        /// <summary>
        /// The scan player move.
        /// </summary>
        /// <param name="io_PlayerName">
        /// The io_ player name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ScanPlayerMove(string io_PlayerName)
        {
            Console.WriteLine(@"{0}'s Move:
", io_PlayerName);
            return Console.ReadLine();
        }

        /*
         * Scans board size
         */

        /// <summary>
        /// The ask board size.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string AskBoardSize()
        {
            Console.WriteLine();
            Console.WriteLine(@"Choose board size:

1. 6x6
2. 8x8");

            string boardSize = Console.ReadKey().KeyChar.ToString();
            Ex02.ConsoleUtils.Screen.Clear();
            return boardSize;
        }

        /*
         * Draws the board
         */

        /// <summary>
        /// The draw board.
        /// </summary>
        /// <param name="io_Board">
        /// The io_ board.
        /// </param>
        public static void DrawBoard(Board io_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            int size = io_Board.Size;
            char[] firtRowBoardSizeEight = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] firtRowBoardSizeSix = { 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] firtColBoardSizeEight = { '1', '2', '3', '4', '5', '6', '7', '8' };
            char[] firtColBoardSizeSix = { '1', '2', '3', '4', '5', '6' };

            string LineEight = " =================================";
            string LineSix = " =========================";

            if (size == 8)
            {
                Console.Write("   {0}   ", firtRowBoardSizeEight[0]);
                for (int i = 1; i < size; i++)
                {
                    Console.Write("{0}   ", firtRowBoardSizeEight[i]);
                }

                Console.WriteLine();
                Console.Write(LineEight);

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine();
                    Console.Write(
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
                    Console.WriteLine();
                    Console.Write(LineEight);
                }
            }
            else
            {
                if (size == 6)
                {
                    Console.Write("   {0}   ", firtRowBoardSizeSix[0]);
                    for (int i = 1; i < size; i++)
                    {
                        Console.Write("{0}   ", firtRowBoardSizeSix[i]);
                    }

                    Console.WriteLine();
                    Console.Write(LineSix);

                    for (int i = 0; i < size; i++)
                    {
                        Console.WriteLine();
                        Console.Write(
                            "{0}| {1} | {2} | {3} | {4} | {5} | {6} |", 
                            firtColBoardSizeEight[i], 
                            io_Board.getCell(i, 0), 
                            io_Board.getCell(i, 1), 
                            io_Board.getCell(i, 2), 
                            io_Board.getCell(i, 3), 
                            io_Board.getCell(i, 4), 
                            io_Board.getCell(i, 5));
                        Console.WriteLine();
                        Console.Write(LineSix);
                    }
                }
            }

            Console.WriteLine();
        }

        /*
         * Prints end of game
         */

        /// <summary>
        /// The print game over.
        /// </summary>
        /// <param name="io_Player1Points">
        /// The io_ player 1 points.
        /// </param>
        /// <param name="io_Player2Points">
        /// The io_ player 2 points.
        /// </param>
        /// <param name="i_Victor">
        /// The i_ victor.
        /// </param>
        /// <param name="io_Player2">
        /// The io_ player 2.
        /// </param>
        public static void PrintGameOver(int io_Player1Points, int io_Player2Points, string i_Victor, string io_Player2)
        {
            Console.WriteLine(@"The game has finished!

{0} is the victor with {1} points!
And {2} with {3} points!
", i_Victor, io_Player1Points, io_Player2, io_Player2Points);
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
        }

        /// <summary>
        /// The display turn switch.
        /// </summary>
        /// <param name="noMovesPlayer">
        /// The no moves player.
        /// </param>
        public static void DisplayTurnSwitch(string noMovesPlayer)
        {
            Console.WriteLine(@"{0} has no moves, sorry! Turn transfer!", noMovesPlayer);
            Console.WriteLine();
        }

        /// <summary>
        /// The ask play again.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string AskPlayAgain()
        {
            Console.WriteLine(@"Would you like another round?
1. Yes
2. No");
            string anotherRound = Console.ReadKey().KeyChar.ToString();
            Ex02.ConsoleUtils.Screen.Clear();
            return anotherRound;
        }

        public static void Welcome()
        {
            Console.WriteLine(
@"



            =========================================================




                                Welcome to Reversee!


                              Press any key to continue...

            (Choose q during your move if you want to exit! Have fun!) 



            ==========================================================");
           Console.ReadKey();
           Ex02.ConsoleUtils.Screen.Clear();
        }
    }
}