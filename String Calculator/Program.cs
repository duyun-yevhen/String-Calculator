using System;

namespace StringCalculator
{
	public class Program
	{
		public static void Main(string[] args)
		{
		
			Console.WriteLine("Enter comma separated numbers (enter to exit):");
			while (true)
			{
				string input = Console.ReadLine();
				if (input == String.Empty)
					break;
				else
				{
					Console.WriteLine("Result: " + Calculator.Add(input));
					
				}

				Console.WriteLine("Another input please (enter to exit):");
			}
			return;
		}		
	}
}
