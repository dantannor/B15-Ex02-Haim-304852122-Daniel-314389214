// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.Logic
{
    using B15_Ex02_1.Control;
    using B15_Ex02_1.UI;

    public class Player
    {
        private readonly string m_PlayerName;

        private readonly Controller.ePlayer mPlayer;

        private int m_PlayerPoints;

        public Player(string io_PlayerName, Controller.ePlayer i_Player)
        {
            this.m_PlayerName = io_PlayerName;
            this.m_PlayerPoints = 2;
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
         * Updates players points
         */
        public void UpdatePlayerPoints(int io_PlayerPoints)
        {
            this.m_PlayerPoints += io_PlayerPoints;
        }

    }
}
