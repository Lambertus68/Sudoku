using Sudoku;
using System;
using System.Text;

namespace SudokuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Diagram diagram = new Diagram();
            diagram.InvalidAdd += Diagram_InvalidAdd;
            
            diagram.Add(0, 2, 1);
            diagram.Add(0, 4, 6);
            diagram.Add(0, 5, 9);
            diagram.Add(0, 7, 5);
            diagram.Add(1, 2, 2);
            diagram.Add(1, 5, 8);
            diagram.Add(1, 7, 4);
            diagram.Add(2, 6, 7);
            diagram.Add(2, 8, 1);
            diagram.Add(3, 1, 1);
            diagram.Add(3, 4, 5);
            diagram.Add(3, 6, 3);
            diagram.Add(3, 7, 8);
            diagram.Add(4, 2, 7);
            diagram.Add(4, 6, 6);
            diagram.Add(5, 1, 6);
            diagram.Add(5, 2, 3);
            diagram.Add(5, 4, 8);
            diagram.Add(5, 7, 9);
            diagram.Add(6, 0, 7);
            diagram.Add(6, 2, 6);
            diagram.Add(7, 1, 5);
            diagram.Add(7, 3, 9);
            diagram.Add(7, 6, 4);
            diagram.Add(8, 1, 4);
            diagram.Add(8, 3, 3);
            diagram.Add(8, 4, 7);
            diagram.Add(8, 6, 5);
            
            diagram.Solve();

            StringBuilder stringBuilder = new StringBuilder();

            for (int rowCounter = 0; rowCounter < 9; rowCounter++)
            {
                if (rowCounter % 3 == 0)
                {
                    stringBuilder.Append("______________________");
                    stringBuilder.Append(Environment.NewLine);
                }
                for (int columnCounter = 0; columnCounter < 9; columnCounter++)
                {
                    if (columnCounter % 3 == 0)
                    {
                        stringBuilder.Append("|");
                    }
                    stringBuilder.Append(diagram.GetValue(columnCounter, rowCounter) + " ");
                }
                stringBuilder.Append("|");
                stringBuilder.Append(Environment.NewLine);
            }
            stringBuilder.Append("______________________");
            stringBuilder.Append(Environment.NewLine);

            Console.WriteLine(stringBuilder.ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// When an invalid value is added to the diagram, show error message.
        /// </summary>
        /// <param name="sender">The diagram that raised the event</param>
        /// <param name="e">The event arguments</param>
        private static void Diagram_InvalidAdd(object sender, Diagram.InvalidEventAddArgs e)
        {
            Console.WriteLine(string.Format("Diagram {0}: Cannot insert value {1} in cell ({2}, {3})", sender.ToString(), e.Value, e.Column, e.Row));
        }
    }
}
