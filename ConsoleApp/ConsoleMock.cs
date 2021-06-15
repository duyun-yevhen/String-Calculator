using ConsoleApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
	public class ConsoleMock: IConsole
	{
		public List<string> consoleList = new List<string>();
		IEnumerator enumerator;

		public ConsoleMock(string[] input)
		{
			enumerator = input.GetEnumerator();
		}

		public void WriteLine(string value)
		{
			consoleList.Add(value);
		}

		public string ReadLine()
		{
			if(enumerator.MoveNext())
				return (string)enumerator.Current;
			
			return "";
		}
	}
}
