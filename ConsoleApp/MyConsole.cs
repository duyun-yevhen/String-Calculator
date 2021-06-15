using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
	public class MyConsole : IConsole
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
		public void WriteLine(string value)
		{
			Console.WriteLine(value);
		}
	}
}
