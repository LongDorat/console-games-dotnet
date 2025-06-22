using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Cell
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public int AdjacentMines { get; set; }
        public Cell()
        {
            IsMine = false;
            IsRevealed = false;
            AdjacentMines = 0;
        }
    }

    internal class Board
    {
        public Cell[,] Cells { get; private set; } = null!;

        public Board()
        {
            InitializeBoard(Configurations.Width, Configurations.Height);
            GenerateMines(Configurations.Mines, Game.CursorPosition);
        }

        public void InitializeBoard(int width, int height)
        {
            Cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }

        public void GenerateMines(int mineCount, (int, int) CursorPosition)
        {
            Random random = new();
            int width = Cells.GetLength(0);
            int height = Cells.GetLength(1);
            int placedMines = 0;
            while (placedMines < mineCount)
            {
                int x = random.Next(width);
                int y = random.Next(height);
                if (!Cells[x, y].IsMine && (x, y) != CursorPosition)
                {
                    Cells[x, y].IsMine = true;
                    placedMines++;
                    UpdateAdjacentMineCounts(x, y);
                }
            }
        }

        private void UpdateAdjacentMineCounts(int mineX, int mineY)
        {
            for (int x = mineX - 1; x <= mineX + 1; x++)
            {
                for (int y = mineY - 1; y <= mineY + 1; y++)
                {
                    if (x >= 0 && x < Cells.GetLength(0) 
                        && y >= 0 && y < Cells.GetLength(1) 
                        && !(x == mineX && y == mineY))
                    {
                        Cells[x, y].AdjacentMines++;
                    }
                }
            }
        }
    }
}
