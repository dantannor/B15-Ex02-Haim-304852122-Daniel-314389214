using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    public class Controller
    {
        /*
        * Scan user input
        */

        public Controller()
        {
        }

        private enum ePlayerType
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
         * Ask for Player 2 or PC from user and validate
         */
        private static ePlayerType getPlayer2Type()
        {
            int playerTypeNum;
            int.TryParse(UI.AskPlayerType(), out playerTypeNum);

            while (!(Enum.IsDefined(typeof(ePlayerType), playerTypeNum)))
            {
                UI.PrintInvalidInput("Sorry, that's an invalid player type. Please re-enter:");
                int.TryParse(UI.AskPlayerType(), out playerTypeNum);
            }

            return (ePlayerType)playerTypeNum;
        }

        /*
         * Initial start up of values at game beginning.
         */
        public static void ScanInputAndInitialize()
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
            

    // If valid string, initialize player1
    Player player1 = new Player(player1Name, player);
            

            
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
        private static bool validatePlayerName(string io_playerName)
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


