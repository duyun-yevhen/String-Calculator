using Moq;
using Xunit;

namespace ConsoleApp.Test
{

	public class ConsoleCalculatorProgramTests
	{
		[Fact]
		public void ConsoleCalculatorProgramm_WelcomeMessege()
		{ 
			// arrange
			var calculatorMock = new Mock<StringCalculator.StringCalculator>();
			calculatorMock.Setup(f => f.Add(It.IsNotNull<string>())).Returns(0);

			var consoleMock = new Mock<MyConsole>();
			consoleMock.Setup(a => a.ReadLine()).Returns(string.Empty);

			var calculatorProgram = new ConsoleCalculatorProgram(consoleMock.Object, calculatorMock.Object);

			// act
			calculatorProgram.DoWork();
			// assert
			consoleMock.Verify(a => a.WriteLine(It.Is<string>(s => s == "Enter comma separated numbers (enter to exit):"))); 
		}

		[Fact]
		public void ConsoleCalculatorProgramm_SecondAndNextMessege()
		{
			// arrange
			var calculatorMock = new Mock<StringCalculator.StringCalculator>();
			calculatorMock.Setup(f => f.Add(It.IsNotNull<string>())).Returns(0);

			var consoleMock = new Mock<MyConsole>();
			consoleMock.SetupSequence(a => a.ReadLine()).Returns("50")
														.Returns("10")
														.Returns(string.Empty);

			var calculatorProgram = new ConsoleCalculatorProgram(consoleMock.Object, calculatorMock.Object);
			// act
			calculatorProgram.DoWork();
			// assert
			consoleMock.Verify(a => a.WriteLine(It.Is<string>(s => s == "Another input please (enter to exit):")),Times.AtLeast(2));
		}

		[Fact]
		public void ConsoleCalculatorProgramm_ResultMessege()
		{
			// arrange
			var calculatorMock = new Mock<StringCalculator.StringCalculator>();
			calculatorMock.Setup(f => f.Add(It.IsNotNull<string>())).Returns(11);

			var consoleMock = new Mock<MyConsole>();
			consoleMock.SetupSequence(a => a.ReadLine()).Returns("11")
														.Returns(string.Empty);

			var calculatorProgram = new ConsoleCalculatorProgram(consoleMock.Object, calculatorMock.Object);
			// act
			calculatorProgram.DoWork();
			// assert
			consoleMock.Verify(a => a.WriteLine(It.Is<string>(s => s == "Result: 11")));
		}
	}
}
