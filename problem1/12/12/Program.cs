using System;
using MatrixNS;

public class Program
{
    public static void Main()
    {
        int size = 5;

        Matrix matrix = new Matrix(size);
        matrix.FillWithRandom();

        Console.WriteLine($"Randomly generated {size}*{size} matrix:");
        matrix.Print();

        int[] diagonalSums = matrix.CalcDiagonalSums();
        Console.WriteLine();
        Console.WriteLine($"Diagonal sums calculated for this matrix:");
        foreach (int sum in diagonalSums)
        {
            Console.Write($"{sum, 6}");
        }
        Console.WriteLine();
    }
}