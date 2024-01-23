using System;

namespace MathLib
{
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

