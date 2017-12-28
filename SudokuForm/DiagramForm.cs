using Sudoku;
using System;
using System.Windows.Forms;

namespace SudokuForm
{
    public partial class DiagramForm : Form
    {
        Diagram _sudokuDiagram = new Diagram();
        
        public DiagramForm()
        {
            InitializeComponent();
            _sudokuDiagram.InvalidAdd += _sudokuDiagram_InvalidAdd;
        }

        private void _sudokuDiagram_InvalidAdd(object sender, Diagram.InvalidEventAddArgs e)
        {
            MessageBox.Show(string.Format("Invalid value: {0}", e.Value), "Error");
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            short value = 0;
            short column = 0;
            short row = 0;

            TextBox textBox = sender as TextBox;

            if (textBox == textBox_0_0 || textBox == textBox_0_1 || textBox == textBox_0_2 || textBox == textBox_0_3 || textBox == textBox_0_4 || textBox == textBox_0_5 || textBox == textBox_0_6 || textBox == textBox_0_7 || textBox == textBox_0_8)
            {
                column = 0;
            }
            else if (textBox == textBox_1_0 || textBox == textBox_1_1 || textBox == textBox_1_2 || textBox == textBox_1_3 || textBox == textBox_1_4 || textBox == textBox_1_5 || textBox == textBox_1_6 || textBox == textBox_1_7 || textBox == textBox_1_8)
            {
                column = 1;
            }
            else if (textBox == textBox_2_0 || textBox == textBox_2_1 || textBox == textBox_2_2 || textBox == textBox_2_3 || textBox == textBox_2_4 || textBox == textBox_2_5 || textBox == textBox_2_6 || textBox == textBox_2_7 || textBox == textBox_2_8)
            {
                column = 2;
            }
            else if (textBox == textBox_3_0 || textBox == textBox_3_1 || textBox == textBox_3_2 || textBox == textBox_3_3 || textBox == textBox_3_4 || textBox == textBox_3_5 || textBox == textBox_3_6 || textBox == textBox_3_7 || textBox == textBox_3_8)
            {
                column = 3;
            }
            else if (textBox == textBox_4_0 || textBox == textBox_4_1 || textBox == textBox_4_2 || textBox == textBox_4_3 || textBox == textBox_4_4 || textBox == textBox_4_5 || textBox == textBox_4_6 || textBox == textBox_4_7 || textBox == textBox_4_8)
            {
                column = 4;
            }
            else if (textBox == textBox_5_0 || textBox == textBox_5_1 || textBox == textBox_5_2 || textBox == textBox_5_3 || textBox == textBox_5_4 || textBox == textBox_5_5 || textBox == textBox_5_6 || textBox == textBox_5_7 || textBox == textBox_5_8)
            {
                column = 5;
            }
            else if (textBox == textBox_6_0 || textBox == textBox_6_1 || textBox == textBox_6_2 || textBox == textBox_6_3 || textBox == textBox_6_4 || textBox == textBox_6_5 || textBox == textBox_6_6 || textBox == textBox_6_7 || textBox == textBox_6_8)
            {
                column = 6;
            }
            else if (textBox == textBox_7_0 || textBox == textBox_7_1 || textBox == textBox_7_2 || textBox == textBox_7_3 || textBox == textBox_7_4 || textBox == textBox_7_5 || textBox == textBox_7_6 || textBox == textBox_7_7 || textBox == textBox_7_8)
            {
                column = 7;
            }
            else if (textBox == textBox_8_0 || textBox == textBox_8_1 || textBox == textBox_8_2 || textBox == textBox_8_3 || textBox == textBox_8_4 || textBox == textBox_8_5 || textBox == textBox_8_6 || textBox == textBox_8_7 || textBox == textBox_8_8)
            {
                column = 8;
            }

            if (textBox == textBox_0_0 || textBox == textBox_1_0 || textBox == textBox_2_0 || textBox == textBox_3_0 || textBox == textBox_4_0 || textBox == textBox_5_0 || textBox == textBox_6_0 || textBox == textBox_7_0 || textBox == textBox_8_0)
            {
                row = 0;
            }
            else if (textBox == textBox_0_1 || textBox == textBox_1_1 || textBox == textBox_2_1 || textBox == textBox_3_1 || textBox == textBox_4_1 || textBox == textBox_5_1 || textBox == textBox_6_1 || textBox == textBox_7_1 || textBox == textBox_8_1)
            {
                row = 1;
            }
            else if (textBox == textBox_0_2 || textBox == textBox_1_2 || textBox == textBox_2_2 || textBox == textBox_3_2 || textBox == textBox_4_2 || textBox == textBox_5_2 || textBox == textBox_6_2 || textBox == textBox_7_2 || textBox == textBox_8_2)
            {
                row = 2;
            }
            else if (textBox == textBox_0_3 || textBox == textBox_1_3 || textBox == textBox_2_3 || textBox == textBox_3_3 || textBox == textBox_4_3 || textBox == textBox_5_3 || textBox == textBox_6_3 || textBox == textBox_7_3 || textBox == textBox_8_3)
            {
                row = 3;
            }
            else if (textBox == textBox_0_4 || textBox == textBox_1_4 || textBox == textBox_2_4 || textBox == textBox_3_4 || textBox == textBox_4_4 || textBox == textBox_5_4 || textBox == textBox_6_4 || textBox == textBox_7_4 || textBox == textBox_8_4)
            {
                row = 4;
            }
            else if (textBox == textBox_0_5 || textBox == textBox_1_5 || textBox == textBox_2_5 || textBox == textBox_3_5 || textBox == textBox_4_5 || textBox == textBox_5_5 || textBox == textBox_6_5 || textBox == textBox_7_5 || textBox == textBox_8_5)
            {
                row = 5;
            }
            else if (textBox == textBox_0_6 || textBox == textBox_1_6 || textBox == textBox_2_6 || textBox == textBox_3_6 || textBox == textBox_4_6 || textBox == textBox_5_6 || textBox == textBox_6_6 || textBox == textBox_7_6 || textBox == textBox_8_6)
            {
                row = 6;
            }
            else if (textBox == textBox_0_7 || textBox == textBox_1_7 || textBox == textBox_2_7 || textBox == textBox_3_7 || textBox == textBox_4_7 || textBox == textBox_5_7 || textBox == textBox_6_7 || textBox == textBox_7_7 || textBox == textBox_8_7)
            {
                row = 7;
            }
            else if (textBox == textBox_0_8 || textBox == textBox_1_8 || textBox == textBox_2_8 || textBox == textBox_3_8 || textBox == textBox_4_8 || textBox == textBox_5_8 || textBox == textBox_6_8 || textBox == textBox_7_8 || textBox == textBox_8_8)
            {
                row = 8;
            }

            if (short.TryParse(textBox.Text, out value) && value > 0 && value < 10)
            {
                _sudokuDiagram.Add(column, row, value);
            }
            else
            {
                _sudokuDiagram.Remove(column, row);
                textBox.Text = string.Empty;
            }
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            _sudokuDiagram.InvalidAdd -= _sudokuDiagram_InvalidAdd;
            _sudokuDiagram.Solve();
            UpdateDiagram();
            _sudokuDiagram.InvalidAdd += _sudokuDiagram_InvalidAdd;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _sudokuDiagram.Clear();
            UpdateDiagram();
        }
        
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _sudokuDiagram.ClearNonFixedCells();
            UpdateDiagram();
        }

