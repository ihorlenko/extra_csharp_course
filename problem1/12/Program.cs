using System;
using MatrixLib;
using static MathLib.VectorMath;

public class Program
{
    public static void Main()
    {
        int size = 5;

        SquareMatrix matrix = new SquareMatrix(size);
        matrix.FillWithRandom();

        Console.WriteLine($"Randomly generated {size}*{size} matrix:");
        matrix.Print();

        int[] diagonalSums = matrix.CalculateDiagonalSums();
        Console.WriteLine();
        Console.WriteLine($"Diagonal sums calculated for this matrix:");
        foreach (int sum in diagonalSums)
        {
            Console.Write($"{sum, 6}");
        }
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine($"Dot product of row and column of a minimal " +
            $"element of this matrix:");
        Tuple<int, int> minIndex = matrix.IndexOf(matrix.Min);
        Console.WriteLine(DotProduct(
            matrix.GetRow(minIndex.Item1),
            matrix.GetColumn(minIndex.Item2)
            ));
    }
}