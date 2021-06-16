using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleApp.Test
{

	public class ConsoleTests
	{
		[Fact]
		public void ConsoleCalculatorProgramm_FistMessegeTest()
		{ 
			// arrange
			string expected = "Enter comma separated numbers (enter to exit):";
			string actual = string.Empty;
			var calculatorMoq = new Mock<StringCalculator.StringCalculator>();
			calculatorMoq.Setup(f => f.Add(It.IsNotNull<string>())).Returns(0);
			var consoleMoq = new Mock<MyConsole>();
			consoleMoq.Setup(a => a.ReadLine()).Returns(string.Empty);
			var calculatorProgram = new ConsoleCalculatorProgram(consoleMoq.Object, calculatorMoq.Object);

			// act
			calculatorProgram.DoWork();
			// assert
			consoleMoq.Verify(a => a.WriteLine(It.Is<string>(s => s == expected))); 
		}

		[Fact]
		public void ConsoleCalculatorProgramm_SecondAndNextMessegeTest()
		{
			// arrange
			string expected = "Another input please (enter to exit):";
			var calculatorMoq = new Mock<StringCalculator.StringCalculator>();
			calculatorMoq.Setup(f => f.Add(It.IsNotNull<string>())).Returns(0);
			var consoleMoq = new Mock<MyConsole>();
			consoleMoq.SetupSequence(a => a.ReadLine()).Returns("50")
														.Returns("10")
														.Returns(string.Empty);
			var calculatorProgram = new ConsoleCalculatorProgram(consoleMoq.Object, calculatorMoq.Object);
			// act
			calculatorProgram.DoWork();
			// assert
			consoleMoq.Verify(a => a.WriteLine(It.Is<string>(s => s == expected)),Times.AtLeast(2));
		}

		[Fact]
		public void ConsoleCalculatorProgramm_ResultMessegeTest()
		{
			// arrange
			string expected = "Result:";
			var calculatorMoq = new Mock<StringCalculator.StringCalculator>();
			calculatorMoq.Setup(f => f.Add(It.IsNotNull<string>())).Returns(0);
			var consoleMoq = new Mock<MyConsole>();
			consoleMoq.SetupSequence(a => a.ReadLine()).Returns("0")
														.Returns("1,2")
														.Returns(string.Empty);

			var calculatorProgram = new ConsoleCalculatorProgram(consoleMoq.Object, calculatorMoq.Object);
			// act
			calculatorProgram.DoWork();
			// assert
			consoleMoq.Verify(a => a.WriteLine(It.Is<string>(s => s.Contains(expected))), Times.AtLeast(2));
		}
	}
}
