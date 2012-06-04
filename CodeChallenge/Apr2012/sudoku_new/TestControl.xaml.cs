using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sudoku_new
{
    /// <summary>
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl
    {
        public int Id { get; set; }
        public string DisplayValue { get; set; }
        public bool IsHighligthed { get; set; }
        

        public TestControl()
        {

            InitializeComponent();
            PopulateDetails();

        }

        private void PopulateDetails()
        {
            //SudokuRectangle 
            //Rectangle emptyBlock = new Rectangle();
            //SudokuRectangle.Height = 37;
            //SudokuRectangle.Width = 40;

            //emptyBlock.SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            //emptyBlock.SetValue(Canvas.LeftProperty, Convert.ToDouble(x));
            GradientStopCollection gradients = new GradientStopCollection();

            
            //Label blockLabel = new Label();
            //blockLabel.Height = 37;
            //blockLabel.Width = 40;
            //blockLabel.FontSize = 25;

            //blockLabel.SetValue(Canvas.TopProperty, Convert.ToDouble(y - 5));
            //blockLabel.SetValue(Canvas.LeftProperty, Convert.ToDouble(x + 7));
            //SudokuLabel.Name = "B" + (BLockNameIterator++).ToString();
            //SudokuLabel.Children.Insert(1, blockLabel);
            //labels[blocknumber] = blockLabel;

            if (IsHighligthed == false)
            {
                gradients.Add(new GradientStop(Colors.Gray, 1));
                gradients.Add(new GradientStop(Color.FromArgb(38, 255, 255, 255), 0.448));
                gradients.Add(new GradientStop(Color.FromArgb(90, 73, 73, 73), 0.076));
            }
            else
            {
                gradients.Add(new GradientStop(Colors.LightBlue, 1));
                gradients.Add(new GradientStop(Color.FromArgb(38, 255, 255, 255), 0.448));
                gradients.Add(new GradientStop(Color.FromArgb(90, 73, 73, 73), 0.076));
            }

            LinearGradientBrush myBrush = new LinearGradientBrush(gradients);
            myBrush.StartPoint = new Point(0.5, 0);
            myBrush.EndPoint = new Point(0.5, 1);
            
            SudokuRectangle.Stroke = Brushes.Gray;
            SudokuRectangle.StrokeThickness = 1;
            SudokuRectangle.Fill = myBrush;
            SudokuRectangle.RadiusX = 8;
            SudokuRectangle.RadiusY = 8;
            //SudokuRectangle.Name = "B" + (BLockNameIterator).ToString();
        }

        
    }
}
