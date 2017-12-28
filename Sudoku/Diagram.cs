using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class Diagram
    {
        const short MINVALUE = 0;
        const short MAXVALUE = 9;
        const int MAXCOLUMNS = 9;
        const int MAXROWS = 9;
        
        private Cell[,] _grid = new Cell[9, 9];

        public class InvalidEventAddArgs : EventArgs
        {
            public int Column, Row;
            public short Value;

            public InvalidEventAddArgs(int column, int row, short value)
            {
                Column = column;
                Row = row;
                Value = value;
            }
        }

        public event EventHandler<InvalidEventAddArgs> InvalidAdd;
        
        /// <summary>
        /// Raise InvalidAdd event
        /// </summary>
        /// <param name="args">Event arguments</param>
        protected virtual void OnInvalidAdd(InvalidEventAddArgs args)
        {
            InvalidAdd?.Invoke(this, args);
        }
        
        /// <summary>
        /// Creates a new instance of class Diagram.
        /// Initializes the Sudoku grid.
        /// </summary>
        public Diagram()
        {
            _grid = new Cell[9, 9];
            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                {
                    _grid[columnCounter, rowCounter] = new Cell();
                }
            }
        }

        /// <summary>
        /// Add value 
        /// </summary>
        /// <param name="column">Column</param>
        /// <param name="row">Row</param>
        /// <param name="value">Value</param>
        public void Add(int column, int row, short value)
        {
            if (_grid == null)
            {
                _grid = new Cell[MAXCOLUMNS, MAXROWS];
            }

            if (Check(value, column, row))
            {
                _grid[column, row].Value = value;
            }
            else
            {
                OnInvalidAdd(new InvalidEventAddArgs(column, row, value));
            }
        }
        
        /// <summary>
        /// Clear cell
        /// </summary>
        /// <param name="column">Column of the cell</param>
        /// <param name="row">Row of the cell</param>
        public void Remove(int column, int row)
        {
            if (_grid == null)
            {
                _grid = new Cell[MAXCOLUMNS, MAXROWS];
            }

            _grid[column, row].Value = 0;
        }

        /// <summary>
        /// Get value at cell (column, row)
        /// </summary>
        /// <param name="column">Column</param>
        /// <param name="row">Row</param>
        /// <returns>Value of grid at cell (column, row)</returns>
        public short GetValue(int column, int row)
        {
            if (_grid == null)
            {
                _grid = new Cell[MAXCOLUMNS, MAXROWS];
            }

            if (column < 0 || column > MAXCOLUMNS)
            {
                column = 0;
            }

            if (row < 0 || row > MAXROWS)
            {
                row = 0;
            }

            return _grid[column, row].Value;
        }

        /// <summary>
        /// Solve Sudoku puzzle
        /// </summary>
        public void Solve()
        {
            bool addedNew = false;

            do
            {
                addedNew = false;

                for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                {
                    addedNew = addedNew || SolveRow(rowCounter);
                }

                for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
                {
                    addedNew = addedNew || SolveColumn(columnCounter);
                }

                addedNew = addedNew || SolveSubGrid(0, 0);
                addedNew = addedNew || SolveSubGrid(0, 3);
                addedNew = addedNew || SolveSubGrid(0, 6);
                addedNew = addedNew || SolveSubGrid(3, 0);
                addedNew = addedNew || SolveSubGrid(3, 3);
                addedNew = addedNew || SolveSubGrid(3, 6);
                addedNew = addedNew || SolveSubGrid(6, 0);
                addedNew = addedNew || SolveSubGrid(6, 3);
                addedNew = addedNew || SolveSubGrid(6, 6);
            }
            while (addedNew);

            if (!Solved())
            {
                for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                    {
                        if (_grid[columnCounter, rowCounter].Value == MINVALUE)
                        {
                            List<short> possibleValues = GetPossibleValues(columnCounter, rowCounter);
                            if (possibleValues.Count == 1)
                            {
                                _grid[columnCounter, rowCounter].Value = possibleValues[0];
                                addedNew = true;
                            }
                        }
                    }
                }
            }

            if (!Solved() && addedNew)
            {
                Solve();
            }
        }

        /// <summary>
        /// Set fixed cells
        /// </summary>
        public void SetFixedCells()
        {
            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                {
                    _grid[columnCounter, rowCounter].Fixed = _grid[columnCounter, rowCounter].Value > MINVALUE;
                }
            }
        }

        /// <summary>
        /// Clear diagram
        /// </summary>
        public void Clear()
        {
            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                {
                    _grid[columnCounter, rowCounter].Value = MINVALUE;
                    _grid[columnCounter, rowCounter].Fixed = false;
                }
            }
        }

        /// <summary>
        /// Clear non-fixed cells
        /// </summary>
        public void ClearNonFixedCells()
        {
            for (int colCounter = 0; colCounter < MAXCOLUMNS; colCounter++)
            {
                for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                {
                    if (!_grid[colCounter, rowCounter].Fixed)
                    {
                        _grid[colCounter, rowCounter].Value = MINVALUE;
                    }
                }
            }
        }

        /// <summary>
        /// Determine if Sudoku puzzle is solved
        /// </summary>
        /// <returns><c>True</c> if puzzle is solved, <c>false</c> otherwise</returns>
        private bool Solved()
        {
            bool result = true;

            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
                {
                    result = result && _grid[columnCounter, rowCounter].Value > MINVALUE;

                    if (!result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get possible values for a particular grid cell
        /// </summary>
        /// <param name="column">Column</param>
        /// <param name="row">Row</param>
        /// <returns>List of possible values for the given cell</returns>
        private List<short> GetPossibleValues(int column, int row)
        {
            List<short> result = new List<short>();
            for (short value = MINVALUE + 1; value <= MAXVALUE; value++)
            {
                if (CheckColumn(value, column) && CheckRow(value, row) && CheckValueInSubGrid(value, column, row))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        /// <summary>
        /// Check possibility of filling in value in a particular diagram cell
        /// </summary>
        /// <param name="value">The value to fill in</param>
        /// <param name="column">The column</param>
        /// <param name="row">The row</param>
        /// <returns><c>True</c> if the value can be filled in in this cell, otherwise <c>false</c></returns>
        private bool Check(short value, int column, int row)
        {
            return GetValue(column, row) == MINVALUE && CheckColumn(value, column) && CheckRow(value, row) && CheckValueInSubGrid(value, column, row);
        }

        /// <summary>
        ///  Check if value is already present in the 3x3 sub grid
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="column">Number of the diagram column to check</param>
        /// <param name="row">Number of the diagram row to check</param>
        /// <returns><c>True</c> if value is not already present in the sub grid, <c>false</c> otherwise</returns>
        private bool CheckValueInSubGrid(short value, int column, int row)
        {
            int minColumnRange = (column / 3) * 3;
            int minRowRange = (row / 3) * 3;

            for (int columnCounter = minColumnRange; columnCounter < minColumnRange + 3; columnCounter++)
            {
                for (int rowCounter = minRowRange; rowCounter < minRowRange + 3; rowCounter++)
                {
                    if (value > MINVALUE && _grid[columnCounter, rowCounter].Value == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        /// <summary>
        ///  Check if value is already present in diagram row
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="row">Number of the diagram row to check</param>
        /// <returns><c>True</c> if value is not already present in the row, <c>false</c> otherwise</returns>
        private bool CheckRow(short value, int row)
        {
            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                if (value > MINVALUE && _grid[columnCounter, row].Value == value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check if value is already present in diagram row
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="column">Number of the diagram column to check</param>
        /// <returns><c>True</c> if value is not already present in the column, <c>false</c> otherwise</returns>
        private bool CheckColumn(short value, int column)
        {
            for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
            {
                if (value > MINVALUE && _grid[column, rowCounter].Value == value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Solve 3x3 sub grid. Fill in values if possible.
        /// </summary>
        /// <param name="column">Column of the sub grid</param>
        /// <param name="row">Row of the sub grid</param>
        /// <returns><c>True</c> if a value is added to the grid, <c>false</c> otherwise</returns>
        private bool SolveSubGrid(int column, int row)
        {
            bool result = false;
            Dictionary<short, List<KeyValuePair<int, int>>> candidates = GetCandidates(column, row);

            foreach (short value in candidates.Keys)
            {
                if (candidates[value].Count == 1)
                {
                    KeyValuePair<int, int> cell = candidates[value][0];
                    Add(cell.Key, cell.Value, value);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Solve row. Fill in values if possible.
        /// </summary>
        /// <param name="row">Row of the diagram</param>
        /// <returns><c>True</c> if a value is added to the grid, <c>false</c> otherwise</returns>
        private bool SolveRow(int row)
        {
            bool result = false;
            Dictionary<short, List<KeyValuePair<int, int>>> candidates = GetRowCandidates(row);

            foreach (short value in candidates.Keys)
            {
                if (candidates[value].Count == 1)
                {
                    KeyValuePair<int, int> cell = candidates[value][0];
                    Add(cell.Key, cell.Value, value);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Solve column. Fill in values if possible.
        /// </summary>
        /// <param name="row">Column of the diagram</param>
        /// <returns><c>True</c> if a value is added to the grid, <c>false</c> otherwise</returns>
        private bool SolveColumn(int column)
        {
            bool result = false;
            Dictionary<short, List<KeyValuePair<int, int>>> candidates = GetColumnCandidates(column);

            foreach (short value in candidates.Keys)
            {
                if (candidates[value].Count == 1)
                {
                    KeyValuePair<int, int> cell = candidates[value][0];
                    Add(cell.Key, cell.Value, value);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Check every 3x3 sub grid.
        /// For every missing value in the sub grid, determine in which cells the value can be placed.
        /// </summary>
        /// <param name="column">Column of the sub grid</param>
        /// <param name="row">Row of the sub grid</param>
        /// <returns>Dictionary containing for each missing value a list of cells where the value can be filled in</returns>
        private Dictionary<short, List<KeyValuePair<int, int>>> GetCandidates(int column, int row)
        {
            Dictionary<short, List<KeyValuePair<int, int>>> result = new Dictionary<short, List<KeyValuePair<int, int>>>();
            List<short> possibleValues = new List<short>();

            for (short value = MINVALUE + 1; value <= MAXVALUE; value++)
            {
                possibleValues.Add(value);
            }

            int minColumnRange = (column / 3) * 3;
            int minRowRange = (row / 3) * 3;

            for (int columnCounter = minColumnRange; columnCounter < minColumnRange + 3; columnCounter++)
            {
                for (int rowCounter = minRowRange; rowCounter < minRowRange + 3; rowCounter++)
                {
                    if (_grid[columnCounter, rowCounter].Value > MINVALUE)
                    {
                        possibleValues.Remove(_grid[columnCounter, rowCounter].Value);
                    }
                }
            }

            for (int columnCounter = minColumnRange; columnCounter < minColumnRange + 3; columnCounter++)
            {
                for (int rowCounter = minRowRange; rowCounter < minRowRange + 3; rowCounter++)
                {
                    foreach (short value in possibleValues)
                    {
                        if (Check(value, columnCounter, rowCounter))
                        {
                            if (result.ContainsKey(value))
                            {
                                result[value].Add(new KeyValuePair<int, int>(columnCounter, rowCounter));
                            }
                            else
                            {
                                result.Add(value, new List<KeyValuePair<int, int>>());
                                result[value].Add(new KeyValuePair<int, int>(columnCounter, rowCounter));
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Check row.
        /// For every missing value in the row, determine in which cells the value can be placed.
        /// </summary>
        /// <param name="row">Index of the row to check</param>
        /// <returns>Dictionary containing for each missing value a list of cells where the value can be filled in</returns>
        private Dictionary<short, List<KeyValuePair<int, int>>> GetRowCandidates(int row)
        {
            Dictionary<short, List<KeyValuePair<int, int>>> result = new Dictionary<short, List<KeyValuePair<int, int>>>();
            List<short> possibleValues = new List<short>();

            for (short value = MINVALUE + 1; value <= MAXVALUE; value++)
            {
                possibleValues.Add(value);
            }

            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                if (_grid[columnCounter, row].Value > MINVALUE)
                {
                    possibleValues.Remove(_grid[columnCounter, row].Value);
                }
            }

            for (int columnCounter = 0; columnCounter < MAXCOLUMNS; columnCounter++)
            {
                foreach (short value in possibleValues)
                {
                    if (Check(value, columnCounter, row))
                    {
                        if (result.ContainsKey(value))
                        {
                            result[value].Add(new KeyValuePair<int, int>(columnCounter, row));
                        }
                        else
                        {
                            result.Add(value, new List<KeyValuePair<int, int>>());
                            result[value].Add(new KeyValuePair<int, int>(columnCounter, row));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Check column.
        /// For every missing value in the column, determine in which cells the value can be placed.
        /// </summary>
        /// <param name="column">Index of the column to check</param>
        /// <returns>Dictionary containing for each missing value a list of cells where the value can be filled in</returns>
        private Dictionary<short, List<KeyValuePair<int, int>>> GetColumnCandidates(int column)
        {
            Dictionary<short, List<KeyValuePair<int, int>>> result = new Dictionary<short, List<KeyValuePair<int, int>>>();
            List<short> possibleValues = new List<short>();

            for (short value = MINVALUE + 1; value <= MAXVALUE; value++)
            {
                possibleValues.Add(value);
            }

            for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
            {
                if (_grid[column, rowCounter].Value > MINVALUE)
                {
                    possibleValues.Remove(_grid[column, rowCounter].Value);
                }
            }

            for (int rowCounter = 0; rowCounter < MAXROWS; rowCounter++)
            {
                foreach (short value in possibleValues)
                {
                    if (Check(value, column, rowCounter))
                    {
                        if (result.ContainsKey(value))
                        {
                            result[value].Add(new KeyValuePair<int, int>(column, rowCounter));
                        }
                        else
                        {
                            result.Add(value, new List<KeyValuePair<int, int>>());
                            result[value].Add(new KeyValuePair<int, int>(column, rowCounter));
                        }
                    }
                }
            }

            return result;
        }
    }
}