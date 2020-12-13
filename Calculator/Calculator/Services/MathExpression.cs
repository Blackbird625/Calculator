namespace Calculator.Services
{
	public class MathExpression
	{
		public static double Parse(string expression)
		{
			return 0.0;
		}

		public static bool TryParse(string expression, out double result)
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
