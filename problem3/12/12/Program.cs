using System;
using LinearAlgebra;

class Program
{
    public static void Main()
    {
        Polynom F = new Polynom(new int[] {1, -2, 1});
        Polynom G = new Polynom(new int[] {1, 3, -4});

        Polynom H = F * G;

        Console.WriteLine(H);
    }
}