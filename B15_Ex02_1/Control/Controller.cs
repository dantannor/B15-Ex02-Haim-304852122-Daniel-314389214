// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.Control
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

    using B15_Ex02_1.Logic;
    using B15_Ex02_1.UI;

    public class Controller
    {
        private static Board m_Board;

        private static Player m_Player1;

        private static Player m_Player2;

        private static string m_PlayerMove;

        private static Game.eTurn m_PlayerTurn; 


        /*
         * 2nd Player type PC/Player 2
         */
        public enum ePlayer
        {
            Player = 1,
            PC = 2,
            Player2 = 3
        }

        /*
         * scans and validates correct player name using UI
         */
        private static string getPlayerName()
        {
            // Read player name and check input
            string playerName = View.ScanPlayerName();

            while (!InputValidation.ValidatePlayerName(playerName))
            {
                Console.WriteLine();
                View.PrintInvalidInput("Sorry, that's an invalid player name. Please re-enter:");
                playerName = View.ScanPlayerName();
            }

            return playerName;
        }

        /*
         * Ask for Player 2 or PC from user and validate
         */
        private static ePlayer getPlayer2Type()
        {
            int playerTypeNum;
            string playerType = View.AskPlayerType();
            int.TryParse(playerType, out playerTypeNum);

            while (!Enum.IsDefined(typeof(ePlayer), playerTypeNum) && (playerTypeNum != (int)ePlayer.Player2))
            {
                Console.WriteLine();
                View.PrintInvalidInput("Sorry, that's an invalid player type. Please re-enter:");
                int.TryParse(View.AskPlayerType(), out playerTypeNum);
            }

            return (ePlayer)playerTypeNum;
        }

        /*
         * Initial start up of values at game beginning.
         */
        public Controller()
        {
            initPlayers();
            initBoard();
            Game game = new Game(m_Player1, m_Player2);
            play();
        }

        /*
         * Starts and handles the game.
         */
        private static void play()
        {
            m_PlayerTurn = Game.GetTurn();

            while (Game.GetTurn() != Game.eTurn.GameOver)
            {

                // Get player move, validate and pass it on to game move, which updates the board.
                

                switch (playerTurn)
                {
                     case Game.eTurn.Player1:
                        m_PlayerMove = getPlayerMove(m_Player1.PlayerName);
                        Game.ValidMove(m_PlayerMove);
                        Game.Move(playerTurn, m_PlayerMove);
                        break;
                     case Game.eTurn.Player2:
                        m_PlayerMove = getPlayerMove(m_Player2.PlayerName);
                        Game.ValidMove(m_PlayerMove);
                        Game.Move(playerTurn, m_PlayerMove);
                        break;
                }
                
            }  
        }

        /*
         * Gets player move from user
         */
        private static string getPlayerMove(string playerName)
        {
            // Read player name and check input
            string playerMove = View.ScanPlayerMove(playerName);

            while (!Game.ValidMove(playerMove))
            {
                Console.WriteLine();
                View.PrintInvalidInput("Sorry, that's an invalid move. Please re-enter:");
                playerMove = View.ScanPlayerMove(playerName);
            }

            return playerMove;
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
            string boardSize = View.AskBoardSize();
            int.TryParse(boardSize, out boardSizeNum);

            while (!Enum.IsDefined(typeof(eBoardSize), boardSizeNum))
            {
                Console.WriteLine();
                View.PrintInvalidInput("Sorry, that's an invalid board size. Please re-enter:");
                int.TryParse(View.AskPlayerType(), out boardSizeNum);
            }

            return (eBoardSize)boardSizeNum;
        }

        /*
         * Scan player names and create instances
         */
        private static void initPlayers()
        {
            string player1Name = getPlayerName();
            m_Player1 = new Player(player1Name, ePlayer.Player);

            // Determine player2 type and act accordingly
            ePlayer ePlayerOrPc = getPlayer2Type();
            
            switch (ePlayerOrPc)
            {
                case ePlayer.Player:
                    string player2Name = getPlayerName();
                    m_Player2 = new Player(player2Name, ePlayer.Player2);
                    break;

                case ePlayer.PC:
                    m_Player2 = new Player("*PC*", ePlayer.PC);
                    break;
            }
        }

        /*
         * Board size
         */
        public enum eBoardSize
         {
                Six = 1,
                Eight = 2
         }

    }
}

