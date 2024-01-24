using System;

class Program
{
    static Dictionary<int, double> memo = new Dictionary<int, double>();

    public static void Main()
    {
        Console.WriteLine($"{Polynom(100, 10):F2}");
    }

    public static double Polynom(int m, int x)
    {
        if (m < 0)
        {
            throw new ArgumentException("m must be non-negative");
        }
        if (m == 0) { return 1.0; }
        if (m == 1) { return (double)x; }

        if (memo.ContainsKey(m))
            return memo[m];

        memo[m] = (3.0 * m - 1) / m * Polynom(m - 1, x) - x * Polynom(m - 2, x);
        return memo[m];
    }
}