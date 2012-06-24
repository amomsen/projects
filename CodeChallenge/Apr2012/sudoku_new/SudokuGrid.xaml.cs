using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            numbers = GameController.GetSudokuProblem().ToArray();
            DrawSquare(7, 8);
        }

        private void DrawSquare(int startx, int starty)
        {
            int x, y;
            int YAdder = 0;
            for (int vert = 1; vert < 10; vert++)
            {
                int xAdder = 0;

                if (vert == 4 || vert == 7)
                    YAdder += 4;

                for (int hori = 1; hori < 10; hori++)
                {
                    if (hori == 4 || hori == 7)
                        xAdder += 5;

                    x = (hori * 40) - 40 + startx + xAdder;
                    y = (vert * 37) - 37 + starty + YAdder;

                    if (numbers[BlockNumber] == 0)
                        DrawBlock(x, y, true, numbers[BlockNumber], BlockNumber++);
                    else
                        DrawBlock(x, y, false, numbers[BlockNumber], BlockNumber++);

                    PositionList.Add(new Point(x, y));
                }
            }
        }

        private void DrawBlock(int x, int y, bool highlight, int DisplayNumber, int blocknumber)
        {
            TestControl block = new TestControl(highlight) { Id = blocknumber, DisplayValue = DisplayNumber.ToString() };

            block.SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            block.SetValue(Canvas.LeftProperty, Convert.ToDouble(x));

            block.Name = "B" + (BLockNameIterator++).ToString();

            labels[blocknumber] = block.SudokuLabel;

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

                inputBox = new TextBox();
                inputBox.SetValue(Canvas.LeftProperty, Convert.ToDouble(PositionList[blockNumber].X));
                inputBox.SetValue(Canvas.TopProperty, Convert.ToDouble(PositionList[blockNumber].Y));
                SelectedBlock = blockNumber;
                inputBox.Height = 37;
                inputBox.Width = 40;
                inputBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                inputBox.Focus();
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

            string s = e.Key.ToString();

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