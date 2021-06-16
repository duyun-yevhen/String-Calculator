using System;

namespace ConsoleApp
{
	public class MyConsole
	{
		public virtual string ReadLine()
		{
			return Console.ReadLine();
		}

		public virtual void WriteLine(string value)
		{
			Console.WriteLine(value);
		}
	}
}
