using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_defintivo
{
    class Piece
    {
		private int _posX, _posY;
		private int _color;
		private int rotation;
		private PieceForm[] forms = new PieceForm[Constants.NUM_ROTATIONS];

		public Piece()
		{

		}

		public Piece(string PieceFormRotation1, string PieceFormRotation2, string PieceFormRotation3, string PieceFormRotation4, int color)
		{
			_color = color;
			rotation = 0;
			forms[0] = new PieceForm(PieceFormRotation1);
			forms[1] = new PieceForm(PieceFormRotation2);
			forms[2] = new PieceForm(PieceFormRotation3);
			forms[3] = new PieceForm(PieceFormRotation4);
			_posX = 6;
			_posY = 0 - alto + 1;
		}

		public int this[int y, int x]
		{
			get
			{
				if (x < 0 || x > Constants.COLUMS_PIECES || y < 0 || y > Constants.ROWS_PIECES)
					throw new Exception("El intervalo está fuera del índice");
				else
					return ((PieceForm)forms[rotation])[y, x];
			}
			set
			{
				if (!(x < 0 || x > Constants.COLUMS_PIECES || y < 0 || y > Constants.ROWS_PIECES))
					((PieceForm)forms[rotation])[y, x] = value;
				else
					throw new Exception("El intervalo está fuera del índice");
			}
		}

		public int ancho
		{
			get
			{
				return ((PieceForm)forms[rotation]).ancho;
			}
		}

		public int alto
		{
			get
			{
				return ((PieceForm)forms[rotation]).alto;
			}
		}

		public int posX
		{
			get
			{
				return m_posX;
			}
			set
			{
				m_posX = value;
			}
		}

		public int posY
		{
			get
			{
				return m_posY;
			}
			set
			{
				m_posY = value;
			}
		}

		public int color
		{
			get
			{
				return m_color;
			}
			set
			{
				m_color = value;
			}
		}

		public void rotarDerecha()
		{
			if (rotation < Constants.NUM_ROTATIONS - 1)
				rotation++;
			else
				rotation = 0;
		}

		public void rotarIzquierda()
		{
			if (rotation > 0)
				rotation--;
			else
				rotation = Constants.NUM_ROTATIONS - 1;
		}
	}
}
