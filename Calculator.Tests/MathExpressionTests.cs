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

			[Fact]
			public void OneTest()
			{
				Assert.True(MathExpression.TryParse("1", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void TwoTest()
			{
				Assert.True(MathExpression.TryParse("2", out var result));
				Assert.Equal(2.0, result);
			}

			[Fact]
			public void TwelveTest()
			{
				Assert.True(MathExpression.TryParse("12", out var result));
				Assert.Equal(12.0, result);
			}

			[Fact]
			public void TwentyTwoTest()
			{
				Assert.True(MathExpression.TryParse("22", out var result));
				Assert.Equal(22.0, result);
			}

			[Fact]
			public void ZeroInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(0)", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void OneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(1)", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void TwoInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(2)", out var result));
				Assert.Equal(2.0, result);
			}

			[Fact]
			public void TwelveInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12)", out var result));
				Assert.Equal(12.0, result);
			}

			[Fact]
			public void TwentyInBracesTwoTest()
			{
				Assert.True(MathExpression.TryParse("(22)", out var result));
				Assert.Equal(22.0, result);
			}

			[Fact]
			public void ZeroPlusZeroTest()
			{
				Assert.True(MathExpression.TryParse("0+0", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void OnePlusOneTest()
			{
				Assert.True(MathExpression.TryParse("1+1", out var result));
				Assert.Equal(2.0, result);
			}

			[Fact]
			public void TwoPlusTwoTest()
			{
				Assert.True(MathExpression.TryParse("2+2", out var result));
				Assert.Equal(4.0, result);
			}

			[Fact]
			public void TwelvePlusTwelveTTest()
			{
				Assert.True(MathExpression.TryParse("12+12", out var result));
				Assert.Equal(24.0, result);
			}

			[Fact]
			public void TwentyTwoPlusTwentyTwoTest()
			{
				Assert.True(MathExpression.TryParse("22+22", out var result));
				Assert.Equal(44.0, result);
			}

			[Fact]
			public void ZeroPlusZeroInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(0+0)", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void OnePlusOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(1+1)", out var result));
				Assert.Equal(2.0, result);
			}

			[Fact]
			public void TwoPlusTwoInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(2+2)", out var result));
				Assert.Equal(4.0, result);
			}

			[Fact]
			public void TwelvePlusTwelveInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12+12)", out var result));
				Assert.Equal(24.0, result);
			}

			[Fact]
			public void TwentyPlusTwelveInBracesTwoTest()
			{
				Assert.True(MathExpression.TryParse("(22+22)", out var result));
				Assert.Equal(44.0, result);
			}

			[Fact]
			public void TwelvePlusTwentyOneTest()
			{
				Assert.True(MathExpression.TryParse("12+21", out var result));
				Assert.Equal(33.0, result);
			}

			[Fact]
			public void TwelvePlusTwentyOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12+21)", out var result));
				Assert.Equal(33.0, result);
			}

			[Fact]
			public void OneMultiplyByOneTest()
			{
				Assert.True(MathExpression.TryParse("1*1", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void OneMultiplyByOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(1*1)", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void TwelveMultiplyByTwelveTest()
			{
				Assert.True(MathExpression.TryParse("12*12", out var result));
				Assert.Equal(144.0, result);
			}

			[Fact]
			public void TwelveMultiplyByTwelveInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12*12)", out var result));
				Assert.Equal(144.0, result);
			}

			[Fact]
			public void TwelveMultiplyByTwentyOneTest()
			{
				Assert.True(MathExpression.TryParse("12*21", out var result));
				Assert.Equal(12.0 * 21.0, result);
			}

			[Fact]
			public void TwelveMultiplyByTwentyOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12*21)", out var result));
				Assert.Equal(12.0 * 21.0, result);
			}

			[Fact]
			public void OneMinusOneTest()
			{
				Assert.True(MathExpression.TryParse("1-1", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void OneMinusOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(1-1)", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void TwelveMinusTwelveTest()
			{
				Assert.True(MathExpression.TryParse("12-12", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void TwelveMinusTwelveInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12-12)", out var result));
				Assert.Equal(0.0, result);
			}

			[Fact]
			public void TwelveMinusTwentyOneTest()
			{
				Assert.True(MathExpression.TryParse("12-21", out var result));
				Assert.Equal(12.0 - 21.0, result);
			}

			[Fact]
			public void TwelveMinusTwentyOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12-21)", out var result));
				Assert.Equal(12.0 - 21.0, result);
			}

			[Fact]
			public void OneDividedByOneTest()
			{
				Assert.True(MathExpression.TryParse("1/1", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void OneDividedByOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(1/1)", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void TwelveDividedByTwelveTest()
			{
				Assert.True(MathExpression.TryParse("12/12", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void TwelveDividedByTwelveInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12/12)", out var result));
				Assert.Equal(1.0, result);
			}

			[Fact]
			public void TwelveDividedByTwentyOneTest()
			{
				Assert.True(MathExpression.TryParse("12/21", out var result));
				Assert.Equal(12.0 / 21.0, result);
			}

			[Fact]
			public void TwelveDividedByTwentyOneInBracesTest()
			{
				Assert.True(MathExpression.TryParse("(12/21)", out var result));
				Assert.Equal(12.0 / 21.0, result);
			}
		}
	}
}
