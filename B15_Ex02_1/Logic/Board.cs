// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Board.cs" company="">
//   
// </copyright>
// <summary>
//   The board.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.Logic
{
    /// <summary>
    /// The board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The cells.
        /// </summary>
        private char[,] cells;

        /// <summary>
        /// The m_board size.
        /// </summary>
        private int m_boardSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="boardSize">
        /// The board size.
        /// </param>
        public Board(int boardSize)
        {
            cells = new char[boardSize, boardSize];
            m_boardSize = boardSize;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public int Size
        {
            get
            {
                return m_boardSize;
            }
        }

        /// <summary>
        /// The get cell.
        /// </summary>
        /// <param name="num">
        /// The num.
        /// </param>
        /// <param name="letter">
        /// The letter.
        /// </param>
        /// <returns>
        /// The <see cref="char"/>.
        /// </returns>
        public char getCell(char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            if (m_boardSize == 8)
            {
                if (numTonumber < 0 || numTonumber > 7 || letterToNumber < 0 || letterToNumber > 7)
                {
                    return 'E';
                }
            }
            else
            {
                if (numTonumber < 0 || numTonumber > 5 || letterToNumber < 0 || letterToNumber > 5)
                {
                    return 'E';
                }
            }

            return cells[numTonumber, letterToNumber];
        }

        /// <summary>
        /// The get cell.
        /// </summary>
        /// <param name="num1">
        /// The num 1.
        /// </param>
        /// <param name="num2">
        /// The num 2.
        /// </param>
        /// <returns>
        /// The <see cref="char"/>.
        /// </returns>
        public char getCell(int num1, int num2)
        {
            return cells[num1, num2];
        }

        /// <summary>
        /// The set cell.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="num">
        /// The num.
        /// </param>
        /// <param name="letter">
        /// The letter.
        /// </param>
        public void setCell(char c, char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            cells[numTonumber, letterToNumber] = c;
        }
    }
}