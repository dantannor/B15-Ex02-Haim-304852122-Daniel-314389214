// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.Logic
{
    public class Player
    {
        private readonly string m_PlayerName;

        private readonly Controller.ePlayer mPlayer;

        private int m_PlayerPoints;

        private string m_PlayerMove;

        public Player(string io_PlayerName, Controller.ePlayer i_Player)
        {
            this.m_PlayerName = io_PlayerName;
            this.m_PlayerPoints = 0;
            this.mPlayer = i_Player;
        }
        public int PlayerPoints
        {
            get { return this.m_PlayerPoints; }
            set { this.m_PlayerPoints = value; }
        }

        public Controller.ePlayer Type
        {
            get { return this.mPlayer; }
        }
        public string PlayerName
        {
            get { return this.m_PlayerName; }
        }
        /*
         * TODO: Asks for move from the user and commits
         */
        public void Move()
        {
            // get valid moves
            if (this.mPlayer.Equals(Controller.ePlayer.PC))
            {
                calcPCMove();
            }
            // If human
            else if (this.mPlayer.Equals(Controller.ePlayer.Player))
            {
                this.m_PlayerMove = View.ScanPlayerMove(this.m_PlayerName);

                // Add Q for exit
                while (!validPlayerMove(m_PlayerMove))
                {
                    View.PrintInvalidInput("Invalid move, please re-enter:");
                    this.m_PlayerMove = View.ScanPlayerMove(this.m_PlayerName);
                }
            }

            // else if pc create random move
        }

        /*
         * Checks if player move is valid vs regex
         */
        private bool validPlayerMove(string io_PlayerMove)
        {
            // Check vs list of valid moves if exists.
            throw new System.NotImplementedException();
        }

        /*
         * Calculates a valid PC move
         */
        private string calcPCMove()
        {
            /*
             * getValidMoves, then choose a random number to choose one of the moves from list
             */
            
        }

        /*
         * Updates players points
         */
        public void UpdatePlayerPoints(int io_PlayerPoints)
        {
            this.m_PlayerPoints += io_PlayerPoints;
        }
    }
}
