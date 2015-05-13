using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B15_Ex02_1.Control;

namespace B15_Ex02_1.Logic
{
    class Game
    {
        private int foundLegalMove = 0;
        private int numberOfCellsNeededToChange = 1;
        private bool changeTheSequence = false;

        private Player m_Player1;

        private Player m_Player2;

        private static List<String> m_Player1MovesList;

        private static List<String> m_Player2MovesList;

        private static eTurn m_PlayerTurn;

        private static bool v_NoPlayer1Moves;

        private static bool v_NoPlayer2Moves;

        private static eTurn m_NextPlayerTurn;

        /*
         * Creates game instance with two player types.
         */
        public Game(Player io_Player1, Player io_Player2)
        {
            m_Player1 = io_Player1;
            m_Player2 = io_Player2;
        }

        // check all adjacent cells to  specific cell
        private bool checkedValidMove(Board board, char row, char column, Player playerType)
        {

            int minusLine = row - 1;
            int minusColumn = column - 1;
            int plusLine = row + 1;
            int plusColumn = column + 1;
            // player one turn
            // TODO:
            if (Player.Ty)
            {
                // get all adjacent cells 
                eCoin neighber0 = board.getCell((char)minusLine, (char)minusColumn);
                eCoin neighber1 = board.getCell((char)minusLine, column);
                eCoin neighber2 = board.getCell((char)minusLine, (char)plusColumn);
                eCoin neighber3 = board.getCell(row, (char)minusColumn);
                eCoin neighber4 = board.getCell(row, (char)plusColumn);
                eCoin neighber5 = board.getCell((char)plusLine, (char)minusColumn);
                eCoin neighber6 = board.getCell((char)plusLine, column);
                eCoin neighber7 = board.getCell((char)plusLine, (char)plusColumn);
                // insert adjacent cells to array 
                char[] neighbers = new char[] {neighber0, neighber1 ,neighber2,neighber3 ,neighber4
                ,neighber5, neighber6, neighber7};

                // check for each adjacent cell whether need to change or not
                for (int i = 0; i < 8; i++)
                {
                    numberOfCellsNeededToChange = 1;
                    if (neighbers[i] == 'X')
                    {

                        if (i == 0)
                        {
                            bool check = checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }

                        }
                        else if (i == 1)
                        {
                            bool check = checkedValidMoveContinue(board, (char)minusLine, column, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 2)
                        {
                            bool check = checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 3)
                        {
                            bool check = checkedValidMoveContinue(board, row, (char)minusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 4)
                        {
                            bool check = checkedValidMoveContinue(board, row, (char)plusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 5)
                        {
                            bool check = checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 6)
                        {
                            bool check = checkedValidMoveContinue(board, (char)plusLine, column, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 7)
                        {
                            bool check = checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }


                    }
                }
            }
            // player two turn 
            else
            {
                char neighber0 = board.getCell((char)minusLine, (char)minusColumn);
                char neighber1 = board.getCell((char)minusLine, column);
                char neighber2 = board.getCell((char)minusLine, (char)plusColumn);
                char neighber3 = board.getCell(row, (char)minusColumn);
                char neighber4 = board.getCell(row, (char)plusColumn);
                char neighber5 = board.getCell((char)plusLine, (char)minusColumn);
                char neighber6 = board.getCell((char)plusLine, column);
                char neighber7 = board.getCell((char)plusLine, (char)plusColumn);

                char[] neighbers = new char[] {neighber0, neighber1 ,neighber2,neighber3 ,neighber4
                ,neighber5, neighber6, neighber7};

                for (int i = 0; i < 8; i++)
                {
                    numberOfCellsNeededToChange = 1;
                    if (neighbers[i] == 'O')
                    {

                        if (i == 0)
                        {
                            bool check = checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 1)
                        {
                            bool check = checkedValidMoveContinue(board, (char)minusLine, column, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 2)
                        {
                            bool check = checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 3)
                        {
                            bool check = checkedValidMoveContinue(board, row, (char)minusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 4)
                        {
                            bool check = checkedValidMoveContinue(board, row, (char)plusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 5)
                        {
                            bool check = checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 6)
                        {
                            bool check = checkedValidMoveContinue(board, (char)plusLine, column, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }
                        else if (i == 7)
                        {
                            bool check = checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                            if (check)
                            {

                                changeTheSequence = true;
                            }
                        }


                    }
                }
            }
            if (changeTheSequence == true)
            {
                return true;
            }


            return false;
        }

        // change sign for each cell in the sequence 
        private void drawAllChangeCells(Board board, char row, char column, int i)
        {

            int row1 = ((int)row);
            int column1 = ((int)column);
            // player one turn
            if (m_currentPlayer == 1)
            {
                if (i == 0)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1++;
                        column1++;
                    }

                }
                if (i == 1)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1++;

                    }

                }
                if (i == 2)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1++;
                        column1--;
                    }

                }
                if (i == 3)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        column1++;
                    }

                }
                if (i == 4)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        column1--;
                    }

                }
                if (i == 5)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1--;
                        column1++;
                    }

                }
                if (i == 6)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1--;

                    }

                }
                if (i == 7)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1--;
                        column1--;
                    }

                }
            }
            //player2
            else
            {
                if (i == 0)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1++;
                        column1++;
                    }

                }
                if (i == 1)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1++;

                    }

                }
                if (i == 2)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1++;
                        column1--;
                    }

                }
                if (i == 3)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        column1++;
                    }

                }
                if (i == 4)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        column1--;
                    }

                }
                if (i == 5)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1--;
                        column1++;
                    }

                }
                if (i == 6)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1--;

                    }

                }
                if (i == 7)
                {
                    for (int j = 0; j < numberOfCellsNeededToChange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1--;
                        column1--;
                    }

                }
            }
        }
        // if adjacent cell with opposite sign, check the sequence in a specific direction
        // if found a legal move use drawAllChangeCells method to change the sequence
        private bool checkedValidMoveContinue(Board board, char row, char column, int i)
        {

            int minusLine = row - 1;
            int minusColumn = column - 1;
            int plusLine = row + 1;
            int plusColumn = column + 1;
            // player one
            if (m_currentPlayer == 1)
            {

                if (i == 0)
                {
                    char neighber0 = board.getCell((char)minusLine, (char)minusColumn);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 1)
                {
                    char neighber0 = board.getCell((char)minusLine, column);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, column, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 2)
                {
                    char neighber0 = board.getCell((char)minusLine, (char)plusColumn);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 3)
                {
                    char neighber0 = board.getCell(row, (char)minusColumn);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)minusColumn, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 4)
                {
                    char neighber0 = board.getCell(row, (char)plusColumn);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)plusColumn, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 5)
                {
                    char neighber0 = board.getCell((char)plusLine, (char)minusColumn);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 6)
                {
                    char neighber0 = board.getCell((char)plusLine, column);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, column, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 7)
                {
                    char neighber0 = board.getCell((char)plusLine, (char)plusColumn);
                    if (neighber0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                    }
                    else if (neighber0 == 'O')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
            }
            // player two
            else
            {
                if (i == 0)
                {
                    char neighber0 = board.getCell((char)minusLine, (char)minusColumn);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 1)
                {
                    char neighber0 = board.getCell((char)minusLine, column);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, column, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 2)
                {
                    char neighber0 = board.getCell((char)minusLine, (char)plusColumn);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 3)
                {
                    char neighber0 = board.getCell(row, (char)minusColumn);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)minusColumn, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 4)
                {
                    char neighber0 = board.getCell(row, (char)plusColumn);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)plusColumn, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 5)
                {
                    char neighber0 = board.getCell((char)plusLine, (char)minusColumn);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 6)
                {
                    char neighber0 = board.getCell((char)plusLine, column);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, column, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
                if (i == 7)
                {
                    char neighber0 = board.getCell((char)plusLine, (char)plusColumn);
                    if (neighber0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                    }
                    else if (neighber0 == 'X')
                    {
                        foundLegalMove = 1;
                        drawAllChangeCells(board, row, column, i);
                        return true;
                    }

                }
            }
            if (foundLegalMove == 1)
            {
                return true;
            }
            return false;
        }

        /*
         * Moves player according to whose turn and input of move
         */
        public static void Move(eTurn playerTurn, string playerMove)
        {
            switch (playerTurn)
            {
                case eTurn.Player1:
                    break;
                case eTurn.Player2:
                    // case PC
                    break;
                case eTurn.GameOver:
                    break;
            }
            
            throw new NotImplementedException();
        }

        /* 
         * Returns game status
         */
        public static eTurn GetTurn()
        {
            v_NoPlayer1Moves = false;
            v_NoPlayer2Moves = false;
            m_PlayerTurn = m_NextPlayerTurn;

            switch (m_PlayerTurn)
            {
                // Player 1's turn
                case eTurn.Player1:

                    // Get Player 1 moves
                    m_Player1MovesList = getValidMoves(eTurn.Player1);

                    // Player 1 has no moves
                    if (!m_Player1MovesList.Any())
                    {
                        if (v_NoPlayer2Moves)
                        {
                            // Both players have no moves, return game over.
                            m_PlayerTurn = eTurn.GameOver;
                        }
                        else
                        {
                            // Switch to player 2's turn
                            v_NoPlayer1Moves = true;
                            m_PlayerTurn = eTurn.Player2;
                            goto case eTurn.Player2;
                        }
                    }
                    // Player 1 has moves in the move list
                    else
                    {
                        m_PlayerTurn = eTurn.Player1;
                    }
                    break;

                case eTurn.Player2:
                    m_Player2MovesList = getValidMoves(eTurn.Player2);
                    if (!m_Player2MovesList.Any())
                    {
                        if (v_NoPlayer1Moves)
                        {
                            m_PlayerTurn = eTurn.GameOver;
                        }
                        else
                        {
                            v_NoPlayer2Moves = true;
                            m_PlayerTurn = eTurn.Player1;
                            goto case eTurn.Player2;
                        }
                    }

                    // Player 2 has moves in the move list
                    else
                    {
                        m_PlayerTurn = eTurn.Player2;
                    }
                    break;

            }

            // Set next players turn
            if (m_PlayerTurn == eTurn.Player1)
            {
                m_NextPlayerTurn = eTurn.Player2;
            }
            else
            {
                m_NextPlayerTurn = eTurn.Player1;
            }

            return m_PlayerTurn;
        }


        private static List<string> getValidMoves(eTurn player)
        {
            throw new NotImplementedException();
        }

        /*
         * Compares valid move with list of legal moves
         */
        public static bool ValidMove(string playerMove)
        {
            throw new NotImplementedException();
        }

        /*
         * Saves whose turn it is
         */
        internal enum eTurn
        {
            Player1,
            Player2,
            GameOver
        }
    }


}
