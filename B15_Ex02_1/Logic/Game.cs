using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B15_Ex02_1.Control;

namespace B15_Ex02_1.Logic
{
    /*
         * Saves whose turn it is
         */

    public enum eTurn
    {
        Player1 = 1,

        Player2 = 2,

        GameOver
    }

    public class Game
    {
        private List<Char> CellsNeededToChange = new List<Char>();

        private List<int> foundLegalMoveNeighbours = new List<int>();

        private List<int> numberOfCellsNeededToChangeArray = new List<int>();


        private List<Char> computerLegalMovesRow = new List<Char>();

        private List<Char> computerLegalMovesCol = new List<Char>();


        private int numberOfCellsNeededToChange = 1;

        private bool changeTheSequence = false;

        private Player m_Player1;

        private Player m_Player2;

        private static List<String> m_Player1MovesList;

        private static List<String> m_Player2MovesList;

        private static eTurn m_PlayerTurn = eTurn.Player1;

        private static bool v_NoPlayer1Moves;

        private static bool v_NoPlayer2Moves;

        private static eTurn m_NextPlayerTurn;

        private Board m_Board;

        /*
         * Creates game instance with two player types.
         */

        public Game(Player io_Player1, Player io_Player2, Board board)
        {
            m_Player1 = io_Player1;
            m_Player2 = io_Player2;
            m_Board = board;
            m_NextPlayerTurn = eTurn.Player1;
        }

        public List<string> PcMovesList2
        {
            get { return m_Player2MovesList; }
        }
        public List<string> PcMovesList
        {
            get { return m_Player1MovesList; }
        }
        //TODO: delete two methods up and put this
        /*
         * public List<string> PcMovesList
        {
            get { return m_Player2MovesList; }
        }
         */

        // check all adjacent cells to  specific cell


        /* 
         * Returns game status
         */

