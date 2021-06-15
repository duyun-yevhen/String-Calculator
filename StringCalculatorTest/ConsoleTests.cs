using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Moq;

namespace ConsoleApp.Test
{
	public class ConsoleTests
	{
		[Fact]
		public void Console_OutputMessegesTest()
		{
			int i = 0;
			// arrange
			string[] expected = new string[] { "Enter comma separated numbers (enter to exit):", "Result: 43", "Another input please (enter to exit):" };
			string[] nums = new string[] { "10, 33", String.Empty};
			List<string> actual = new List<string>();

			var moq = new Mock<IConsole>();
			moq.Setup(a => a.ReadLine()).Returns(() => { return nums[i++]; });
			moq.Setup(a => a.WriteLine(It.IsAny<string>())).Callback<string>((a)=> actual.Add(a));

			Program.console = moq.Object;
			// act
			Program.Main(null);
			// assert
			Assert.Equal(expected, actual);
		}
	}
}
