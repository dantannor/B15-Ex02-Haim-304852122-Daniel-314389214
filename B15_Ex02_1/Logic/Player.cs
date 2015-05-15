// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="">
//   
// </copyright>
// <summary>
//   The player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace B15_Ex02_1.Logic
{
    using B15_Ex02_1.Control;

    /// <summary>
    /// The player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The m_ player name.
        /// </summary>
        private readonly string m_PlayerName;

        /// <summary>
        /// The m player.
        /// </summary>
        private readonly Controller.ePlayer mPlayer;

        /// <summary>
        /// The m_ player points.
        /// </summary>
        private int m_PlayerPoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="io_PlayerName">
        /// The io_ player name.
        /// </param>
        /// <param name="i_Player">
        /// The i_ player.
        /// </param>
        public Player(string io_PlayerName, Controller.ePlayer i_Player)
        {
            this.m_PlayerName = io_PlayerName;
            this.m_PlayerPoints = 2;
            this.mPlayer = i_Player;
        }

        /// <summary>
        /// Gets or sets the player points.
        /// </summary>
        public int PlayerPoints
        {
            get
            {
                return this.m_PlayerPoints;
            }

            set
            {
                this.m_PlayerPoints = value;
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Controller.ePlayer Type
        {
            get
            {
                return this.mPlayer;
            }
        }

        /// <summary>
        /// Gets the player name.
        /// </summary>
        public string PlayerName
        {
            get
            {
                return this.m_PlayerName;
            }
        }

        /*
         * Updates players points
         */

        /// <summary>
        /// The update player points.
        /// </summary>
        /// <param name="io_PlayerPoints">
        /// The io_ player points.
        /// </param>
        public void UpdatePlayerPoints(int io_PlayerPoints)
        {
            this.m_PlayerPoints += io_PlayerPoints;
        }
    }
}