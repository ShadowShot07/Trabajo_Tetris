using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_defintivo
{
    class Constants
    {
		public const int ROWS_PIECES = 4;
		public const int COLUMS_PIECES = 4;
		public const int NUM_PIECES = 7;
		public const int NUM_ROTATIONS = 4;
		public const int ROWS_WINDOW = 21;
		public const int COLUMS_WINDOW = 13;
		public const int WIDTH_CELL = 20;
		public const int HEIGHT_CELL = 20;
		public const int NUM_LINES_BY_LEVEL = 2;

		private static Color[] colors = new Color[7] { Color.Red, Color.Blue, Color.DarkOrange, Color.DeepPink, Color.Violet, Color.Beige, Color.DarkMagenta };

		private static int[] levels = new int[10] { 1000, 800, 640, 512, 410, 328, 262, 210, 168, 134 };

		public static Color Colors(int color)
		{
			return colors[color];
		}

		public static int Levels(int level)
		{
			return levels[level];
		}
	}
}
