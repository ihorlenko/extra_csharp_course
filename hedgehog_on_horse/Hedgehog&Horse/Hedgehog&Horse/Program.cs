using System;
using static System.Math;

public class Program
{
    static int n, m, p, q;
    static int[][] dp;
    static int[][] field;
    static int[][] memo;

    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        n = Convert.ToInt32(input[0]);
        m = Convert.ToInt32(input[1]);
        p = Convert.ToInt32(input[2]);
        q = Convert.ToInt32(input[3]);

        field = new int[n][];
        dp = new int[n][];
        memo = new int[n][];

        for (int i = 0; i < n; ++i)
        {
            int[] row = new int[m];
            dp[i] = new int[m];
            memo[i] = new int[m];

            string[] rowOfStrings = Console.ReadLine().Split();
            for (int j = 0; j < m; ++j)
            {
                row[j] = Convert.ToInt32(rowOfStrings[j]);
                memo[i][j] = -1;
            }

            field[i] = row;
        }

        int happiness = seekHappiness(n - 1, m - 1);
        if (happiness != 0)
        {
            Console.WriteLine(happiness);
        } else
        {
            Console.WriteLine("Not today");
        }
    }

    public static int seekHappiness(int i, int j)
    {
        if (memo[i][j] != -1) { return memo[i][j]; }
        if (i == 0 && j == 0) { return field[0][0]; }

        int happiness = 0;
        if (j - p >= 0 && i - q >= 0)
        {
            dp[i - q][j - p] = seekHappiness(i - q, j - p);
            happiness = Max(happiness, dp[i - q][j - p]);
        }
        if (j - p >= 0 && i + q < n)
        {
            dp[i + q][j - p] = seekHappiness(i + q, j - p);
            happiness = Max(happiness, dp[i + q][j - p]);
        }
        if (i - p >= 0 && j - q >= 0)
        {
            dp[i - p][j - q] = seekHappiness(i - p, j - q);
            happiness = Max(happiness, dp[i - p][j - q]);
        }
        if (i - p >= 0 && j + q < m)
        {
            dp[i - p][j + q] = seekHappiness(i - p, j + q);
            happiness = Max(happiness, dp[i - p][j + q]);
        }

        if (happiness != 0)
        {
            memo[i][j] = field[i][j] + happiness;
            return field[i][j] + happiness;
        } else
        {
            return 0;
        }
    }

}