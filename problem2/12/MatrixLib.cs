using System.Collections;
using MathLib;
using static MathLib.VectorMath;

namespace MatrixLib
{
    public struct Matrix : IEnumerable<int>
	{
        public struct Size
        {
            public int rows;
            public int columns;

            public Size(int rows, int columns)
            {
                this.rows = rows;
                this.columns = columns;
            }
        }

        public int[,] data { get; }
		public Size size { get; private set; }
        private static readonly Random rand = new Random();
        
        public Matrix(int rows, int columns)
        {
            this.size = new Size(rows, columns);
            data = new int[rows, columns];
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < size.rows; ++i)
            {
                for (int j = 0; j < size.columns; ++j)
                {
                    yield return data[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void FillWithRandom()
        {
            for (int i = 0; i < size.rows; ++i)
            {
                for (int j = 0; j < size.columns; ++j)
                {
                    data[i, j] = rand.Next(-100, 100);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < size.rows; ++i)
            {
                for (int j = 0; j < size.columns; ++j)
                {
                    Console.Write($"{data[i, j], 4}");
                }
                Console.WriteLine();
            }
        }

        public Tuple<int,int> IndexOf(int element)
        {
            Tuple<int, int> index = new Tuple<int, int>(-1, -1);
            for (int i = 0; i < size.rows; ++i)
            {
                for (int j = 0; j < size.columns; ++j)
                {
                    if (data[i,j] == element)
                    {
                        index = new Tuple<int, int>(i, j);
                    }
                }
            }

            return index;
        }

        public int[] MultiplyByVector(int[] vector)
        {
            if (size.columns != vector.Length)
            {
                throw new ArgumentException("Argument vector and rows in matrix" +
                    "must be of equal size");
            }

            int[] result = new int[size.rows];
            for (int i = 0; i < size.rows; ++i)
            {
                result[i] = DotProduct(GetRow(i), vector);
            }

            return result;
        }

        public int[] MultiplyByVector(Vector vector)
        {
            return MultiplyByVector(vector.data);
        }

        public int[] GetRow(int rowIndex)
        {
            int[] row = new int[size.columns];
            for (int i = 0; i < size.columns; ++i)
            {
                row[i] = data[rowIndex, i];
            }

            return row;
        }

        public int[] GetColumn(int columnIndex)
        {
            int[] column = new int[size.rows];
            for (int i = 0; i < size.rows; ++i)
            {
                column[i] = data[i, columnIndex];
            }

            return column;
        }
    }
}

