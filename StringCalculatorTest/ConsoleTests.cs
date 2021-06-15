using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ConsoleApp.Test
{


	public class ConsoleTests
	{
		[Fact]
		public void Console_OutputMessegesTest()
		{
			// arrange
			string[] expected = new string[] { "Enter comma separated numbers (enter to exit):", "Result: 43", "Another input please (enter to exit):" };
			string[] nums = new string[] { "10, 33", String.Empty};
			Program.console = new ConsoleMock(nums);
			// act
			Program.Main(null);
			var actual = ((ConsoleMock)Program.console).consoleList;
			// assert
			Assert.Equal(expected, actual);
		}
	}
}
