using System.Windows;

namespace Sudoku
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GameController.GenerateNewGame();
            InitializeComponent();
        }
    }
}