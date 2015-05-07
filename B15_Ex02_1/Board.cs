using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{

    public class Board
    {
        private char[] cells;
        private int m_boardSize;

        public Board(int boardSize)
        {
            cells = new char[boardSize * boardSize];
            m_boardSize = boardSize;
        }

        public char getCell(char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            return cells[numTonumber * m_boardSize + letterToNumber];
        }

        public char getCell(int num1, int num2)
        {
            return cells[num1 * m_boardSize + num2];
        }

        public void setCell(char c, char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            cells[numTonumber * m_boardSize + letterToNumber] = c;
        }

        public void drawBoard(Board io_Board)
        {
            int size = m_boardSize;
            char[] firtRowBoardSizeEight = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] firtRowBoardSizeSix = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] firtColBoardSizeEight = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
            char[] firtColBoardSizeSix = new char[] { '1', '2', '3', '4', '5', '6' };

            String LineEight = " =================================";
            String LineSix = " =========================";

            if (size == 8)
            {

                System.Console.Write("   {0}   ", firtRowBoardSizeEight[0]);
                for (int i = 1; i < size; i++)
                {
                    System.Console.Write("{0}   ", firtRowBoardSizeEight[i]);
                }
                System.Console.WriteLine();
                System.Console.Write(LineEight);

                for (int i = 0; i < size; i++)
                {
                    System.Console.WriteLine();
                    System.Console.Write("{0}| {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} |", firtColBoardSizeEight[i],
                        io_Board.getCell(i, 0), io_Board.getCell(i, 1), io_Board.getCell(i, 2), io_Board.getCell(i, 3), io_Board.getCell(i, 4),
                        io_Board.getCell(i, 5), io_Board.getCell(i, 6), io_Board.getCell(i, 7));
                    System.Console.WriteLine();
                    System.Console.Write(LineEight);
                }
            }
            else
            {
                if (size == 6)
                {

                    System.Console.Write("   {0}   ", firtRowBoardSizeSix[0]);
                    for (int i = 1; i < size; i++)
                    {
                        System.Console.Write("{0}   ", firtRowBoardSizeSix[i]);
                    }
                    System.Console.WriteLine();
                    System.Console.Write(LineSix);

                    for (int i = 0; i < size; i++)
                    {
                        System.Console.WriteLine();
                        System.Console.Write("{0}| {1} | {2} | {3} | {4} | {5} | {6} |", firtColBoardSizeEight[i],
                            io_Board.getCell(i, 0), io_Board.getCell(i, 1), io_Board.getCell(i, 2), io_Board.getCell(i, 3), io_Board.getCell(i, 4),
                        io_Board.getCell(i, 5), io_Board.getCell(i, 6));
                        System.Console.WriteLine();
                        System.Console.Write(LineSix);
                    }
                }
            }
        }
    }
}

