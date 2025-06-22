using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal static class Render
    {
        public static void Board(Board board, (int x, int y) cursorPosition)
        {
            Console.Clear();
            for (int y = 0; y < board.Cells.GetLength(1); y++)
            {
                for (int x = 0; x < board.Cells.GetLength(0); x++)
                {
                    var cell = board.Cells[x, y];
                    
                    // Always check cursor position first
                    if (cursorPosition.x == x && cursorPosition.y == y)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        
                        if (cell.IsRevealed && !cell.IsMine)
                        {
                            Console.Write(" _ "); // Revealed non-mine cell at cursor position
                        }
                        else
                        {
                            Console.Write(" ? "); // Hidden or mine cell at cursor position
                        }
                        
                        Console.ResetColor();
                    }
                    // Then handle non-cursor cells
                    else if (cell.IsRevealed)
                    {
                        if (cell.IsMine)
                        {
                            Console.Write(" * "); // Mine
                        }
                        else
                        {
                            Console.Write($" {cell.AdjacentMines} "); // Number of adjacent mines
                        }
                    }
                    else
                    {
                        Console.Write(" . "); // Hidden cell
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
