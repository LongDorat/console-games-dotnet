using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal static class Game
    {
        public static (int, int) CursorPosition { get; set; } = (0, 0);
        static bool IsGameOver { get; set; } = false;
        static bool IsGameWon { get; set; } = false;
        static bool IsBoardInitialized { get; set; } = false;

        static Game()
        {
            Console.CursorVisible = false;
            if (OperatingSystem.IsWindowsVersionAtLeast(10))
            {
                Console.SetWindowSize(80, 25);
                Console.SetBufferSize(80, 25);
            }
        }

        public static void Start()
        {
            Board board = new();
            while (!IsGameOver && !IsGameWon)
            {
                Console.Clear();
                Render.Board(board, CursorPosition);
                HandleInput(board);
            }
            if (IsGameWon)
            {
                Render.Board(board, CursorPosition);
                Console.WriteLine("Congratulations! You've won!");
            }
            else
            {
                Render.Board(board, CursorPosition);
                Console.WriteLine("Game Over! You hit a mine.");
            }
        }

        private static void HandleInput(Board board)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (CursorPosition.Item2 > 0) CursorPosition = (CursorPosition.Item1, CursorPosition.Item2 - 1);
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorPosition.Item2 < Configurations.Height - 1) CursorPosition = (CursorPosition.Item1, CursorPosition.Item2 + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    if (CursorPosition.Item1 > 0) CursorPosition = (CursorPosition.Item1 - 1, CursorPosition.Item2);
                    break;
                case ConsoleKey.RightArrow:
                    if (CursorPosition.Item1 < Configurations.Width - 1) CursorPosition = (CursorPosition.Item1 + 1, CursorPosition.Item2);
                    break;
                case ConsoleKey.Enter:
                    if (!IsBoardInitialized)
                    {
                        board.InitializeBoard(Configurations.Width, Configurations.Height);
                        board.GenerateMines(Configurations.Mines, CursorPosition);
                        IsBoardInitialized = true;
                    }
                    RevealCell(board, CursorPosition);
                    break;
            }
        }

        private static void RevealCell(Board board, (int x, int y) position)
        {
            Queue<(int x, int y)> cellsToReveal = new Queue<(int x, int y)>();
            cellsToReveal.Enqueue(position);
            
            while (cellsToReveal.Count > 0)
            {
                var currentPos = cellsToReveal.Dequeue();
                var cell = board.Cells[currentPos.x, currentPos.y];
                
                // Skip already revealed cells
                if (cell.IsRevealed) continue;
                
                // Handle mine case
                if (cell.IsMine)
                {
                    IsGameOver = true;
                    return;
                }

                // Mark the current cell as revealed
                cell.IsRevealed = true;
                
                // If cell has no adjacent mines, add neighbors to queue
                if (cell.AdjacentMines == 0)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            int newX = currentPos.x + x;
                            int newY = currentPos.y + y;
                            
                            // Check if the neighbor is within bounds and not already revealed
                            if (newX >= 0 && newX < Configurations.Width && 
                                newY >= 0 && newY < Configurations.Height &&
                                !board.Cells[newX, newY].IsRevealed &&
                                !board.Cells[newX, newY].IsMine)
                            {
                                cellsToReveal.Enqueue((newX, newY));
                            }
                        }
                    }
                }
            }
            
            // Check for win condition
            IsGameWon = board.Cells.Cast<Cell>().All(c => c.IsRevealed || c.IsMine);
        }
    }
}
