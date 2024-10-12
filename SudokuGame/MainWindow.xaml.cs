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
            Background = Brushes.LightGray; // Fondo de la ventana

            // Creación del Grid principal
            mainGrid = new Grid();
            Content = mainGrid;

            // Crear el tablero Sudoku y añadirlo al mainGrid
            CreateSudokuGrid();

            // Lógica para cargar el tablero inicial del Sudoku
            LoadBoard();
        }

        private void CreateSudokuGrid()
        {
            // Creación de una cuadrícula UniformGrid para representar el tablero de Sudoku
            UniformGrid sudokuGrid = new UniformGrid
            {
                Rows = 9,
                Columns = 9,
                Margin = new Thickness(20)
            };

            // Crear las celdas (TextBoxes) del tablero con un diseño mejorado
            for (int i = 0; i < 81; i++)
            {
                TextBox cell = new TextBox
                {
                    Width = 40,
                    Height = 40,
                    FontSize = 20,
                    TextAlignment = TextAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    Background = Brushes.White, // Fondo blanco para las celdas
                    BorderBrush = Brushes.Gray // Borde gris para las celdas
                };

                // Añadir color de fondo para subcuadrículas de 3x3 para distinguir mejor los bloques
                int row = i / 9;
                int col = i % 9;
                if ((row / 3 + col / 3) % 2 == 0)
                {
                    cell.Background = Brushes.LightYellow; // Color de fondo diferente para bloques
                }

                sudokuGrid.Children.Add(cell);
            }

            // Agregar el tablero UniformGrid al Grid principal
            mainGrid.Children.Add(sudokuGrid);
        }

        private void LoadBoard()
        {
            // Ejemplo de un tablero de Sudoku inicial predefinido
            int[,] initialBoard = new int[9, 9]
            {
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };

            // Copiar el tablero inicial al tablero del juego
            board = initialBoard;
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

                // Hacer las celdas con valores iniciales como de solo lectura
                textBox.IsReadOnly = board[row, col] != 0;
                textBox.FontWeight = board[row, col] != 0 ? FontWeights.Bold : FontWeights.Normal;
                textBox.Foreground = board[row, col] != 0 ? Brushes.DarkBlue : Brushes.Black;

                cellIndex++;
            }
        }
    }
}