        public eTurn GetTurn()
        {
            v_NoPlayer1Moves = false;
            v_NoPlayer2Moves = false;
            m_PlayerTurn = m_NextPlayerTurn;

            switch (m_PlayerTurn)
            {
                // Player 1's turn
                case eTurn.Player1:

                    // Get Player 1 moves
                    m_Player1MovesList = validCells(eTurn.Player1);

                    // Player 1 has no moves
                    if (!m_Player1MovesList.Any())
                    {
                        //View call
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
                    m_Player2MovesList = validCells(eTurn.Player2);
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
                            goto case eTurn.Player1;
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
            m_NextPlayerTurn = (m_PlayerTurn == eTurn.Player1) ? eTurn.Player2 : eTurn.Player1;

            return m_PlayerTurn;
        }


        private static List<string> getValidMoves(eTurn player)
        {
            throw new NotImplementedException();
        }

        public void checkAndFillListValidMoves()
        {
            if (m_Board.Size == 8)
            {
                
                for (int i = 49; i < 57; i++)
                {
                    
                    for (int j = 65; j < 73; j++)
                    {
                        if (checkedValidCell(m_Board, (char)i, (char)j) && checkedValidMove(m_Board, (char)i, (char)j))
                        {
                            computerLegalMovesRow.Add((char)i);
                            computerLegalMovesCol.Add((char)j);

                            numberOfCellsNeededToChangeArray.Clear();
                            foundLegalMoveNeighbours.Clear();
                            changeTheSequence = false;
                            CellsNeededToChange.Clear();
                        }
                    }
                }
                CellsNeededToChange.Clear();
                foundLegalMoveNeighbours.Clear();
                numberOfCellsNeededToChangeArray.Clear();
                changeTheSequence = false;
            }
            else
            {
                for (int i = 49; i < 55; i++)
                {
                    for (int j = 65; j < 71; j++)
                    {
                        if (checkedValidCell(m_Board, (char)i, (char)j) && checkedValidMove(m_Board, (char)i, (char)j))
                        {
                            computerLegalMovesRow.Add((char)i);
                            computerLegalMovesCol.Add((char)j);

                            numberOfCellsNeededToChangeArray.Clear();
                            foundLegalMoveNeighbours.Clear();
                            changeTheSequence = false;
                            CellsNeededToChange.Clear();
                        }
                    }
                }
                CellsNeededToChange.Clear();
                foundLegalMoveNeighbours.Clear();
                numberOfCellsNeededToChangeArray.Clear();
                changeTheSequence = false;
            }
        }

        public List<string> validCells(eTurn curPlayer)
        {
            m_PlayerTurn = curPlayer;
            string cell = "";
            List<string> validMoveList = new List<string>();
            checkAndFillListValidMoves();
            for (int i = 0; i < computerLegalMovesRow.Count; i++)
            {
                cell += (computerLegalMovesCol[i]);
                cell += (computerLegalMovesRow[i]);
                validMoveList.Add(cell);
                cell = "";
            }
            computerLegalMovesRow.Clear();
            computerLegalMovesCol.Clear();
            return validMoveList;
        }

        /*
         * Compares valid move with list of legal moves
         */

        public static bool ValidMove(string playerMove, eTurn player)
        {
            return (player == eTurn.Player1)
                       ? m_Player1MovesList.Contains(playerMove)
                       : m_Player2MovesList.Contains(playerMove);
        }
        public void Move(eTurn curPlayer, string cell)
        {
            m_PlayerTurn = curPlayer;
            Ex02.ConsoleUtils.Screen.Clear();
            char row;
            char column;
            m_Board.drawBoard(m_Board);


            System.Console.WriteLine();


            row = cell[1];
            column = cell[0];
            /*
            while (row < 49 || row > 56 || column < 65 || column > 72)
            {
                System.Console.WriteLine("invalid input, please enter row and column in this form 1A:");
                cell = System.Console.ReadLine();

                row = cell[1];
                column = cell[0];

            }
            */
            if (checkedValidCell(m_Board, row, column) && checkedValidMove(m_Board, row, column))
            {
                if (curPlayer == eTurn.Player1)
                {
                    m_Board.setCell('O', row, column);
                    for (int i = 0, j = 0; i < foundLegalMoveNeighbours.Count; i++, j += 2)
                    {
                        char cellRowToChange = CellsNeededToChange[j];
                        char cellColumnToChange = CellsNeededToChange[j + 1];
                        int whichNeighborMove = foundLegalMoveNeighbours[i];
                        int numberOfCellsToChange = numberOfCellsNeededToChangeArray[i];
                        drawAllChangeCells(
                            m_Board,
                            cellRowToChange,
                            cellColumnToChange,
                            whichNeighborMove,
                            numberOfCellsToChange);
                        m_Player1.PlayerPoints = m_Player1.PlayerPoints + numberOfCellsToChange;
                        m_Player2.PlayerPoints = m_Player2.PlayerPoints - numberOfCellsToChange;

                    }
                    m_Player1.PlayerPoints++;
                }
                else
                {
                    m_Board.setCell('X', row, column);
                    for (int i = 0, j = 0; i < foundLegalMoveNeighbours.Count; i++, j += 2)
                    {
                        char cellRowToChange = CellsNeededToChange[j];
                        char cellColumnToChange = CellsNeededToChange[j + 1];
                        int whichNeighborMove = foundLegalMoveNeighbours[i];
                        int numberOfCellsToChange = numberOfCellsNeededToChangeArray[i];
                        drawAllChangeCells(
                            m_Board,
                            cellRowToChange,
                            cellColumnToChange,
                            whichNeighborMove,
                            numberOfCellsToChange);
                        m_Player2.PlayerPoints = m_Player2.PlayerPoints + numberOfCellsToChange;
                        m_Player1.PlayerPoints = m_Player1.PlayerPoints - numberOfCellsToChange;

                    }

                    m_Player2.PlayerPoints++;
                }

                CellsNeededToChange.Clear();
                foundLegalMoveNeighbours.Clear();
                numberOfCellsNeededToChangeArray.Clear();
                changeTheSequence = false;
                Ex02.ConsoleUtils.Screen.Clear();
                m_Board.drawBoard(m_Board);
                System.Console.WriteLine();
            }
            
        }
        // check all adjacent cells to  specific cell
        private bool checkedValidMove(Board board, char row, char column)
        {

            int minusLine = row - 1;
            int minusColumn = column - 1;
            int plusLine = row + 1;
            int plusColumn = column + 1;
            // player one turn
            if (m_PlayerTurn == eTurn.Player1)
            {
                // get all adjacent cells 
                char neighbor0 = board.getCell((char)minusLine, (char)minusColumn);
                char neighbor1 = board.getCell((char)minusLine, column);
                char neighbor2 = board.getCell((char)minusLine, (char)plusColumn);
                char neighbor3 = board.getCell(row, (char)minusColumn);
                char neighbor4 = board.getCell(row, (char)plusColumn);
                char neighbor5 = board.getCell((char)plusLine, (char)minusColumn);
                char neighbor6 = board.getCell((char)plusLine, column);
                char neighbor7 = board.getCell((char)plusLine, (char)plusColumn);
                // insert adjacent cells to array 
                char[] neighbers = new char[] {neighbor0, neighbor1 ,neighbor2,neighbor3 ,neighbor4
                ,neighbor5, neighbor6, neighbor7};

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
                char neighbor0 = board.getCell((char)minusLine, (char)minusColumn);
                char neighbor1 = board.getCell((char)minusLine, column);
                char neighbor2 = board.getCell((char)minusLine, (char)plusColumn);
                char neighbor3 = board.getCell(row, (char)minusColumn);
                char neighbor4 = board.getCell(row, (char)plusColumn);
                char neighbor5 = board.getCell((char)plusLine, (char)minusColumn);
                char neighbor6 = board.getCell((char)plusLine, column);
                char neighbor7 = board.getCell((char)plusLine, (char)plusColumn);

                char[] neighbers = new char[] {neighbor0, neighbor1 ,neighbor2,neighbor3 ,neighbor4
                ,neighbor5, neighbor6, neighbor7};

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
        private void drawAllChangeCells(Board board, char row, char column, int i, int numTochange)
        {

            int row1 = ((int)row);
            int column1 = ((int)column);
            // player one turn
            if (m_PlayerTurn == eTurn.Player1)
            {
                if (i == 0)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1++;
                        column1++;
                    }

                }
                if (i == 1)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1++;

                    }

                }
                if (i == 2)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1++;
                        column1--;
                    }

                }
                if (i == 3)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        column1++;
                    }

                }
                if (i == 4)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        column1--;
                    }

                }
                if (i == 5)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1--;
                        column1++;
                    }

                }
                if (i == 6)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('O', (char)row1, (char)column1);
                        row1--;

                    }

                }
                if (i == 7)
                {
                    for (int j = 0; j < numTochange; j++)
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
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1++;
                        column1++;
                    }

                }
                if (i == 1)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1++;

                    }

                }
                if (i == 2)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1++;
                        column1--;
                    }

                }
                if (i == 3)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        column1++;
                    }

                }
                if (i == 4)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        column1--;
                    }

                }
                if (i == 5)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1--;
                        column1++;
                    }

                }
                if (i == 6)
                {
                    for (int j = 0; j < numTochange; j++)
                    {
                        board.setCell('X', (char)row1, (char)column1);
                        row1--;

                    }

                }
                if (i == 7)
                {
                    for (int j = 0; j < numTochange; j++)
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
            if (m_PlayerTurn == eTurn.Player1)
            {

                if (i == 0)
                {
                    char neighbor0 = board.getCell((char)minusLine, (char)minusColumn);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;

                        checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(0);



                        return true;
                    }

                }
                if (i == 1)
                {
                    char neighbor0 = board.getCell((char)minusLine, column);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, column, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(1);



                        return true;
                    }

                }
                if (i == 2)
                {
                    char neighbor0 = board.getCell((char)minusLine, (char)plusColumn);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(2);



                        return true;
                    }

                }
                if (i == 3)
                {
                    char neighbor0 = board.getCell(row, (char)minusColumn);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)minusColumn, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(3);

                        return true;
                    }

                }
                if (i == 4)
                {
                    char neighbor0 = board.getCell(row, (char)plusColumn);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)plusColumn, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(4);


                        return true;
                    }

                }
                if (i == 5)
                {
                    char neighbor0 = board.getCell((char)plusLine, (char)minusColumn);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(5);


                        return true;
                    }

                }
                if (i == 6)
                {
                    char neighbor0 = board.getCell((char)plusLine, column);
                    if (neighbor0 == 'X')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, column, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(6);

                        return true;
                    }

                }
                if (i == 7)
                {
                    char neighbor0 = board.getCell((char)plusLine, (char)plusColumn);
                    if (neighbor0 == 'X')
                    {

                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                    }
                    else if (neighbor0 == 'O')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(7);


                        return true;
                    }

                }
            }
            // player two
            else
            {
                if (i == 0)
                {
                    char neighbor0 = board.getCell((char)minusLine, (char)minusColumn);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(0);



                        return true;
                    }

                }
                if (i == 1)
                {
                    char neighbor0 = board.getCell((char)minusLine, column);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, column, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(1);


                        return true;
                    }

                }
                if (i == 2)
                {
                    char neighbor0 = board.getCell((char)minusLine, (char)plusColumn);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(2);

                        ;

                        return true;
                    }

                }
                if (i == 3)
                {
                    char neighbor0 = board.getCell(row, (char)minusColumn);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)minusColumn, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(3);



                        return true;
                    }

                }
                if (i == 4)
                {
                    char neighbor0 = board.getCell(row, (char)plusColumn);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, row, (char)plusColumn, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(4);

                        return true;
                    }

                }
                if (i == 5)
                {
                    char neighbor0 = board.getCell((char)plusLine, (char)minusColumn);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(5);



                        return true;
                    }

                }
                if (i == 6)
                {
                    char neighbor0 = board.getCell((char)plusLine, column);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, column, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(6);

                        return true;
                    }

                }
                if (i == 7)
                {
                    char neighbor0 = board.getCell((char)plusLine, (char)plusColumn);
                    if (neighbor0 == 'O')
                    {
                        numberOfCellsNeededToChange++;
                        checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                    }
                    else if (neighbor0 == 'X')
                    {
                        CellsNeededToChange.Add(row);
                        CellsNeededToChange.Add(column);
                        numberOfCellsNeededToChangeArray.Add(numberOfCellsNeededToChange);
                        numberOfCellsNeededToChange = 1;
                        foundLegalMoveNeighbours.Add(7);

                        return true;
                    }

                }
            }
            if (foundLegalMoveNeighbours.Count != 0)
            {
                return true;
            }
            return false;
        }

        public static bool checkedValidCell(Board board, char row, char column)
        {

            while (board.getCell(row, column) == 'O' || board.getCell(row, column) == 'X')
            {
                return false;

            }


            return true;
        }

  
    }
}
