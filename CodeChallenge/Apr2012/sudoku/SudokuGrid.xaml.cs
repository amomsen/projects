using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace sudoku
{
    /// <summary>
    /// Interaction logic for SudokuGrid.xaml
    /// </summary>
    public partial class SudokuGrid : UserControl
    {

        private Label[] labels = new Label[81];
        private int BLockNameIterator;
        private TextBox inputBox;
        private int SelectedBlock;
        private int BlockNumber;
        private int[] numbers = new int[81];

        private List<Point> PositionList = new List<Point>();

        public SudokuGrid()
        {
            InitializeComponent();
            
            numbers = GameController.GetSudokuProblem(36).ToArray();
            numbers = Board.Values; 
            DrawBoard();
        }

        private void DrawBoard()
        {
            for (int verticalCount = 1; verticalCount <= Board.NumberOfRowsAndColumns; verticalCount++)
            {
                for (int horizontalCount = 1; horizontalCount < Board.NumberOfRowsAndColumns; horizontalCount++)
                {
                    DrawBox((horizontalCount * 120) - 120 + (6 * horizontalCount), (verticalCount * 111) - 111 + (6 * verticalCount));
                }
            }
        }

        private void DrawBox(int xOffset, int yOffSet)
        {
            for (int verticalCount = 1; verticalCount <= Board.SquareGrouping; verticalCount++)
            {
                for (int horizontalCount = 1; horizontalCount <= Board.SquareGrouping; horizontalCount++)
                {
                    int x = (horizontalCount * 40) - 40 + xOffset;
                    int y = (verticalCount * 37) - 37 + yOffSet;
                    if (numbers[BlockNumber] == Board.EmptyFlagValue)
                    {
                        DrawRectangle(x, y, true, numbers[BlockNumber], BlockNumber++);
                    }
                    else
                    {

                        DrawRectangle(x, y, false, numbers[BlockNumber], BlockNumber++);
                    }
                    PositionList.Add(new Point(x, y));
                }
            }
        }

        private void DrawRectangle(int x, int y, bool highlight, int DisplayNumber, int blocknumber)
        {
            SudokuSquare emptyBlock = new SudokuSquare(BLockNameIterator++, x, y);
            
            //emptyBlock.SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            //emptyBlock.SetValue(Canvas.LeftProperty, Convert.ToDouble(x));
            
            //GradientStopCollection gradients = new GradientStopCollection();

            //Label blockLabel = new Label();
            //blockLabel.Height = 37;
            //blockLabel.Width = 40;
            //blockLabel.FontSize = 25;

            //blockLabel.SetValue(Canvas.TopProperty, Convert.ToDouble(y - 5));
            //blockLabel.SetValue(Canvas.LeftProperty, Convert.ToDouble(x + 7));
            //blockLabel.Name = "B" + (BLockNameIterator++).ToString();
            
            
            /*BoardCanvas.Children.Insert(1, blockLabel);
            labels[blocknumber] = blockLabel;

            if (highlight == false)
            {
                gradients.Add(new GradientStop(Colors.LightGray, 1));
                gradients.Add(new GradientStop(Color.FromArgb(38, 255, 255, 255), 0.448));
                gradients.Add(new GradientStop(Color.FromArgb(90, 73, 73, 73), 0.076));
                emptyBlock.Stroke = Brushes.LightGray;
            }
            else
            {
                gradients.Add(new GradientStop(Colors.LightBlue, 1));
                gradients.Add(new GradientStop(Color.FromArgb(38, 255, 255, 255), 0.448));
                gradients.Add(new GradientStop(Colors.LightBlue, 0.006));
                emptyBlock.Stroke = Brushes.Silver;
                //gradients.Add(new GradientStop(Color.FromArgb(90, 73, 73, 73), 0.076));
            }

            LinearGradientBrush myBrush = new LinearGradientBrush(gradients);
            myBrush.StartPoint = new Point(0.5, 0);
            myBrush.EndPoint = new Point(0.5, 1);
            //emptyBlock.Stroke = Brushes.Gray;
            emptyBlock.StrokeThickness = 1;
            emptyBlock.Fill = myBrush;
            emptyBlock.RadiusX = 8;
            emptyBlock.RadiusY = 8;
            emptyBlock.Name = "B" + (BLockNameIterator).ToString();

            if (DisplayNumber != 0)
            {
                blockLabel.Content = DisplayNumber.ToString();
            }
            else
            {
                emptyBlock.MouseLeftButtonDown += new MouseButtonEventHandler(emptyBlock_MouseLeftButtonDown);
                blockLabel.MouseLeftButtonDown += new MouseButtonEventHandler(emptyBlock_MouseLeftButtonDown);
            }
             */ 
             
            BoardCanvas.Children.Insert(1, emptyBlock);

        }

        private void emptyBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string blockName = "";
            int blockNumber;
            if (e.Source is Rectangle)
                blockName = ((Rectangle)e.Source).Name.TrimStart('B');
            else if (e.Source is Label)
                blockName = ((Label)e.Source).Name.TrimStart('B');

            if (int.TryParse(blockName, out blockNumber))
            {
                if (inputBox != null)
                {
                    BoardCanvas.Children.Remove(inputBox);
                    inputBox = null;
                }
                inputBox = new TextBox();
                inputBox.SetValue(Canvas.LeftProperty, Convert.ToDouble(PositionList[blockNumber].X));
                inputBox.SetValue(Canvas.TopProperty, Convert.ToDouble(PositionList[blockNumber].Y));
                SelectedBlock = blockNumber;
                inputBox.Height = 37;
                inputBox.Width = 40;
                inputBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                inputBox.FontSize = 25;
                inputBox.TextAlignment = TextAlignment.Center;
                BoardCanvas.Children.Insert(1, inputBox);
                inputBox.Focus();
            }
        }

        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString().TrimStart('D');

            bool foundInput = false;
            for (int i = 0; i < 10; i++)
                if (key == (i + 1).ToString())
                {
                    foundInput = true;
                    break;
                }

            if (!foundInput || inputBox.Text.Length > 0)
                e.Handled = true;
            else
            {
                labels[SelectedBlock].Content = key.ToString();
                BoardCanvas.Children.Remove(inputBox);

                CheckIfSuccess();
            }

        }

        private void GetValuesFromGrid()
        {
            foreach (Label lable in labels) {
                //lable.Content
            }
        }


        private void CheckIfSuccess()
        {
            int res = 0;
            foreach (Label l in labels)
            {
                res = res + Convert.ToInt32(l.Content);

            }
            if (res == 405)
                BoardCanvas.Opacity = 0.3;
        }
    }
}