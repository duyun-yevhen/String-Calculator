using System;

namespace ConsoleApp
{

	public interface IConsole
	{
		public string ReadLine();
		public void WriteLine(string value);
	}

	public class MyConsole : IConsole
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
