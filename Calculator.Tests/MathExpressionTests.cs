using System;
using Calculator.Services;
using Xunit;

namespace Calculator.Tests
{
	public class MathExpressionTests
	{
		public class TryParseTests
		{
			[Fact]
			public void ZeroTest()
			{
				Assert.True(MathExpression.TryParse("0", out var result));
				Assert.Equal(0.0, result);
			}
		}
	}
}
