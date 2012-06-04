using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace sudoku
{
    public class SudokuSquare : UIElement
    {

        Rectangle rectangle = new Rectangle();
        

       /* public SudokuSquare(int id, int x, int y)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 40;
            rectangle.Height = 37;

            rectangle.SetValue(Canvas.TopProperty, Convert.ToDouble(y));
            rectangle.SetValue(Canvas.LeftProperty, Convert.ToDouble(x));

            GradientStopCollection gradients = new GradientStopCollection();

            Label label = new Label();
            label.Height = 37;
            label.Width = 40;
            label.FontSize = 25;

            label.SetValue(Canvas.TopProperty, Convert.ToDouble(y - 5));
            label.SetValue(Canvas.LeftProperty, Convert.ToDouble(x + 7));
            label.Name = "B" + (id).ToString();


            
        }*/

    }
}
