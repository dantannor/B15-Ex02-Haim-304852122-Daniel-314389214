using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    class Controller
    {
        private Player m_firstPlayer;
        private Player m_secondPlayer;
        private int m_currentPlayer;
        public Board m_Board;
        private int m_BoardSize;
        private eOpponent m_OpponentType;

        enum eOpponent
        {
            Computer = 1,
            User = 2
        }

        public Controller(Player io_player1, Player io_player2, int boardSize, int io_opponentType)
        {
            m_firstPlayer = io_player1;
            m_secondPlayer = io_player2;
            m_currentPlayer = 1;
            m_BoardSize = boardSize;
            m_Board = new Board(boardSize);
            if (boardSize == 8)
            {
                m_Board.setCell('O', '4', 'D');
                m_Board.setCell('X', '4', 'E');
                m_Board.setCell('X', '5', 'D');
                m_Board.setCell('O', '5', 'E');
            }
            else
            {
                if (boardSize == 6)
                {
                    m_Board.setCell('O', '3', 'C');
                    m_Board.setCell('X', '3', 'D');
                    m_Board.setCell('X', '4', 'C');
                    m_Board.setCell('O', '4', 'D');
                }
            }


            if (io_opponentType == (int)eOpponent.Computer)
            {
                this.m_OpponentType = eOpponent.Computer;
            }
            else
            {
                this.m_OpponentType = eOpponent.User;
            }
        }

        public void GameAgainstPlayer()
        {

            Ex02.ConsoleUtils.Screen.Clear();
            char row;
            char column;
            m_Board.drawBoard(m_Board);
            System.Console.WriteLine();
            System.Console.WriteLine("please enter row and column in this form 1A:");
            String input = System.Console.ReadLine();
            if (input == "Q")
            {
                return;
            }

            while (input.Length != 2)
            {

                System.Console.WriteLine("invalid input, please enter row and column in this form 1A:");
                input = System.Console.ReadLine();

            }
            row = input[0];
            column = input[1];

            while (row < 49 || row > 56 || column < 65 || column > 72)
            {
                System.Console.WriteLine("invalid input, please enter row and column in this form 1A:");
                input = System.Console.ReadLine();
                if (input == "Q")
                {
                    return;
                }
                row = input[0];
                column = input[1];

            }

            if (checkedValidCell(m_Board, row, column))
            {
                if (m_currentPlayer == 1)
                {
                    m_Board.setCell('O', row, column);
                    m_currentPlayer = 2;
                }
                else
                {
                    m_Board.setCell('X', row, column);
                    m_currentPlayer = 1;

                }
                GameAgainstPlayer();
            }
            else
            {
                GameAgainstPlayer();
            }

            m_Board.setCell('X', '4', 'D');
            GameAgainstPlayer();
        }
        private static bool checkedValidCell(Board board, char row, char column)
        {

            while (board.getCell(row, column) == 'O' || board.getCell(row, column) == 'X')
            {
                return false;

            }


            return true;
        }

        private static bool checkedValidMove(Board board, char row, char column)
        {




            return true;
        }

    }
}

