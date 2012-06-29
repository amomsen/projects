using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System;

namespace sudoku_new
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
            int x = startx + (Row * 41);
            SetValue(Canvas.LeftProperty, Convert.ToDouble(x));

            int y = starty + (Column * 38);
            SetValue(Canvas.TopProperty, Convert.ToDouble(y));

            GradientStopCollection gradients = new GradientStopCollection();

            if (Value != 0)
            {
                gradients.Add(new GradientStop(Colors.Gray, 1));
                SudokuTextBox.Text = Value.ToString(); 
                SudokuTextBox.IsEnabled = false;
            }
            else
            {
                gradients.Add(new GradientStop(Colors.LightBlue, 1));
            }

            SudokuTextBox.BorderThickness = new Thickness(0);
            

            gradients.Add(new GradientStop(Color.FromArgb(38, 255, 255, 255), 0.448));
            gradients.Add(new GradientStop(Color.FromArgb(90, 73, 73, 73), 0.076));
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
            Value = Convert.ToInt32(textBox.Text);
                                                    
        }

    }
}