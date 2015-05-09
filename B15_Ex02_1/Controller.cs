// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

    public class Controller
    {
        /*
         * 2nd Player type PC/Player 2
         */
        private enum ePlayerType
        {
            Player2 = 1,
            PC = 2
        }

        /*
         * scans and validates correct player name using UI
         */
        private static string getPlayerName()
        {
            // Read player name and check input
            string playerName = UI.ScanPlayerName();

            while (!validatePlayerName(playerName))
            {
                Console.WriteLine();
                UI.PrintInvalidInput("Sorry, that's an invalid player name. Please re-enter:");
                playerName = UI.ScanPlayerName();
            }

            return playerName;
        }

        /*
         * Ask for Player 2 or PC from user and validate
         */
        private static ePlayerType getPlayer2Type()
        {
            int playerTypeNum;
            string playerType = UI.AskPlayerType();
            int.TryParse(playerType, out playerTypeNum);

            while (!Enum.IsDefined(typeof(ePlayerType), playerTypeNum))
            {
                Console.WriteLine();
                UI.PrintInvalidInput("Sorry, that's an invalid player type. Please re-enter:");
                int.TryParse(UI.AskPlayerType(), out playerTypeNum);
            }

            return (ePlayerType)playerTypeNum;
        }

        /*
          * Validates correct input for player name
          */
        private static bool validatePlayerName(string io_playerName)
        {
            const string sPattern = "[A-Za-z0-9]+";

            return Regex.IsMatch(io_playerName, sPattern);
        }

        /*
         * Initial start up of values at game beginning.
         */
        public static void ScanInputAndInitializePlayers()
        {
            string player1Name = getPlayerName();
            Player player1 = new Player(player1Name, "player");
            Player player2;

            // Determine player2 type and act accordingly
            ePlayerType ePlayerOrPc = getPlayer2Type();
            
            switch (ePlayerOrPc)
            {
                case ePlayerType.Player2:
                    string player2Name = getPlayerName();
                    player2 = new Player(player2Name, "player");
                    break;

                case ePlayerType.PC:
                    player2 = new Player("PC", "PC");
                    break;
            }
        }

        /*
         *TODO: Initialize board
         */ 
        private void scanAndInitializeBoard()
        {
            
        }

        /*
         * TODO: Decide whose turn it is
         */
        private void decideTurn()
        {
            // Get valid moves
        }


          

                /*
         * Checks input type
         */
            /*
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
        **/
        }
    }
}
