using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_Ex02_1.Logic
{
    public class Board
    {
        private readonly int m_boardSize;

        private eCoin[,] cells;

        /*
         * Creates a board instance with user size - 6 or 8
         */
        public Board(int boardSize)
        {
            cells = new eCoin[boardSize, boardSize];
            m_boardSize = boardSize;
        }

        /*
         * Get matrix cell data
         */
        public eCoin getCell(char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;

            // Return empty coin if we leave board limit
            if (numTonumber < 0 || numTonumber > 7 || letterToNumber < 0 || letterToNumber > 7)
            {
                return eCoin.E;
            }
            return cells[numTonumber, letterToNumber];
        }

        public eCoin getCell(int num1, int num2)
        {

            return cells[num1, num2];
        }

        public void setCell(eCoin c, char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            cells[numTonumber, letterToNumber] = c;
        }

        public void drawBoard(Board io_Board)
        {
            char[] firtRowBoardSizeEight = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] firtRowBoardSizeSix = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] firtColBoardSizeEight = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
            char[] firtColBoardSizeSix = new char[] { '1', '2', '3', '4', '5', '6' };

            const string LineEight = " =================================";
            const string LineSix = " =========================";

            if (m_boardSize == 8)
            {

                System.Console.Write("   {0}   ", firtRowBoardSizeEight[0]);
                for (int i = 1; i < m_boardSize; i++)
                {
                    System.Console.Write("{0}   ", firtRowBoardSizeEight[i]);
                }
                System.Console.WriteLine();
                System.Console.Write(LineEight);

                for (int i = 0; i < m_boardSize; i++)
                {
                    System.Console.WriteLine();
                    System.Console.Write(
                        "{0}| {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} |",
                        firtColBoardSizeEight[i],
                        io_Board.getCell(i, 0),
                        io_Board.getCell(i, 1),
                        io_Board.getCell(i, 2),
                        io_Board.getCell(i, 3),
                        io_Board.getCell(i, 4),
                        io_Board.getCell(i, 5),
                        io_Board.getCell(i, 6),
                        io_Board.getCell(i, 7));
                    System.Console.WriteLine();
                    System.Console.Write(LineEight);
                }
            }
            else
            {
                if (m_boardSize == 6)
                {

                    System.Console.Write("   {0}   ", firtRowBoardSizeSix[0]);
                    for (int i = 1; i < m_boardSize; i++)
                    {
                        System.Console.Write("{0}   ", firtRowBoardSizeSix[i]);
                    }
                    System.Console.WriteLine();
                    System.Console.Write(LineSix);

                    for (int i = 0; i < m_boardSize; i++)
                    {
                        System.Console.WriteLine();
                        System.Console.Write(
                            "{0}| {1} | {2} | {3} | {4} | {5} | {6} |",
                            firtColBoardSizeEight[i],
                            io_Board.getCell(i, 0),
                            io_Board.getCell(i, 1),
                            io_Board.getCell(i, 2),
                            io_Board.getCell(i, 3),
                            io_Board.getCell(i, 4),
                            io_Board.getCell(i, 5),
                            io_Board.getCell(i, 6));
                        System.Console.WriteLine();
                        System.Console.Write(LineSix);
                    }
                }
            }
        }
    }

    public enum eCoin
    {
        O,

        X,

        E
    }
}

