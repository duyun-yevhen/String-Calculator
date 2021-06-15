using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace StringCalculator.Test
{


	public class ConsoleTests
	{
		[Fact]
		public void Console_InputTest()
		{
			// arrange
			string expected = "Result: 25" + Environment.NewLine + "Another input please (enter to exit):";
			string nums = "10, 15\n\r";
			ConsoleMock console = new ConsoleMock(nums);
			// act
			string actual = console.Main(); 
			// assert
			Assert.Equal(expected, actual);
		}
	}




	class ConsoleMock
	{
		
		StringBuilder stringBuilder;
		TextWriter stringWriter;
		TextReader stringReader;

		public ConsoleMock(string numbers)
		{
			stringBuilder = new StringBuilder();
			stringWriter = new StringWriter(stringBuilder);
			Console.SetOut(stringWriter);
			stringReader = new StringReader(numbers); 
			Console.SetIn(stringReader);
		}
		
		public string Main()
		{
			Program.Main(null);
			string[] consoleOut = stringBuilder.ToString().Split(Environment.NewLine);
			return consoleOut[^3] + Environment.NewLine + consoleOut[^2];
		}
	}
}
