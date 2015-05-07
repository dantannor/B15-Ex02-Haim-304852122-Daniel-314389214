using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    internal class Controller
    {
        /*
        * Scan user input
        */

        public Controller()
        {
        }

        private enum playerType
        {
            Player2 = 1,

            PC = 2
        };

        /*
         * scans and validates correct player name using UI
         */

        private static string getPlayerName()
        {
            // Read player name and check input
            string playerName = UI.ScanPlayerName();

            while (!validatePlayerName(playerName))
            {
                UI.PrintInvalidInput("Sorry, that's an invalid player name. Please re-enter:");
                playerName = UI.ScanPlayerName();
            }

            return playerName;
        }

        /*
         * Player or PC
         */
        private static playerType getPlayer2Type()
        {
            playerType playerOrPC = (playerType)UI.AskPlayerType();

            while (!validatePlayerType(playerOrPC))
            {
                UI.PrintInvalidInput("Sorry, that's an invalid player type. Please re-enter:");
                playerOrPC = (playerType)UI.AskPlayerType();
            }

            return playerOrPC;
        }

        /*
         * Initial start up of values at game beginning.
         */
        private static void scanInputAndInitialize()
        {
            string player1Name = getPlayerName();
            Player player1 = new Player(player1Name);

            // Determine player2 type and act accordingly
            playerType playerOrPC = getPlayer2Type();
            
            switch (playerOrPC)
            {
                case playerType.Player2:
                    string player2Name = getPlayerName();
                    Player player2 = new Player(player2Name);
                    break;

                case playerType.PC:
                    Player player2 = new Player("PC");
                    break;
            }
            

            string player2Name = UI.ScanPlayer();


            Player player2 = new Player(player2Name);

























                /*
            

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

                 * */
        private bool validatePlayerName(string io_playerName)
        {
            throw new NotImplementedException();
        }
             

                /*
         * Checks input type
         */
            private
            string checkInputType 
            (string
            io_input)
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
}
