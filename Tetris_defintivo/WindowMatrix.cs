using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_defintivo
{
    class WindowMatrix
    {
		int[,] windowMatrix;

		public WindowMatrix()
		{
			windowMatrix = new int[Constants.ROWS_WINDOW, Constants.COLUMS_WINDOW];
		}

		public int[,] _windowMatrix
		{
			get
			{
				return windowMatrix;
			}
		}

		public int this[int y, int x]
		{
			get
			{
				if (x < 0 || x > Constants.COLUMS_WINDOW || y < 0 || y > Constants.ROWS_WINDOW)
					throw new Exception("El intervalo está fuera del índice");
				else
					return windowMatrix[y, x];
			}
			set
			{
				if (!(x < 0 || x > Constants.COLUMS_WINDOW || y < 0 || y > Constants.ROWS_WINDOW))
					windowMatrix[y, x] = value;
				else
					throw new Exception("El intervalo está fuera del índice");
			}
		}

		public void pintarPieza(Pieza p)
		{
			int ancho = p.ancho;
			int alto = p.alto;
			for (int x = 0; x < ancho; x++)
			{
				for (int y = 0; y < alto; y++)
				{
					if (p[y, x] == 1 && p.posY + y >= 0)
					{
						windowMatrix[p.posY + y, p.posX + x] = p.color;
					}
				}
			}
		}

		public bool puedeBajarPieza(Pieza p)
		{
			bool puede = true;
			int ancho = p.ancho;
			int alto = p.alto;
			if (p.posY + p.alto > Constants.ROWS_WINDOW || hayColision(p))
			{
				puede = false;
			}
			return puede;
		}

		public bool hayColision(Pieza p)
		{
			bool hay = false;
			int ancho = p.ancho;
			int alto = p.alto;
			for (int x = 0; x < ancho; x++)
			{
				for (int y = 0; y < alto; y++)
				{
					if (p[y, x] == 1 && p.posY + y >= 0)
					{
						if (windowMatrix[p.posY + y, p.posX + x] != 0)
						{
							hay = true;
						}
					}
				}
			}
			return hay;
		}

		public bool puedeMoverPieza(Pieza p)
		{
			bool puede = true;
			int ancho = p.ancho;
			int alto = p.alto;
			if (p.posX < 0 || p.posX + p.ancho > Constants.COLUMS_WINDOW || hayColision(p))
			{
				puede = false;
			}
			return puede;
		}

		public void borrarPieza(Pieza p)
		{
			int ancho = p.ancho;
			int alto = p.alto;
			for (int x = 0; x < ancho; x++)
			{
				for (int y = 0; y < alto; y++)
				{
					if (p[y, x] == 1 && p.posY + y >= 0)
					{
						windowMatrix[p.posY + y, p.posX + x] = 0;
					}
				}
			}
		}

		public void borrarPantalla()
		{
			windowMatrix = new int[Constants.ROWS_WINDOW, Constants.COLUMS_WINDOW];
		}

		public int eliminaLineasCompletas()
		{
			bool filaCompleta = true;
			int numFilasCompletas = 0;
			int x;
			for (int y = 0; y < Constants.ROWS_WINDOW; y++)
			{
				filaCompleta = true;
				x = 0;
				while (x < Constants.COLUMS_WINDOW && filaCompleta)
				{
					if (windowMatrix[y, x] == 0)
					{
						filaCompleta = false;
					}
					x++;
				}
				if (filaCompleta)
				{
					eliminaLinea(y);
					numFilasCompletas++;
				}
			}
			return numFilasCompletas;
		}

		private void eliminaLinea(int linea)
		{
			for (int y = linea; y > 0; y--)
			{
				for (int x = 0; x < Constants.COLUMS_WINDOW; x++)
				{
					windowMatrix[y, x] = windowMatrix[y - 1, x];
				}
			}
		}
	}
}
