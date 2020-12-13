using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Models
{
	/// <summary>
	/// Base class for a Shunting Yard algorithm
	/// </summary>
	/// <typeparam name="TResult"></typeparam>
	/// <typeparam name="TInput"></typeparam>
	public abstract class ShuntingYardBase<TResult, TInput>
	{
		public delegate void DebugRPNDelegate(List<object> inter, List<char> opr);
		public event DebugRPNDelegate DebugRPNSteps;
		public delegate void DebugResDelegate(List<object> res, List<TResult> var);
		public event DebugResDelegate DebugResSteps;

		/// <summary>
		/// Execute the input list
		/// </summary>
		/// <param name="inputList">List of identifiers and operators</param>
		/// <param name="tagObj">An alternative object to evaluate on.</param>
		/// <returns></returns>
		public TResult Execute(List<TInput> inputList, object tagObj)
		{
			var inter = new Stack<object>(); // output stack
			var opr = new Stack<char>();    // operator stack

			foreach (var s in inputList)
			{
				if (IsNoise(s))
				{
					continue;
				}

				var o = TypecastOperator(s);
				if (IsOperator(o))
				{
					while (opr.Count > 0)
					{
						var ot = opr.Peek();
						// if ot is operator && o < ot
						if (IsOperator(ot) && (
								(Association((char)o) == Associativity.Left && Precedence((char)o, ot) <= 0) ||
								(Association((char)o) == Associativity.Right && Precedence((char)o, ot) < 0))
						)
						{
							inter.Push(opr.Pop()); // stack to output
						}
						else
						{
							break;
						}
					}
					opr.Push((char)o);
				}
				else
				{
					switch (s.ToString())
					{
						case "(":
							opr.Push('(');
							break;
						case ")":
							{
								var pe = false;
								while (opr.Count > 0)
								{   // opr to out until (
									var sc = opr.Peek();
									if (sc == '(')
									{
										pe = true;
										break;
									}
									else
										inter.Push(opr.Pop());
								}
								if (!pe) throw new Exception("No Left (");
								opr.Pop(); // pop off (
								break;
							}
						default:
							{
								if (IsIdentifier(s))
								{
									inter.Push(s);
								}
								else
								{
									if (!IsNoise(s))
									{
										throw new Exception("Unknown token");
									}
								}
								break;
							}
					}
				}

				DebugRPNSteps?.Invoke(inter.Reverse().ToList(), opr.ToList());
			}

			// put opr to out
			while (opr.Count > 0)
			{
				inter.Push(opr.Pop());
			}

			DebugRPNSteps?.Invoke(inter.Reverse().ToList(), opr.ToList());

			var res = new Queue<object>(inter.Reverse());
			var variables = new Stack<TResult>(); // vars stack
			DebugResSteps?.Invoke(res.ToList(), variables.ToList());

			// execute output stack
			while (res.Count > 0)
			{
				var dequeue = res.Dequeue();
				if (dequeue.GetType() == typeof(TInput))
				{
					variables.Push(TypecastIdentifier((TInput)dequeue, tagObj));
				}
				if (dequeue is char c)
				{
					var r = variables.Pop();
					var l = variables.TryPop(out var popResult) ? popResult : default;
					variables.Push(Evaluate(l, c, r));
				}

				DebugResSteps?.Invoke(res.ToList(), variables.ToList());
			}
			return variables.Peek(); // return result
		}

		/// <summary>
		/// Is input acceptable noise
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public abstract bool IsNoise(TInput input);

		/// <summary>
		/// Calculate the result of firstOperand and secondOperand
		/// </summary>
		/// <param name="result1"></param>
		/// <param name="opr"></param>
		/// <param name="result2"></param>
		/// <returns></returns>
		public abstract TResult Evaluate(TResult result1, char opr, TResult result2);

		/// <summary>
		/// Typecast input to Result type
		/// </summary>
		/// <param name="input">Alt. object to evaluate on</param>
		/// <param name="tagObj">Identifier to typecast</param>
		/// <returns></returns>
		public abstract TResult TypecastIdentifier(TInput input, object tagObj);

		/// <summary>
		/// Is input a identifier
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public abstract bool IsIdentifier(TInput input);

		/// <summary>
		/// Calculates operator's precedence.
		/// </summary>
		/// <param name="firstOperator">An char representing first operator.</param>
		/// <param name="secondOperator">An char representing second operator.</param>
		/// <returns>A calculated value or precedence.</returns>
		public abstract int Precedence(char firstOperator, char secondOperator);

		/// <summary>
		/// Is operator left/Right associativity
		/// </summary>
		/// <param name="mathOperator"></param>
		/// <returns></returns>
		public abstract Associativity Association(char mathOperator);

		/// <summary>
		/// Is input a operator
		/// </summary>
		/// <param name="opr"></param>
		/// <returns></returns>
		public abstract bool IsOperator(char? opr);

		/// <summary>
		/// Typecast input to a operator
		/// </summary>
		/// <param name="opr"></param>
		/// <returns></returns>
		public abstract char? TypecastOperator(TInput opr);
	}
}