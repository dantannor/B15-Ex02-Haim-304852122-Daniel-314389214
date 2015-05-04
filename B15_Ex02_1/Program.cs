using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    using System.Media;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Scan input
            scanInputAndInitialize();
        }

        /*
         * Scan user input
         */
        private static void scanInputAndInitialize()
        {
            Console.WriteLine("Enter Player1 name");
            string player1Name = Console.ReadLine();
            checkInput(player1Name);

            // If valid string, initialize player1
            Player player1 = new Player(player1Name, player);

            Console.WriteLine(@"Choose your opponent:
                                 1. Player
                                 2. Computer");

            string opponentType = Console.ReadLine();
            while (opponentType != 1 || != 2)
            {
                checkInput(opponentType);
            }

            if (opponentType == 1)
            {
                Console.WriteLine("Enter Player2 name");
                string player2Name = Console.ReadLine();
                checkInput(player2Name);
                Player player2 = new Player(player2Name, player);
            }
            else if (opponentType == 2)
            {
                Player computer = new Player(pc, pc);
            }

            Console.WriteLine("Please enter board size (min 6 or 8)");
            string boardSize = Console.ReadLine();
            while (boardSize < 6)
            {
                checkInput(boardSize);
            }

            Board board = new Board(boardSize);

        }

        /*
         * Checks input and re-requests if it's problematic
         */
        private void checkInput(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);
            while (!isNumber || stringNumber.Length != 8 || number < 0)
            {
                Console.WriteLine("invalid number, try again");
                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }
        }
    }
}

    
