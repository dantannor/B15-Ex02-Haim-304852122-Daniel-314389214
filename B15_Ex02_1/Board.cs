// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Board.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1
{
    using System;

    public class Board
    {
        private char[] cells;

        private int m_boardSize;

        public Board(int boardSize)
        {
            cells = new char[boardSize * boardSize];
            m_boardSize = boardSize;
        }

        // get the specific cell - number and big letter
        public char getCell(char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            return cells[numTonumber * m_boardSize + letterToNumber];
        }

        // this method for internal use in darwBoard method
        public char getCell(int num1, int num2)
        {
            return cells[num1 * m_boardSize + num2];
        }

        // set value in a specific cell
        public void setCell(char c, char num, char letter)
        {
            int letterToNumber = letter - 65;
            int numTonumber = num - 49;
            cells[numTonumber * m_boardSize + letterToNumber] = c;
        }

        // draw the board and initialize it with two 'O' and two 'x'
        // there is option to 6 size board and 8 size, by the m_boardSize
        public void drawBoard(Board io_Board)
        {
            int size = m_boardSize;
            char[] firtRowBoardSizeEight = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] firtRowBoardSizeSix = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] firtColBoardSizeEight = new[] { '1', '2', '3', '4', '5', '6', '7', '8' };
            char[] firtColBoardSizeSix = new[] { '1', '2', '3', '4', '5', '6' };

            string LineEight = " =================================";
            string LineSix = " =========================";

            if (size == 8)
            {
                Console.Write("   {0}   ", firtRowBoardSizeEight[0]);
                for (int i = 1; i < size; i++)
                {
                    Console.Write("{0}   ", firtRowBoardSizeEight[i]);
                }

                Console.WriteLine();
                Console.Write(LineEight);

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine();
                    Console.Write(
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
                    Console.WriteLine();
                    Console.Write(LineEight);
                }
            }
            else
            {
                if (size == 6)
                {
                    Console.Write("   {0}   ", firtRowBoardSizeSix[0]);
                    for (int i = 1; i < size; i++)
                    {
                        Console.Write("{0}   ", firtRowBoardSizeSix[i]);
                    }

                    Console.WriteLine();
                    Console.Write(LineSix);

                    for (int i = 0; i < size; i++)
                    {
                        Console.WriteLine();
                        Console.Write(
                            "{0}| {1} | {2} | {3} | {4} | {5} | {6} |", 
                            firtColBoardSizeEight[i], 
                            io_Board.getCell(i, 0), 
                            io_Board.getCell(i, 1), 
                            io_Board.getCell(i, 2), 
                            io_Board.getCell(i, 3), 
                            io_Board.getCell(i, 4), 
                            io_Board.getCell(i, 5), 
                            io_Board.getCell(i, 6));
                        Console.WriteLine();
                        Console.Write(LineSix);
                    }
                }
            }
        }
    }
}

