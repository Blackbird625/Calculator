using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Calculator.Models
{
	/// <summary>
	/// Implementation of simple math class
	/// </summary>
	public class SimpleMathParserForDouble : ShuntingYardBase<double, string>
	{
		private readonly Dictionary<char, PrecedenceAssociativity> _operators = new Dictionary<char, PrecedenceAssociativity>()
		{
			{ '+', new PrecedenceAssociativity(2,Associativity.Left)},
			{ '-', new PrecedenceAssociativity(2,Associativity.Left)},
			{ '*', new PrecedenceAssociativity(3,Associativity.Left)},
			{ '/', new PrecedenceAssociativity(3,Associativity.Left)},
		};

		public override double Evaluate(double firstOperand, char mathOperator, double secondOperand) =>
			mathOperator switch
			{
				'+' => firstOperand + secondOperand,
				'-' => firstOperand - secondOperand,
				'*' => firstOperand * secondOperand,
				'/' => firstOperand / secondOperand,
				_ => throw new Exception("Wrong operator!!")
			};

		public override double TypecastIdentifier(string input, object tagObj) => double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var result) ? result : throw new Exception("Wrong identifier!!");

		public override bool IsIdentifier(string input) => double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out _);

		public override bool IsOperator(char? opr) => opr != null && _operators.ContainsKey((char)opr);

		public override char? TypecastOperator(string input) => _operators.ContainsKey(input[0]) ? input[0] : (char?)null;

		public override Associativity Association(char mathOperator) => _operators.ContainsKey(mathOperator) ? _operators[mathOperator].Associativity : throw new Exception("Wrong operator!!");

		public override int Precedence(char firstOperator, char secondOperator)
		{
			if (!_operators.ContainsKey(firstOperator))
			{
				throw new Exception("Wrong operator!!");
			}

			if (!_operators.ContainsKey(secondOperator))
			{
				throw new Exception("Wrong operator!!");
			}

			if (_operators[firstOperator].Precedence > _operators[secondOperator].Precedence)
			{
				return 1;
			}

			if (_operators[firstOperator].Precedence < _operators[secondOperator].Precedence)
			{
				return -1;
			}

			return 0;
		}

		public override bool IsNoise(string input) => false;

		public List<string> TokenizeExpression(string expression) => SplitToTokens(RemoveWhiteSpaces(expression.Replace(',', '.')));

		private static string RemoveWhiteSpaces(string expression) => new string(expression.Where(c => !char.IsWhiteSpace(c)).ToArray());

		private List<string> SplitToTokens(string expression)
		{
			var result = new List<string>();
			var expressionQueue = new Queue<char>(expression.ToCharArray());
			var digit = new List<char>();
			while (expressionQueue.TryDequeue(out var c))
			{
				switch (c)
				{
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case '.':
						digit.Add(c);
						break;
					case { } possibleOperator when _operators.ContainsKey(possibleOperator) || possibleOperator == '(' || possibleOperator == ')':
						EvaluateDigit(ref digit, ref result);
						result.Add(possibleOperator.ToString());
						break;
					default:
						throw new ArgumentException("An unknown character in the expression.", nameof(expression));
				}
			}
			EvaluateDigit(ref digit, ref result);
			return result;
		}

		private static void EvaluateDigit(ref List<char> digit, ref List<string> result)
		{
			if (digit.Any())
			{
				result.Add(new string(digit.ToArray()));
				digit.Clear();
			}
		}
	}
}