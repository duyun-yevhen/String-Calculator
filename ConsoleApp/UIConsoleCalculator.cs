using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
	public class UIConsoleCalculator 
	{
		IConsole _console;

		public UIConsoleCalculator(IConsole console)
		{
			_console = console;
		}

		public void DoWork()
		{
			_console.WriteLine("Enter comma separated numbers (enter to exit):");
			while (true)
			{
				string input = _console.ReadLine();
				if (input == String.Empty)
					return;
				else
					_console.WriteLine("Result: " + StringCalculator.StringCalculator.Add(input));

				_console.WriteLine("Another input please (enter to exit):");
			}
		}
	}
}
