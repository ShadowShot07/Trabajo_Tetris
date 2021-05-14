using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_defintivo
{
	class PieceForm
	{
		private int width, height;
		private int[,] matrixPiece = new int[Constants.COLUMS_PIECES, Constants.ROWS_PIECES];

		public PieceForm(string pieceForm)
		{
			if (pieceForm.Length == Constants.ROWS_PIECES * Constants.COLUMS_PIECES)
			{
				int block = 0;
				width = 0;
				height = 0;
				for (int y = 0; y < Constants.ROWS_PIECES; y++)
				{
					for (int x = 0; x < Constants.COLUMS_PIECES; x++)
					{
						block = Int32.Parse(pieceForm.Substring((4 * y) + x, 1));
						if (block == 1)
						{
							if (height < y + 1)
								height = y + 1;
							if (width < x + 1)
								width = x + 1;
						}
						matrixPiece[y, x] = block;
					}
				}
			}
		}

		public int this[int y, int x]
		{
			get
			{
				if (x < 0 || x > Constants.COLUMS_PIECES || y < 0 || y > Constants.ROWS_PIECES)
                {
					return matrixPiece[y, x] = 0;
				}
                else
                {
					return matrixPiece[y, x];
				}
			}
			set
			{
				if (!(x < 0 || x > Constants.COLUMS_PIECES || y < 0 || y > Constants.ROWS_PIECES))
                {
					matrixPiece[y, x] = value;
				}
			}
		}

		public int _width
		{
			get
			{
				return width;
			}
		}

		public int _height
		{
			get
			{
				return height;
			}
		}
	}
}
