using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_Ex02_1.Logic
{
    public class Board
    {

        private char[,] cells;

        private int m_boardSize;

        public Board(int boardSize)
        {
            cells = new char[boardSize, boardSize];
            m_boardSize = boardSize;
        }

        public int Size
        {
            get { return m_boardSize; }
        }

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

        public char getCell(int num1, int num2)
        {

            return cells[num1, num2];
        }

        public void setCell(char c, char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            cells[numTonumber, letterToNumber] = c;
        }

    }
}

