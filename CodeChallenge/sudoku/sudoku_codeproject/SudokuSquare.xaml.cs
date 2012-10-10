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
        public int CorrectValue { get; set; }
        private int startSquarePositionX = Constants.StartSquareX;
        private int startSquarePositionY = Constants.StartSquareY;

        public SudokuSquare(int value, int correctValue, int row, int column)
        {
            InitializeComponent();
            SudokuTextBox.Text = value.ToString();
            CorrectValue = correctValue;
            Row = row;
            Column = column;
            DrawSquare();
        }

        private void DrawSquare()
        {
            PositionSquaresIntoRegions();
            int x = startSquarePositionX + (Row * (int)SudokuRectangle.Width);
            int y = startSquarePositionY + (Column * (int)SudokuRectangle.Height);
            SetValue(Canvas.LeftProperty, Convert.ToDouble(x));
            SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            if (SudokuTextBox.Text.Equals(Constants.PlaceHolder.ToString()))
            {
                SudokuTextBox.IsEnabled = true;
                SudokuTextBox.Text = string.Empty;
            }
            else
            {
                SudokuTextBox.IsEnabled = false;
            }
            SetGradient(Colors.LightBlue, Colors.Silver);
            SudokuTextBox.TextChanged += new TextChangedEventHandler(SudokuTextBox_TextChanged);
        }

        private void SudokuTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            if (!int.TryParse(SudokuTextBox.Text, out i)) {
                SudokuTextBox.Text = string.Empty;
                e.Handled = true;
                return;
            }
            
            if (SudokuTextBox.Text.Equals(CorrectValue.ToString()))
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

        private void PositionSquaresIntoRegions()
        {
            startSquarePositionX += (Row / 3) * Constants.SpaceBetweenRegions;
            startSquarePositionY += (Column / 3) * Constants.SpaceBetweenRegions;
        }

    }
}