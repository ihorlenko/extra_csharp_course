using MyRegEx;
using static System.Math;


public class Program
{
    private delegate double ExpSeries(double t);

    public static void Main()
    {
        StreamReader readerV = new StreamReader("30_Vector_M.txt");
        StreamReader readerM = new StreamReader("30_Matrix copy.txt");
        List<string> vectorFuncDescriptions = readerV.ReadLine().Split(',').ToList();
        List<string> matrixFuncDescriptions = readerM.ReadLine().Split(',').ToList();
        ExpSeries[] vectorFunctions = new ExpSeries[vectorFuncDescriptions.Count];
        ExpSeries[] matrixFunctions = new ExpSeries[matrixFuncDescriptions.Count];

        for (int i = 0; i < vectorFuncDescriptions.Count; ++i)
        {
            List<Tuple<string, string>> listOfCoefficients = Parser.parse(vectorFuncDescriptions[i].Trim());
            foreach (var tuple in listOfCoefficients)
            {
                double alpha = Convert.ToDouble(tuple.Item1);
                double beta = Convert.ToDouble(tuple.Item2);
                vectorFunctions[i] += t => (alpha * Exp(beta * t));
            }
        }

        for (int i = 0; i < matrixFuncDescriptions.Count; ++i)
        {
            List<Tuple<string, string>> listOfCoefficients = Parser.parse(matrixFuncDescriptions[i].Trim());
            foreach (var tuple in listOfCoefficients)
            {
                double alpha = Convert.ToDouble(tuple.Item1);
                double beta = Convert.ToDouble(tuple.Item2);
                matrixFunctions[i] += t => (alpha * Exp(beta * t));
            }
        }

        Console.Write("Введіть значення t: ");
        double t = Convert.ToDouble(Console.ReadLine());
        Compute(t, vectorFunctions, matrixFunctions);
    }

    private static void Compute(double t, ExpSeries[] vectorFunctions, ExpSeries[] matrixFunctions)
    {
        Console.WriteLine($"Вектор при t={t}:");
        foreach (var elem in vectorFunctions)
        {
            double sum = 0;
            for (int i = 0; i < elem.GetInvocationList().Length; ++i)
            {
                sum += elem.Invoke(t: t);
            }
            Console.Write($"{sum} ");
        }
        Console.WriteLine($"\nМатриця при t={t}:");
        for (int i = 0; i < matrixFunctions.Length; ++i)
        {
            double sum = 0;
            var elem = matrixFunctions[i];
            for (int j = 0; j < elem.GetInvocationList().Length; ++j)
            {
                sum += elem.Invoke(t: t);
            }
            if (i % 14 == 0) { Console.WriteLine(); }
            Console.Write($"{sum} ");
        }
    }

}