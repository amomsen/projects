using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System;

namespace sudoku
{
    public partial class SudokuSquare : UserControl
    {
        public int Row { get; set; }
        public int Column  { get; set; }
        public int Value { get; set; }

        //public TextBox textBox = new TextBox();

        private int startx = 7;
        private int starty = 8;


        public SudokuSquare(int value, int row, int column)
        {
            InitializeComponent();
            Value = value;
            Row = row;
            Column = column;
            DrawSquares();
        }

        
        private void DrawSquares()
        {
            if (Row >= 3)
            {
                startx += 5;
            }
            if (Row >= 6)
            {
                startx += 5;
            }
            
            int x = startx + (Row * 40);

            if (Column >= 3)
            {
                starty += 5;
            }

            if (Column >= 6)
            {
                starty += 5;
            } 
            
            int y = starty + (Column * 37);

            SetValue(Canvas.LeftProperty, Convert.ToDouble(x));
            SetValue(Canvas.TopProperty, Convert.ToDouble(y));

            GradientStopCollection gradients = new GradientStopCollection();

            if (Value != 0)
            {
                gradients.Add(new GradientStop(Colors.LightBlue, 1));
                gradients.Add(new GradientStop(Color.FromArgb(38, 255, 255, 255), 0.448));
                gradients.Add(new GradientStop(Color.FromArgb(90, 73, 73, 73), 0.076));
                SudokuTextBox.Text = Value.ToString(); 
                SudokuTextBox.IsEnabled = false;
            }
            else
            {
                gradients.Add(new GradientStop(Colors.LightGreen, 0.9));
                gradients.Add(new GradientStop(Colors.White, 0.448));
                gradients.Add(new GradientStop(Colors.LightGreen, 0.076));
              
            }

            SudokuTextBox.BorderThickness = new Thickness(0);
            SudokuTextBox.TextAlignment = TextAlignment.Center;

            LinearGradientBrush brush = new LinearGradientBrush(gradients);
            brush.StartPoint = new Point(0.5, 0);
            brush.EndPoint = new Point(0.5, 1);
            SudokuRectangle.Fill = brush;
            SudokuRectangle.Stroke = Brushes.Gray;
            SudokuRectangle.StrokeThickness = 1;
            SudokuRectangle.RadiusX = 8;
            SudokuRectangle.RadiusY = 8;

            SudokuTextBox.TextChanged += new TextChangedEventHandler(SudokuTextBox_TextChanged);
        }

        private void SudokuTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int i;
            bool b = Int32.TryParse(textBox.Text, out i);
            Value = i;
        }
    }
}