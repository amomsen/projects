using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using sudoku_new;

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

            DrawBoard();
        }

        private void DrawBoard()
        {
            for (int vert = 1; vert < 4; vert++)
            {
                for (int hori = 1; hori < 4; hori++)
                {
                    DrawSquare((hori * 120) - 120 + (6 * hori), (vert * 111) - 111 + (6 * vert));
                }
            }
        }

        private void DrawSquare(int startx, int starty)
        {
            for (int vert = 1; vert < 4; vert++)
            {
                for (int hori = 1; hori < 4; hori++)
                {
                    int x = (hori * 40) - 40 + startx;
                    int y = (vert * 37) - 37 + starty;

                    if (numbers[BlockNumber] == 0)
                    {
                        DrawBlock(x, y, true, numbers[BlockNumber], BlockNumber++);
                    }
                    else
                    {
                        DrawBlock(x, y, false, numbers[BlockNumber], BlockNumber++);
                    }
                    PositionList.Add(new Point(x, y));
                }
            }
        }

        private void DrawBlock(int x, int y, bool highlight, int DisplayNumber, int blocknumber)
        {
            TestControl block = new TestControl() {Id = blocknumber, DisplayValue = DisplayNumber.ToString(), IsHighligthed = highlight};
            
            block.SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            block.SetValue(Canvas.LeftProperty, Convert.ToDouble(x));
            
            block.Name = "B" + (BLockNameIterator++).ToString();
            
            //BoardCanvas.Children.Insert(1, block);
            
            labels[blocknumber] = block.SudokuLabel;

            //emptyBlock.Name = "B" + (BLockNameIterator).ToString();

            if (DisplayNumber != 0)
            {
                block.SudokuLabel.Content = DisplayNumber.ToString();
            }
            else
            {
                block.MouseLeftButtonDown += new MouseButtonEventHandler(emptyBlock_MouseLeftButtonDown);
            }
            BoardCanvas.Children.Insert(1, block);
        }

        private void emptyBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string blockName = "";
            int blockNumber;
            //if (e.Source is Rectangle)
            //    blockName = ((Rectangle)e.Source).Name.TrimStart('B');
            //else if (e.Source is Label)
            //    blockName = ((Label)e.Source).Name.TrimStart('B');
            TestControl testControl = (TestControl)e.Source;

            blockName = testControl.Name.TrimStart('B');

            if (int.TryParse(blockName, out blockNumber))
            {
                if (inputBox != null)
                {
                    BoardCanvas.Children.Remove(inputBox);
                    inputBox = null;
                }
                testControl.SudokuLabel.Focus();

                //inputBox = new TextBox();
                //inputBox.SetValue(Canvas.LeftProperty, Convert.ToDouble(PositionList[blockNumber].X));
                //inputBox.SetValue(Canvas.TopProperty, Convert.ToDouble(PositionList[blockNumber].Y));
                SelectedBlock = blockNumber;
                //inputBox.Height = 37;
                //inputBox.Width = 40;
                testControl.SudokuLabel.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                testControl.SudokuLabel.Focus();
                //inputBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                //inputBox.FontSize = 25;
                //inputBox.TextAlignment = TextAlignment.Center;
                //BoardCanvas.Children.Insert(1, inputBox);
                //inputBox.Focus();
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

        private void CheckIfSuccess()
        {
            //TODO:
            //IsValidMove
        }
    }
}