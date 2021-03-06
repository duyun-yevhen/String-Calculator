using System;
using Xunit;
using StringCalculator;

namespace StringCalculator.Test
{
	public class StringCalculatorTests
	{
		[Fact]
		public void Add_EmptyString_ReturnsZero()
		{
			// arrange
			int expected = 0;
			string num = String.Empty;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_SingleNumber_ReturnsSameNumber()
		{
			// arrange
			int expected = 15;
			string num = "15";
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_TwoNumbers_ReturnsSum()
		{
			// arrange
			string num = "10, 15";
			int expected = 10 + 15;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_MultipleNumbers_ReturnTotalSum()
		{
			// arrange
			string num = "10, 15, 50, 48";
			int expected = 10 + 15 + 50 + 48;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_NewLineSeparator_ReturnTotalSum()
		{
			// arrange
			string num = "10\n 15, 50\n 48";
			int expected = 10 + 15 + 50 + 48;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_WrongInputFormat_ThrowFormatException()
		{
			// arrange
			string num = "1,\n";
			// act
			Action actual = () => Calculator.Add(num);
			// assert
			Assert.Throws<FormatException>(actual);
		}

		[Fact]
		public void Add_DifferentDelimiter_ReturnTotalSum()
		{
			// arrange
			string num = @"//[s]\n10s15s50s48";
			int expected = 10 + 15 + 50 + 48;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_NegativesInInput_ThrowFormatException()
		{
			// arrange
			string num = "-1,-8,8";
			string expected = "negatives not allowed: -1 -8";
			// act
			string actual = Assert.Throws<FormatException>(() => Calculator.Add(num)).Message;
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_NumberBiggerThan1000ShouldIgnored()
		{
			// arrange
			string num = "1001, 5, 10";
			int expected = 5 + 10;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_AnyLengthOfDelimiter()
		{
			// arrange
			string num = @"//[wse]\n10wse15wse50wse48";
			int expected = 10 + 15 + 50 + 48;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_MultipleDelimiter()
		{
			// arrange
			string num = @"//[w]]][`-][-]\n10`-15w]]50-48";
			int expected = 10 + 15 + 50 + 48;
			// act
			int actual = Calculator.Add(num);
			// assert
			Assert.Equal(expected, actual);
		}
	}

}
