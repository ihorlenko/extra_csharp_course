using System;

namespace MatrixNS
{
	public struct Matrix
	{
		private int[,] data;
		public int size { get; private set; }

        public Matrix(int size)
        {
            this.size = size;
            data = new int[size, size];
        }

        public void FillWithRandom()
        {
            Random rand = new Random();

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    data[i, j] = rand.Next(-100, 100);
                }
            }
        }

        public int[] CalcDiagonalSums()
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
    }

}

