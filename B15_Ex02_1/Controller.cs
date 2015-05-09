// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1
{
<<<<<<< HEAD
<<<<<<< HEAD
=======
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

>>>>>>> origin/master
    public class Controller
=======
    public class Controller 
>>>>>>> parent of 65523e8... a
    {
        private static Board m_Board;

        private static Player m_Player1;

        private static Player m_Player2;


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
        public static void Init()
        {
            initPlayers();
            initBoard();

<<<<<<< HEAD
            // Determine player2 type and act accordingly
            ePlayerType ePlayerOrPc = getPlayer2Type();
            
            switch (ePlayerOrPc)
=======
        }

        /*
         * Initializes the board by scanning a size and creating.
         */
        private static void initBoard()
        {
            eBoardSize boardSize = getBoardSize();

            switch (boardSize)
>>>>>>> origin/master
            {
                case eBoardSize.Six:
                    m_Board = new Board(6);
                    break;

                case eBoardSize.Eight:
                    m_Board = new Board(8);
                    break;
            }

<<<<<<< HEAD
        /*
<<<<<<< HEAD
=======

                /*
>>>>>>> parent of 65523e8... a
            

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
<<<<<<< HEAD
                v_validStringInput = (io_input != null) && io_input.All(Char.IsLetter);
=======
         * Scan board size and create instance
         */
        private static eBoardSize getBoardSize()
        {
            int boardSizeNum;
            string boardSize = UI.AskBoardSize();
            int.TryParse(boardSize, out boardSizeNum);

            while (!Enum.IsDefined(typeof(eBoardSize), boardSizeNum))
            {
                Console.WriteLine();
                UI.PrintInvalidInput("Sorry, that's an invalid board size. Please re-enter:");
                int.TryParse(UI.AskPlayerType(), out boardSizeNum);
            }

            return (eBoardSize)boardSizeNum;
        }

        /*
         * Scan player names and create instances
         */
        private static void initPlayers()
        {
            string player1Name = getPlayerName();
            m_Player1 = new Player(player1Name, "player");

            // Determine player2 type and act accordingly
            ePlayerType ePlayerOrPc = getPlayer2Type();
            
            switch (ePlayerOrPc)
            {
                case ePlayerType.Player2:
                    string player2Name = getPlayerName();
                    m_Player2 = new Player(player2Name, "player");
                    break;

                case ePlayerType.PC:
                    m_Player2 = new Player("PC", "PC");
                    break;
>>>>>>> origin/master
            }
        }

<<<<<<< HEAD
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
=======
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

>>>>>>> parent of 65523e8... a

        }

<<<<<<< HEAD

=======
        /*
         * Board size
         */
        private enum eBoardSize
         {
                Six = 1,
                Eight = 2
         }

        /*
         * TODO: Decide whose turn it is
         */
        private void decideTurn()
        {
            // Get valid moves
        }
>>>>>>> origin/master
=======
>>>>>>> parent of 65523e8... a
    }
}
<<<<<<< HEAD

<<<<<<< HEAD

=======
>>>>>>> origin/master
=======
>>>>>>> parent of 65523e8... a
