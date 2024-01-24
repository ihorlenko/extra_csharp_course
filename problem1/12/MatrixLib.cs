using System;

namespace MatrixLib
{
	public struct SquareMatrix
	{
		private int[,] data;
		public int size { get; private set; }
        public int Min
        {
            get
            {
                int min = Int32.MaxValue;
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        if (data[i, j] < min)
                        {
                            min = data[i, j];
                        }
                    }
                }
                return min;
            }
        }
        private static readonly Random rand = new Random();
        
        public SquareMatrix(int size)
        {
            this.size = size;
            data = new int[size, size];
        }

        public void FillWithRandom()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    data[i, j] = rand.Next(-100, 100);
                }
            }
        }

        public int[] CalculateDiagonalSums()
        {
            int[] diagonalSums = new int[2 * size - 1];
            for (int diagIndex = -size + 1; diagIndex < size; ++diagIndex)
            {
                for (int i = 0; i < size; ++i)
                {
                    int j = diagIndex + i;
                    if (j >= 0 && j < size)
                    {
                        diagonalSums[diagIndex + size - 1] += data[i, j];
                    }
                }
            }

            return diagonalSums;
        }

        public void Print()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write($"{data[i, j], 4}");
                }
                Console.WriteLine();
            }
        }

        public Tuple<int,int> IndexOf(int element)
        {
            Tuple<int, int> index = new Tuple<int, int>(-1, -1);
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (data[i,j] == element)
                    {
                        index = new Tuple<int, int>(i, j);
                    }
                }
            }

            return index;
        }

        public int[] GetRow(int rowIndex)
        {
            int[] row = new int[size];
            for (int i = 0; i < size; ++i)
            {
                row[i] = data[rowIndex, i];
            }

            return row;
        }

        public int[] GetColumn(int columnIndex)
        {
            int[] column = new int[size];
            for (int i = 0; i < size; ++i)
            {
                column[i] = data[i, columnIndex];
            }

            return column;
        }
    }
}

