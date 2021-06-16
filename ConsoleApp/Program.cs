using System;
using StringCalculator;
namespace ConsoleApp
{
	public class Program
	{
		public static void Main(params string[] args)
		{
			ConsoleCalculatorProgram UICalc = new ConsoleCalculatorProgram(new MyConsole(), new StringCalculator.StringCalculator());
			UICalc.DoWork();
			Console.WriteLine("Program end successfully");
		}		
	}
}
