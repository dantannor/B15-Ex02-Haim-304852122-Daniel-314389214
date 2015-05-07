using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    class Controller
    {
        /*
        * Scan user input
        */
        private static void scanInputAndInitialize()
        {
            Console.WriteLine("Enter Player1 name");
            string player1Name = Console.ReadLine();
            validateInput(checkInputType(player1Name), string, 0, 0);

            // If valid string, initialize player1
            Player player1 = new Player(player1Name, player);

            Console.WriteLine(@"Choose your opponent:
                                 1. Player
                                 2. Computer");

            string opponentType = Console.ReadLine();
            while (opponentType != 1 || != 2)
            {
                checkInputType(opponentType);
            }

            if (opponentType == 1)
            {
                Console.WriteLine("Enter Player2 name");
                string player2Name = Console.ReadLine();
                checkInputType(player2Name);
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
                checkInputType(boardSize);
            }

            Board board = new Board(boardSize);

        }

        /*
         * Makes sure input fits demands
         */
        private static void validateInput(string io_input, string io_inputType, int i_minNumSize, int i_maxNumSize)
        {

        }

        /*
         * Checks input type
         */
        private string checkInputType(string io_input)
        {
            int number;
            bool isNumber = int.TryParse(io_input, out number);
            int inputNum;
            bool v_validStringInput = false;
            string inputType;

            // Check if it's a 10 digit number
            bool v_validNumericInput = int.TryParse(io_input, out inputNum) && !(inputNum < 0);

            if (!v_validNumericInput)
            {
                v_validStringInput = (io_input != null) && io_input.All(Char.IsLetter);
            }

            if (v_validNumericInput)
            {
                inputType = "numeric";
            }
            else if (v_validStringInput)
            {
                inputType = "string";
            }
            else
            {
                inputType = "invalid";
            }

            return inputType;
        }

    }
}
