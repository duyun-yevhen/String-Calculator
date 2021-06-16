using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ConsoleApp.Test
{
	
	public class ConsoleTests
	{
		
		[Fact]
		public void Console_Fist_Messege()
		{
			// arrange
			string expected = "Enter comma separated numbers (enter to exit):";
			string actual = string.Empty;

			var moq = new Mock<IConsole>();
			moq.Setup(a => a.WriteLine(It.IsAny<string>())).Callback<string>((a) => actual = a);
			moq.Setup(a => a.ReadLine()).Returns(String.Empty);
			UIConsoleCalculator console = new UIConsoleCalculator(moq.Object);

			// act
			console.DoWork();
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Console_WrongInpurFormat_ThrowFormatException()
		{
			// arrange
			string expected = "Enter comma separated numbers (enter to exit):";
			string actual = string.Empty;

			var moq = new Mock<IConsole>();
			//moq.Setup(a => a.WriteLine(It.IsAny<string>())).Callback<string>((a) => actual = a);
			moq.Setup(a => a.ReadLine()).Returns("-1,-8,8");
			UIConsoleCalculator console = new UIConsoleCalculator(moq.Object);
			// act

			Assert.Throws<FormatException>( ()=>console.DoWork()); //??? и куда это совать????
			// assert
		}

		[Fact]
		public void Console_OutputMessegesTest()
		{

			// arrange
			string[] expected = new string[]
			{
				"Enter comma separated numbers (enter to exit):",
				"Result: 142",
				"Another input please (enter to exit):",
				"Result: 43",
				"Another input please (enter to exit):"
			};

			string[] nums = new string[] { "130, 12", "10, 33", String.Empty };
			List<string> actual = new List<string>();

			var moq = new Mock<IConsole>();
			moq.Setup(a => a.WriteLine(It.IsAny<string>())).Callback<string>((a) => actual.Add(a));

			moq.SetupSequence(a => a.ReadLine()).Returns(nums[0]).Returns(nums[1]).Returns(nums[2]);
			UIConsoleCalculator console = new UIConsoleCalculator(moq.Object);

			// act
			console.DoWork();
			// assert
			Assert.Equal(expected, actual);
		}
	}
}
