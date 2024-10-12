using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SudokuGame
{
    public partial class MainWindow : Window
    {
        private int[,] board = new int[9, 9]; // Tablero de Sudoku
        private Grid mainGrid;

        public MainWindow()
        {
            // Configuración inicial de la ventana
            Title = "Sudoku Game";
            Width = 600;
            Height = 600;

            // Creación del Grid principal
            mainGrid = new Grid();
            Content = mainGrid;

            // Creación de una cuadrícula UniformGrid para representar el tablero de Sudoku
            UniformGrid sudokuGrid = new UniformGrid
            {
                Rows = 9,
                Columns = 9
            };

            // Crear las celdas (TextBoxes) del tablero
            for (int i = 0; i < 81; i++)
            {
                TextBox cell = new TextBox
                {
                    Width = 40,
                    Height = 40,
                    FontSize = 20,
                    TextAlignment = TextAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(0.5)
                };
                sudokuGrid.Children.Add(cell);
            }

            // Agregar el tablero al Grid principal
            mainGrid.Children.Add(sudokuGrid);

            // Lógica para cargar el tablero inicial del Sudoku
            LoadBoard();
        }

        private void LoadBoard()
        {
            // Inicializar el tablero con algunos valores predeterminados
            board[0, 0] = 5;
            board[1, 1] = 3;
            board[4, 4] = 7;
            // Rellena el resto del tablero con ceros o números
            UpdateUI();
        }

        private void UpdateUI()
        {
            // Actualiza la interfaz de usuario con el estado actual del tablero
            int cellIndex = 0;
            foreach (TextBox textBox in ((UniformGrid)mainGrid.Children[0]).Children)
            {
                int row = cellIndex / 9;
                int col = cellIndex % 9;
                textBox.Text = board[row, col] != 0 ? board[row, col].ToString() : string.Empty;
                cellIndex++;
            }
        }
    }
}
