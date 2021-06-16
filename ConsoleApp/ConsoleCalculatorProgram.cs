using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
	public class ConsoleCalculatorProgram 
	{
		private readonly MyConsole _console;
		private readonly StringCalculator.StringCalculator _stringCalculator;

		public ConsoleCalculatorProgram(MyConsole console, StringCalculator.StringCalculator stringCalculator)
		{
			_stringCalculator = stringCalculator;
			_console = console;
		}

		public void DoWork()
		{
			_console.WriteLine("Enter comma separated numbers (enter to exit):");
			while (true)
			{
				string input = _console.ReadLine();
				if (string.IsNullOrEmpty(input))
				{
					return;
				}
				else
				{
					_console.WriteLine("Result: " + _stringCalculator.Add(input));
				}

				_console.WriteLine("Another input please (enter to exit):");
			}
		}
	}
}
