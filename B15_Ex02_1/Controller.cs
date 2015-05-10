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
        private static Board m_Board;

        private static Player m_Player1;

        private static Player m_Player2;


        /*
         * 2nd Player type PC/Player 2
         */
        public enum ePlayerType
        {
            Player = 1,
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

        }

        /*
         * Initializes the board by scanning a size and creating.
         */
        private static void initBoard()
        {
            eBoardSize boardSize = getBoardSize();

            switch (boardSize)
            {
                case eBoardSize.Six:
                    m_Board = new Board(6);
                    break;

                case eBoardSize.Eight:
                    m_Board = new Board(8);
                    break;
            }
        }

        /*
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
            m_Player1 = new Player(player1Name, ePlayerType.Player);

            // Determine player2 type and act accordingly
            ePlayerType ePlayerOrPc = getPlayer2Type();
            
            switch (ePlayerOrPc)
            {
                case ePlayerType.Player:
                    string player2Name = getPlayerName();
                    m_Player2 = new Player(player2Name, ePlayerType.Player);
                    break;

                case ePlayerType.PC:
                    m_Player2 = new Player("*PC*", ePlayerType.PC);
                    break;
            }
        }

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
    }
}

