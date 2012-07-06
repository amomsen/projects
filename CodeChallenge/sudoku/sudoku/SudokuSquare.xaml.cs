using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sudoku
{
    public partial class SudokuSquare : UserControl
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int Value { get; set; }

        public int CorrectValue { get; set; }

        private int startSquarePositionX = Sudoku.Properties.Settings.Default.StartSquareX;
        private int startSquarePositionY = Sudoku.Properties.Settings.Default.StartSquareY;
        private const int spaceBetweenBoxes = 5;

        public SudokuSquare(int value, int correctValue, int row, int column)
        {
            InitializeComponent();
            Value = value;
            CorrectValue = correctValue;
            Row = row;
            Column = column;
            DrawSquares();
        }

        private void PositionSquaresIntoBoxes()
        {
            if (Row >= 3)
            {
                startSquarePositionX += spaceBetweenBoxes;
            }
            if (Row >= 6)
            {
                startSquarePositionX += spaceBetweenBoxes;
            }

            if (Column >= 3)
            {
                startSquarePositionY += spaceBetweenBoxes;
            }

            if (Column >= 6)
            {
                startSquarePositionY += spaceBetweenBoxes;
            }
        }

        private void DrawSquares()
        {
            PositionSquaresIntoBoxes();
            int x = startSquarePositionX + (Row * (int)SudokuRectangle.Width);
            int y = startSquarePositionY + (Column * (int)SudokuRectangle.Height);
            SetValue(Canvas.LeftProperty, Convert.ToDouble(x));
            SetValue(Canvas.TopProperty, Convert.ToDouble(y));

            if (Value != 0)
            {
                SudokuTextBox.Text = Value.ToString();
                SudokuTextBox.IsEnabled = false;
                SetGradient(Colors.LightBlue, Colors.Silver);
            }
            else
            {
                SetGradient(Colors.Silver, Colors.Purple);
            }
            SudokuTextBox.TextChanged += new TextChangedEventHandler(SudokuTextBox_TextChanged);
        }

        private void SudokuTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int i = 0;
            bool b = Int32.TryParse(textBox.Text, out i);
            Value = i;
            if (Value == CorrectValue)
            {
                SetGradient(Colors.Silver, Colors.OliveDrab);
            }
            else
            {
                SetGradient(Colors.Silver, Colors.LightCoral);
            }
        }

        private void SetGradient(Color topColor, Color bottomColor)
        {
            GradientStopCollection gradients = new GradientStopCollection();
            gradients.Add(new GradientStop(topColor, 0.9));
            gradients.Add(new GradientStop(Colors.WhiteSmoke, 0.448));
            gradients.Add(new GradientStop(bottomColor, 0.076));
            LinearGradientBrush brush = new LinearGradientBrush(gradients);
            brush.StartPoint = new Point(0.5, 0);
            brush.EndPoint = new Point(0.5, 1);
            SudokuRectangle.Fill = brush;
        }
    }
}