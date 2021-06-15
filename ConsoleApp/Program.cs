using System;
using StringCalculator;
namespace ConsoleApp
{
	public interface IConsole
	{
		public string ReadLine();
		public void WriteLine(string value);
	}

	public class Program
	{
		public static IConsole console = new MyConsole();
		public static void Main(string[] args)
		{
			console.WriteLine("Enter comma separated numbers (enter to exit):");
			while (true)
			{
				string input = console.ReadLine();
				if (input == String.Empty)
					return;

				else
					console.WriteLine("Result: " + StringCalculator.StringCalculator.Add(input));	

				console.WriteLine("Another input please (enter to exit):");
			}
		}		
	}
}
