using System.Text;

namespace Calculator.Models
{
	// See http://en.wikipedia.org/wiki/Shunting-yard_algorithm 

	/// <summary>
	/// Struct to make a table of operators, precedence and associativity
	/// </summary>
	public readonly struct PrecedenceAssociativity
	{
		public PrecedenceAssociativity(int p, Associativity a)
		{
			Precedence = p;
			Associativity = a;
		}
		public readonly int Precedence;
		public readonly Associativity Associativity;
	}
}
