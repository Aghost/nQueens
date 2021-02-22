using System;

namespace nQueens
{
	class Program
	{
		static int[] Board;
		static int n = 8;
		static int Count = 0;
		static char[] Charray = "*ABCDEFGHIJKLMNOP".ToCharArray();

		static void Main(string[] args)
		{
			if (args.Length == 1)
			{
				int.TryParse(args[0], out n);

				if (n > 3 && n < 16)
				{
					Board = new int[n + 1];
					Queen(1, n);
				}
				else
				{
					Console.WriteLine("please provide a number > 3 and < 16");
				}
			}
			else
			{
				Board = new int[n + 1];
				Queen(1, n);
			}
		}

		static void Print(int n)
		{
			Console.WriteLine($"\nSolution nr: {++Count}");

			for (int i = 0; i <= n; i++)
				Console.Write($"{Charray[i]} ");

			for(int i = 1; i <= n; i++)
			{
				Console.Write($"\n{Charray[i]} ");

				for(int j = 1; j <= n; j++)
				{
					if (Board[i] == j) 
						Console.Write("Q ");
					else 
						Console.Write("- ");
				}
			}

			Console.WriteLine();
		}

		static bool Place(int row, int column)
		{
			for (int i = 1; i <= row - 1; ++i)
			{
				if ((Board[i] == column) || Math.Abs(Board[i] - column) == Math.Abs(i - row))
					return false;
			}

			return true;
		}

		static void Queen(int row, int n)
		{
			for (int column = 1; column <= n; ++column)
			{
				if (Place(row, column))
				{
					Board[row] = column;

					if (row == n)
						Print(n);
					else
						Queen(row + 1, n);
				}
			}
		}
	}
}
