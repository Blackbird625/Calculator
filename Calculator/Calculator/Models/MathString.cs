using System.Collections.Generic;
using System.Linq;

namespace Calculator.Models
{
	internal class MathString
	{
		public string Value { get; private set; }

		private readonly Dictionary<string, string> _replacePatterns = new Dictionary<string, string>()
		{
			{ ",", "." },
			{ "-(", "(-1)*(" },
			{ "(-", "(0-" },
		};

		public MathString(string expression)
		{
			Value = expression;
			RemoveWhiteSpaces();
			ReplacePatterns();
		}

		private void ReplacePatterns()
		{
			foreach (var (oldString, newString) in _replacePatterns)
			{
				Value = Value.Replace(oldString, newString);
			}
		}

		private void RemoveWhiteSpaces() => Value = new string(Value.Where(c => !char.IsWhiteSpace(c)).ToArray());

		public override string ToString()
		{
			return Value;
		}
	}
}