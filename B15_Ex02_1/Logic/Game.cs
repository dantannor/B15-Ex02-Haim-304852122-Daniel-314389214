using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    class Game
    {
        private int foundLegalMove = 0;
        private int numberOfCellsNeededToChange = 1;
        private bool changeTheSequence = false;

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

    }
}
