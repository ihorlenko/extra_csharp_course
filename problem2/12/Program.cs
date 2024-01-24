using System;
using MathLib;
using MatrixLib;

public class Program
{
    public static void Main()
    {
        Matrix matrix = new Matrix(3, 5);
        matrix.FillWithRandom();
        Vector vector = new Vector(5);
        vector.FillWithRandom();

        Console.WriteLine("This is a randomly generated matrix" +
            $"{matrix.size.rows}*{matrix.size.columns}:");
        matrix.Print();
        Console.WriteLine();

        Console.WriteLine("This is a randomly generated vector " +
            $"of size {vector.size}:");
        vector.Print();
        Console.WriteLine("\n");

        int cntPos = 0;
        int cntNeg = 0;
        foreach (int elem in matrix)
        {
            if (elem > 0)
            {
                cntPos += 1;
            }
            else if (elem < 0)
            {
                cntNeg += 1;
            }
        }

        if (cntPos > cntNeg)
        {
            int[] result = matrix.MultiplyByVector(vector);
            Console.WriteLine("It appears that there are more positive " +
                $"elements ({cntPos}) than negatives ({cntNeg})\n" +
                $"So then this is a product of a matrix and a vector above:");
            foreach (int elem in result)
            {
                Console.Write($"{elem,6}");
            }
            Console.WriteLine();
        } else
        {
            Vector columnMinumums = new Vector(matrix.size.columns);
            for (int i = 0; i < matrix.size.columns; ++i)
            {
                int[] column = matrix.GetColumn(i);
                columnMinumums[i] = column.Min();
            }
            Console.WriteLine("It looks like there are less positive " +
                $"elements ({cntPos}) than negatives ({cntNeg})\n" +
                $"So then this is a vector of a minimuns of each column " +
                $"in the matrix above:");
            foreach (int elem in columnMinumums)
            {
                Console.Write($"{elem, 6}");
            }
            Console.WriteLine();
        }
    }
}