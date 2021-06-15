using System;

namespace StringCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			while(true)
			{
				Console.WriteLine("Enter comma separated numbers (enter to exit):");
				string input = Console.ReadLine();
				if (input == String.Empty)
					break;
				else
				{
					Console.WriteLine("Result: " + Calculator.Add(input));
				}
			}
			return;
		}		
	}
}
