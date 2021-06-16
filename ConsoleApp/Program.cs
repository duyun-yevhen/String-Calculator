using System;
using StringCalculator;
namespace ConsoleApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			UIConsoleCalculator UICalc = new UIConsoleCalculator(new MyConsole());
			UICalc.DoWork();
			Console.WriteLine("Program end successfully");
		}		
	}
}
