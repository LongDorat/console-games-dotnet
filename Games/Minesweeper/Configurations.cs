using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal static class Configurations
    {
        static public int Width { get; set; } = 10;
        static public int Height { get; set; } = 10;
        static public int Mines { get; set; } = 10;

        static public void SetMines(double minesDensity)
        {
            Mines = (int)(Width * Height * minesDensity);
        }
    }
}