        private void UpdateDiagram()
        {
            textBox_0_0.Text = _sudokuDiagram.GetValue(0, 0).ToString();
            textBox_0_1.Text = _sudokuDiagram.GetValue(0, 1).ToString();
            textBox_0_2.Text = _sudokuDiagram.GetValue(0, 2).ToString();
            textBox_0_3.Text = _sudokuDiagram.GetValue(0, 3).ToString();
            textBox_0_4.Text = _sudokuDiagram.GetValue(0, 4).ToString();
            textBox_0_5.Text = _sudokuDiagram.GetValue(0, 5).ToString();
            textBox_0_6.Text = _sudokuDiagram.GetValue(0, 6).ToString();
            textBox_0_7.Text = _sudokuDiagram.GetValue(0, 7).ToString();
            textBox_0_8.Text = _sudokuDiagram.GetValue(0, 8).ToString();
            textBox_1_0.Text = _sudokuDiagram.GetValue(1, 0).ToString();
            textBox_1_1.Text = _sudokuDiagram.GetValue(1, 1).ToString();
            textBox_1_2.Text = _sudokuDiagram.GetValue(1, 2).ToString();
            textBox_1_3.Text = _sudokuDiagram.GetValue(1, 3).ToString();
            textBox_1_4.Text = _sudokuDiagram.GetValue(1, 4).ToString();
            textBox_1_5.Text = _sudokuDiagram.GetValue(1, 5).ToString();
            textBox_1_6.Text = _sudokuDiagram.GetValue(1, 6).ToString();
            textBox_1_7.Text = _sudokuDiagram.GetValue(1, 7).ToString();
            textBox_1_8.Text = _sudokuDiagram.GetValue(1, 8).ToString();
            textBox_2_0.Text = _sudokuDiagram.GetValue(2, 0).ToString();
            textBox_2_1.Text = _sudokuDiagram.GetValue(2, 1).ToString();
            textBox_2_2.Text = _sudokuDiagram.GetValue(2, 2).ToString();
            textBox_2_3.Text = _sudokuDiagram.GetValue(2, 3).ToString();
            textBox_2_4.Text = _sudokuDiagram.GetValue(2, 4).ToString();
            textBox_2_5.Text = _sudokuDiagram.GetValue(2, 5).ToString();
            textBox_2_6.Text = _sudokuDiagram.GetValue(2, 6).ToString();
            textBox_2_7.Text = _sudokuDiagram.GetValue(2, 7).ToString();
            textBox_2_8.Text = _sudokuDiagram.GetValue(2, 8).ToString();
            textBox_3_0.Text = _sudokuDiagram.GetValue(3, 0).ToString();
            textBox_3_1.Text = _sudokuDiagram.GetValue(3, 1).ToString();
            textBox_3_2.Text = _sudokuDiagram.GetValue(3, 2).ToString();
            textBox_3_3.Text = _sudokuDiagram.GetValue(3, 3).ToString();
            textBox_3_4.Text = _sudokuDiagram.GetValue(3, 4).ToString();
            textBox_3_5.Text = _sudokuDiagram.GetValue(3, 5).ToString();
            textBox_3_6.Text = _sudokuDiagram.GetValue(3, 6).ToString();
            textBox_3_7.Text = _sudokuDiagram.GetValue(3, 7).ToString();
            textBox_3_8.Text = _sudokuDiagram.GetValue(3, 8).ToString();
            textBox_4_0.Text = _sudokuDiagram.GetValue(4, 0).ToString();
            textBox_4_1.Text = _sudokuDiagram.GetValue(4, 1).ToString();
            textBox_4_2.Text = _sudokuDiagram.GetValue(4, 2).ToString();
            textBox_4_3.Text = _sudokuDiagram.GetValue(4, 3).ToString();
            textBox_4_4.Text = _sudokuDiagram.GetValue(4, 4).ToString();
            textBox_4_5.Text = _sudokuDiagram.GetValue(4, 5).ToString();
            textBox_4_6.Text = _sudokuDiagram.GetValue(4, 6).ToString();
            textBox_4_7.Text = _sudokuDiagram.GetValue(4, 7).ToString();
            textBox_4_8.Text = _sudokuDiagram.GetValue(4, 8).ToString();
            textBox_5_0.Text = _sudokuDiagram.GetValue(5, 0).ToString();
            textBox_5_1.Text = _sudokuDiagram.GetValue(5, 1).ToString();
            textBox_5_2.Text = _sudokuDiagram.GetValue(5, 2).ToString();
            textBox_5_3.Text = _sudokuDiagram.GetValue(5, 3).ToString();
            textBox_5_4.Text = _sudokuDiagram.GetValue(5, 4).ToString();
            textBox_5_5.Text = _sudokuDiagram.GetValue(5, 5).ToString();
            textBox_5_6.Text = _sudokuDiagram.GetValue(5, 6).ToString();
            textBox_5_7.Text = _sudokuDiagram.GetValue(5, 7).ToString();
            textBox_5_8.Text = _sudokuDiagram.GetValue(5, 8).ToString();
            textBox_6_0.Text = _sudokuDiagram.GetValue(6, 0).ToString();
            textBox_6_1.Text = _sudokuDiagram.GetValue(6, 1).ToString();
            textBox_6_2.Text = _sudokuDiagram.GetValue(6, 2).ToString();
            textBox_6_3.Text = _sudokuDiagram.GetValue(6, 3).ToString();
            textBox_6_4.Text = _sudokuDiagram.GetValue(6, 4).ToString();
            textBox_6_5.Text = _sudokuDiagram.GetValue(6, 5).ToString();
            textBox_6_6.Text = _sudokuDiagram.GetValue(6, 6).ToString();
            textBox_6_7.Text = _sudokuDiagram.GetValue(6, 7).ToString();
            textBox_6_8.Text = _sudokuDiagram.GetValue(6, 8).ToString();
            textBox_7_0.Text = _sudokuDiagram.GetValue(7, 0).ToString();
            textBox_7_1.Text = _sudokuDiagram.GetValue(7, 1).ToString();
            textBox_7_2.Text = _sudokuDiagram.GetValue(7, 2).ToString();
            textBox_7_3.Text = _sudokuDiagram.GetValue(7, 3).ToString();
            textBox_7_4.Text = _sudokuDiagram.GetValue(7, 4).ToString();
            textBox_7_5.Text = _sudokuDiagram.GetValue(7, 5).ToString();
            textBox_7_6.Text = _sudokuDiagram.GetValue(7, 6).ToString();
            textBox_7_7.Text = _sudokuDiagram.GetValue(7, 7).ToString();
            textBox_7_8.Text = _sudokuDiagram.GetValue(7, 8).ToString();
            textBox_8_0.Text = _sudokuDiagram.GetValue(8, 0).ToString();
            textBox_8_1.Text = _sudokuDiagram.GetValue(8, 1).ToString();
            textBox_8_2.Text = _sudokuDiagram.GetValue(8, 2).ToString();
            textBox_8_3.Text = _sudokuDiagram.GetValue(8, 3).ToString();
            textBox_8_4.Text = _sudokuDiagram.GetValue(8, 4).ToString();
            textBox_8_5.Text = _sudokuDiagram.GetValue(8, 5).ToString();
            textBox_8_6.Text = _sudokuDiagram.GetValue(8, 6).ToString();
            textBox_8_7.Text = _sudokuDiagram.GetValue(8, 7).ToString();
            textBox_8_8.Text = _sudokuDiagram.GetValue(8, 8).ToString();
        }

        private void buttonFix_Click(object sender, EventArgs e)
        {
            _sudokuDiagram.SetFixedCells();
        }
    }
}
