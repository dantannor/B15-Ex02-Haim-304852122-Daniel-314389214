// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Game.cs" company="">
//   
// </copyright>
// <summary>
//   The e turn.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace B15_Ex02_1.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*
         * Saves whose turn it is
         */

    /// <summary>
    /// The e turn.
    /// </summary>
    public enum eTurn
    {
        /// <summary>
        /// The player 1.
        /// </summary>
        Player1 = 1, 

        /// <summary>
        /// The player 2.
        /// </summary>
        Player2 = 2, 

        /// <summary>
        /// The game over.
        /// </summary>
        GameOver, 

        /// <summary>
        /// The no transfer.
        /// </summary>
        NoTransfer
    }

    /// <summary>
    /// The game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The checked valid cell.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool checkedValidCell(Board board, char row, char column)
        {
            while (board.getCell(row, column) == 'O' || board.getCell(row, column) == 'X')
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The m_ next player turn.
        /// </summary>
        private static eTurn m_NextPlayerTurn;

        /// <summary>
        /// The m_ player 1 moves list.
        /// </summary>
        private static List<string> m_Player1MovesList;

        /// <summary>
        /// The m_ player 2 moves list.
        /// </summary>
        private static List<string> m_Player2MovesList;

        /// <summary>
        /// The m_ player turn.
        /// </summary>
        private static eTurn m_PlayerTurn = eTurn.Player1;

        /// <summary>
        /// The v_ no player 1 moves.
        /// </summary>
        private static bool v_NoPlayer1Moves;

        /// <summary>
        /// The v_ no player 2 moves.
        /// </summary>
        private static bool v_NoPlayer2Moves;

        /// <summary>
        /// The cells needed to change.
        /// </summary>
        private List<char> CellsNeededToChange = new List<char>();

        /// <summary>
        /// The found legal move neighbours.
        /// </summary>
        private List<int> foundLegalMoveNeighbours = new List<int>();

        /// <summary>
        /// The number of cells needed to change array.
        /// </summary>
        private List<int> numberOfCellsNeededToChangeArray = new List<int>();

        /// <summary>
        /// The computer legal moves row.
        /// </summary>
        private List<char> computerLegalMovesRow = new List<char>();

        /// <summary>
        /// The computer legal moves col.
        /// </summary>
        private List<char> computerLegalMovesCol = new List<char>();

        /// <summary>
        /// The number of cells needed to change.
        /// </summary>
        private int numberOfCellsNeededToChange = 1;

        /// <summary>
        /// The change the sequence.
        /// </summary>
        private bool changeTheSequence;

        /// <summary>
        /// The m_ player 1.
        /// </summary>
        private Player m_Player1;

        /// <summary>
        /// The m_ player 2.
        /// </summary>
        private Player m_Player2;

        /// <summary>
        /// The m_ board.
        /// </summary>
        private Board m_Board;

        /*
         * Creates game instance with two player types.
         */

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="io_Player1">
        /// The io_ player 1.
        /// </param>
        /// <param name="io_Player2">
        /// The io_ player 2.
        /// </param>
        /// <param name="board">
        /// The board.
        /// </param>
        public Game(Player io_Player1, Player io_Player2, Board board)
        {
            m_Player1 = io_Player1;
            m_Player2 = io_Player2;
            m_Board = board;
            m_NextPlayerTurn = eTurn.Player1;
        }

        /// <summary>
        /// The turn transfer.
        /// </summary>
        /// <returns>
        /// The <see cref="eTurn"/>.
        /// </returns>
        public static eTurn TurnTransfer()
        {
            eTurn turn;
            if (v_NoPlayer1Moves && v_NoPlayer2Moves == false)
            {
                turn = eTurn.Player1;
            }
            else if (v_NoPlayer2Moves && v_NoPlayer1Moves == false)
            {
                turn = eTurn.Player2;
            }
            else
            {
                turn = eTurn.NoTransfer;
            }

            return turn;
        }

        /// <summary>
        /// The valid move.
        /// </summary>
        /// <param name="playerMove">
        /// The player move.
        /// </param>
        /// <param name="player">
        /// The player.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ValidMove(string playerMove, eTurn player)
        {
            return (player == eTurn.Player1)
                       ? m_Player1MovesList.Contains(playerMove)
                       : m_Player2MovesList.Contains(playerMove);
        }

        /// <summary>
        /// Gets the pc moves list 2.
        /// </summary>
        public List<string> PcMovesList2
        {
            get
            {
                return m_Player2MovesList;
            }
        }

        /// <summary>
        /// Gets the pc moves list.
        /// </summary>
        public List<string> PcMovesList
        {
            get
            {
                return m_Player1MovesList;
            }
        }

        // TODO: delete two methods up and put this
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

        /// <summary>
        /// The get turn.
        /// </summary>
        /// <returns>
        /// The <see cref="eTurn"/>.
        /// </returns>
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
                        // View call
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
                    else
                    {
                        // Player 1 has moves in the move list
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
                    else
                    {
                        // Player 2 has moves in the move list
                        m_PlayerTurn = eTurn.Player2;
                    }

                    break;
            }

            // Set next players turn
            m_NextPlayerTurn = (m_PlayerTurn == eTurn.Player1) ? eTurn.Player2 : eTurn.Player1;

            return m_PlayerTurn;
        }

        /// <summary>
        /// The check and fill list valid moves.
        /// </summary>
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

        /// <summary>
        /// The valid cells.
        /// </summary>
        /// <param name="curPlayer">
        /// The cur player.
        /// </param>
        /// <returns>
        /// The List of valid moves.
        /// </returns>
        public List<string> validCells(eTurn curPlayer)
        {
            m_PlayerTurn = curPlayer;
            string cell = string.Empty;
            List<string> validMoveList = new List<string>();
            checkAndFillListValidMoves();
            for (int i = 0; i < computerLegalMovesRow.Count; i++)
            {
                cell += computerLegalMovesCol[i];
                cell += computerLegalMovesRow[i];
                validMoveList.Add(cell);
                cell = string.Empty;
            }

            computerLegalMovesRow.Clear();
            computerLegalMovesCol.Clear();
            return validMoveList;
        }

        /// <summary>
        /// The move.
        /// </summary>
        /// <param name="curPlayer">
        /// The cur player.
        /// </param>
        /// <param name="cell">
        /// The cell.
        /// </param>
        public void Move(eTurn curPlayer, string cell)
        {
            m_PlayerTurn = curPlayer;

            // Ex02.ConsoleUtils.Screen.Clear();
            char row;
            char column;

            // View.DrawBoard(m_Board);
            Console.WriteLine();

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

                // Ex02.ConsoleUtils.Screen.Clear();
                // View.DrawBoard(m_Board);
                // System.Console.WriteLine();
            }
        }

        // check all adjacent cells to  specific cell

        /// <summary>
        /// The checked valid move.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool checkedValidMove(Board board, char row, char column)
        {
            int minusLine = row - 1;
            int minusColumn = column - 1;
            int plusLine = row + 1;
            int plusColumn = column + 1;

            // player one turn
            switch (m_PlayerTurn)
            {
                case eTurn.Player1:
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
                        char[] neighbers =
                            {
                                neighbor0, neighbor1, neighbor2, neighbor3, neighbor4, neighbor5, neighbor6, 
                                neighbor7
                            };

                        // check for each adjacent cell whether need to change or not
                        for (int i = 0; i < 8; i++)
                        {
                            this.numberOfCellsNeededToChange = 1;
                            if (neighbers[i] == 'X')
                            {
                                if (i == 0)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 1)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)minusLine, column, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 2)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 3)
                                {
                                    bool check = this.checkedValidMoveContinue(board, row, (char)minusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 4)
                                {
                                    bool check = this.checkedValidMoveContinue(board, row, (char)plusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 5)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 6)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)plusLine, column, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 7)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                            }
                        }
                    }

                    break;
                default:
                    {
                        char neighbor0 = board.getCell((char)minusLine, (char)minusColumn);
                        char neighbor1 = board.getCell((char)minusLine, column);
                        char neighbor2 = board.getCell((char)minusLine, (char)plusColumn);
                        char neighbor3 = board.getCell(row, (char)minusColumn);
                        char neighbor4 = board.getCell(row, (char)plusColumn);
                        char neighbor5 = board.getCell((char)plusLine, (char)minusColumn);
                        char neighbor6 = board.getCell((char)plusLine, column);
                        char neighbor7 = board.getCell((char)plusLine, (char)plusColumn);

                        char[] neighbers =
                            {
                                neighbor0, neighbor1, neighbor2, neighbor3, neighbor4, neighbor5, neighbor6, 
                                neighbor7
                            };

                        for (int i = 0; i < 8; i++)
                        {
                            this.numberOfCellsNeededToChange = 1;
                            if (neighbers[i] == 'O')
                            {
                                if (i == 0)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)minusLine, (char)minusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 1)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)minusLine, column, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 2)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)minusLine, (char)plusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 3)
                                {
                                    bool check = this.checkedValidMoveContinue(board, row, (char)minusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 4)
                                {
                                    bool check = this.checkedValidMoveContinue(board, row, (char)plusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 5)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)plusLine, (char)minusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 6)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)plusLine, column, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                                else if (i == 7)
                                {
                                    bool check = this.checkedValidMoveContinue(board, (char)plusLine, (char)plusColumn, i);
                                    if (check)
                                    {
                                        this.changeTheSequence = true;
                                    }
                                }
                            }
                        }
                    }

                    break;
            }

            if (this.changeTheSequence)
            {
                return true;
            }

            return false;
        }

        // change sign for each cell in the sequence 

        /// <summary>
        /// The draw all change cells.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <param name="numTochange">
        /// The num tochange.
        /// </param>
        private void drawAllChangeCells(Board board, char row, char column, int i, int numTochange)
        {
            int row1 = row;
            int column1 = column;

            // player one turn
            switch (m_PlayerTurn)
            {
                case eTurn.Player1:
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

                    break;
                default:
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

                    break;
            }
        }

        // if adjacent cell with opposite sign, check the sequence in a specific direction
        // if found a legal move use drawAllChangeCells method to change the sequence

        /// <summary>
        /// The checked valid move continue.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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
            else
            {
                // player two
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
    }
}