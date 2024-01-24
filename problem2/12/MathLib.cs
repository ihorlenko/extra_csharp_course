using System;
using System.Collections;

namespace MathLib
{
    public struct Vector : IEnumerable<int>
    {
        public int[] data { get; }
        public int size
        {
            get { return data.Length; }
        }
        public int this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        private readonly Random rand = new Random();

        public Vector(int size)
        {
            data = new int[size];
        }

        public void FillWithRandom()
        {
            for (int i = 0; i < size; ++i)
            {
                data[i] = rand.Next(-100, 100);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < size; ++i)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            foreach (int elem in data)
            {
                Console.Write($"{elem, 6}");
            }
        }
    }

	public static class VectorMath
	{
        public static int DotProduct(int[] vector1, int[] vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vectors should be the same size");
            }
            int dotProduct = 0;
            for (int i = 0; i < vector1.Length; ++i)
            {
                dotProduct += vector1[i] * vector2[i];
            }

            return dotProduct;
        }
    }
}

