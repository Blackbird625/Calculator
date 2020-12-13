using Calculator.Models;

namespace Calculator.Services
{
	public class MathExpression
	{
		public static double Parse(string expression)
		{
			var parser = new SimpleMathParserForDouble();
			return parser.Execute(parser.TokenizeExpression(expression), null);
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
