namespace Sudoku
{
    public class Cell
    {
        public short Value { get; set; }
        public bool Fixed { get; set; }

        /// <summary>
        /// Creates a new instance of class Cell
        /// </summary>
        public Cell()
        {
            Value = 0;
            Fixed = false;
        }
    }
}
