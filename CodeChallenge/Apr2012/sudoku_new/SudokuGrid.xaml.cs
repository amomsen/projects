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
        //private Label[] labels = new Label[81];
        //private int BLockNameIterator;
        //private TextBox inputBox = new TextBox();
        private List<SudokuSquare> sudokuSquares = new List<SudokuSquare>();
        private List<int> possibleSolution = new List<int>();
        //private int SelectedBlock;
        //private int BlockNumber;
        private int[] solution = new int[81];


        private List<Point> PositionList = new List<Point>();

        public SudokuGrid()
        {
            InitializeComponent();
            solution = GameController.GetSudokuProblem().ToArray();
            
            DrawSquares();
        }


        private void getPossibleSolution()
        {
            possibleSolution = new List<int>();
            foreach (SudokuSquare square in sudokuSquares)
            {

                possibleSolution.Add(Convert.ToInt32(square.Value));
            }
        }


        private void CheckIfSuccess()
        {

            getPossibleSolution();

            if (!possibleSolution.Contains(0))
            {
                bool b = GameController.IsProblemSolved(possibleSolution);
            }
        }

        //TODO fix tab index
        private void DrawSquares()
        {
            int squareNumber = 0;
            for (int row = 0; row < 9; row++)
            {

                for (int column = 0; column < 9; column++)
                {
                    SudokuSquare sudokuSquare = new SudokuSquare(solution[squareNumber], row, column);
                    sudokuSquare.SudokuTextBox.TextChanged += new TextChangedEventHandler(TextChanged);
                    sudokuSquares.Add(sudokuSquare);
                    Canvas.Children.Insert(1, sudokuSquare);
                    squareNumber++;
                }
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            

            CheckIfSuccess();
        }


        /*private void DrawSquare()
        {
            int startx = 7;
            int starty = 8;
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

                    if (solution[BlockNumber] == 0)
                        DrawBlock(x, y, true, solution[BlockNumber], BlockNumber++);
                    else
                        DrawBlock(x, y, false, solution[BlockNumber], BlockNumber++);

                    PositionList.Add(new Point(x, y));
                }
            }
        }

        private void DrawBlock(int x, int y, bool highlight, int DisplayNumber, int blocknumber)
        {
            //testControl = new SudokuSquare(highlight) { IsHighlighted = highlight, Id = blocknumber, DisplayValue = DisplayNumber.ToString() };

            //testControl.SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            //testControl.SetValue(Canvas.LeftProperty, Convert.ToDouble(x));

            //testControl.Name = sudoku_new.Properties.Settings.Default.StringAffix + (BLockNameIterator++).ToString();

            //labels[blocknumber] = testControl.SudokuTextBox.Text;

            if (DisplayNumber != 0)
            {
                //testControl.SudokuLabel.Content = DisplayNumber.ToString();
            }
            else
            {
                //testControl.MouseLeftButtonDown += new MouseButtonEventHandler(emptyBlock_MouseLeftButtonDown);
            }

            //Canvas.Children.Insert(1, testControl);
        }

        private void emptyBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string blockName = string.Empty;
            int blockNumber;
            //testControl = (SudokuSquare)e.Source;
            //blockName = testControl.Name.TrimStart(sudoku_new.Properties.Settings.Default.StringAffix);
            if (int.TryParse(blockName, out blockNumber))
            {
                if (inputBox != null)
                {
                    Canvas.Children.Remove(inputBox);
                    inputBox = null;
                }
                //testControl.SudokuLabel.Focus();
                //inputBox = new TextBox();
                //testControl.textBox.SetValue(Canvas.LeftProperty, Convert.ToDouble(PositionList[blockNumber].X));
                //testControl.textBox.SetValue(Canvas.TopProperty, Convert.ToDouble(PositionList[blockNumber].Y));
                SelectedBlock = blockNumber;
                //testControl.textBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                //testControl.textBox.Focus();
                //testControl.textBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                //testControl.textBox.TextAlignment = TextAlignment.Center;
                //Canvas.Children.Insert(1, testControl.textBox);
                //testControl.textBox.Focus();
                /*inputBox.SetValue(Canvas.LeftProperty, Convert.ToDouble(PositionList[blockNumber].X));
                inputBox.SetValue(Canvas.TopProperty, Convert.ToDouble(PositionList[blockNumber].Y));
                SelectedBlock = blockNumber;
                inputBox.Height = 37;
                inputBox.Width = 40;
                inputBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                inputBox.Focus();
                inputBox.KeyDown += new KeyEventHandler(inputBox_KeyDown);
                inputBox.FontSize = 25;
                inputBox.TextAlignment = TextAlignment.Center;
                Canvas.Children.Insert(1, inputBox);
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

            //int l = testControl.textBox.Text.Length;

            if (!foundInput)
                e.Handled = true;
            else
            {
                //labels[SelectedBlock].Content = key.ToString();
                //Canvas.Children.Remove(inputBox);
                //Canvas.Children.Remove(testControl.textBox);
                CheckIfSuccess();
            }
        }
        */

    }
}