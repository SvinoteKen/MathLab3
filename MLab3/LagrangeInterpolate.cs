using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLab3
{
	class LagrangeInterpolate
	{
		private List<double> allX = new List<double>();
		private List<double> allY = new List<double>();

		public void Add(double x, double y)
		{
			allX.Add(x);
			allY.Add(y);
		}

		public double InterpolateX(double x)
		{
			double answer = 0;
			for (int i = 0; i <= allX.Count - 1; i++)
			{
				double numerator = 1;
				double denominator = 1;
				for (int c = 0; c <= allX.Count - 1; c++)
				{
					if (c != i)
					{
						numerator *= (x - allX[c]);
						denominator *= (allX[i] - allX[c]);

					}
				}
				answer += allY[i] * (numerator / denominator);
			}
			return answer;
		}
	}
}
