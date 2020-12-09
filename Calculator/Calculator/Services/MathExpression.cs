using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Services
{
	public class MathExpression
	{
		public double Parse(string expression)
		{
			return 0.0;
		}

		public bool TryParse(string expression, out double result)
		{
			try
			{
				result = Parse(expression);
				return true;
			}
			catch
			{
				result = default;
				return false;
			}

		}
	}
}
