using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace sudoku_new
{
    /// <summary>
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl
    {
        public int Id { get; set; }
        public string DisplayValue { get; set; }
        
        
        
        //TODO: fix this
        private bool isHighlighted;
        public bool IsHighlighted
        {
            get
            {
                return isHighlighted;
            }
            set
            {
                isHighlighted = value;
            }
        } 


        public TestControl(bool highlight)
        {
            InitializeComponent();
            IsHighlighted = highlight;
            PopulateDetails();
        }

        private void PopulateDetails()
        {
            GradientStopCollection gradients = new GradientStopCollection();
            if (isHighlighted == false)
            {
                gradients.Add(new GradientStop(Colors.Gray, 1));
            }
            else
            {
                gradients.Add(new GradientStop(Colors.LightBlue, 1));
            }

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
        }

    }
}
