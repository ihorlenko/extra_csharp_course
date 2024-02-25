using System;
using System.Linq;
using static System.Math;

namespace LinearAlgebra
{
	public struct Polynom
	{
		public double[] coefficients;
		public int degree { get { return coefficients.Length - 1; } }
		readonly Random rand = new Random();

		public Polynom(int degree=1)
		{
			if (degree < 0) { throw new ArgumentException("Polynom must be " +
				"of degree at least 0"); }

			this.coefficients = new double[degree + 1];
		}

		public Polynom(double[] coefficients) : this(degree: coefficients.Length - 1)
		{
			Array.Reverse(coefficients);
			this.coefficients = coefficients;
		}

		public Polynom(int[] coefficients) : this(degree: coefficients.Length - 1)
        {
			for (int i = 0; i < coefficients.Length; ++i)
			{
				this.coefficients[i] = Convert.ToDouble(coefficients[coefficients.Length - i - 1]);
			}
		}

		private void FillWithRandomDouble()
		{
			for (int i = 0; i < this.coefficients.Length; ++i)
			{
				this.coefficients[i] = Pow(-1, rand.Next(0, 1)) * rand.NextDouble() * 10;
			}
		}

		private void FillWithRandomInts()
		{
            for (int i = 0; i < this.coefficients.Length; ++i)
            {
				this.coefficients[i] = Convert.ToDouble(rand.Next(-10, 10));
            }
        }

		public static Polynom operator *(Polynom F, Polynom G)
		{
			Polynom result = new Polynom(F.degree * G.degree);
			for (int k = 0; k < result.coefficients.Length; ++k)
			{
				for (int i = F.coefficients.Length - 1; i > -1; --i)
				{
					for (int j = 0; j < G.coefficients.Length; ++j)
					{
						if (i + j == k)
						{
							result.coefficients[k]
								+= F.coefficients[i] * G.coefficients[j];
						}
					}
				}
			}

			return result;
		}

        public override string ToString()
        {
			List<string> representaion = new List<string>();
			for (int i = this.coefficients.Length - 1; i > -1; --i)
			{
				string coef_part;
				string x_part;

				if (coefficients[i] == 0) { continue; }

				switch (i)
				{
					case 0:
						x_part = "";
						break;
					case 1:
						x_part = "x";
						break;
					default:
						x_part = $"x^{i}";
						break;
				}

				switch (coefficients[i])
				{
					case 1:
						coef_part = "";
						break;
					default:
						coef_part = $"{coefficients[i]}";
						break;
				}

				representaion.Add($"{coef_part}{x_part}");
			}

			return string.Join("+", representaion);
        }
    }
}

