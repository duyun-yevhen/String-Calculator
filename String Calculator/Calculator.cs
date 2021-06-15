using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
	public class Calculator
	{
		public static int Add(string numbers)
		{
			string[] _numbers;
			int result = 0;

			if (numbers == null || numbers == string.Empty)
				return 0;

			string[] delimiters = GetDelimiters(numbers);

			_numbers = GetNumbers(numbers, delimiters);

			string negatives = String.Empty;
			for (int i = 0; i < _numbers.Length; i++)
			{
				int t = int.Parse(_numbers[i]);
				if (t < 0)
					negatives += " " + t.ToString();
				if (t > 1000)
					continue;

				result += t;
			}
			if (negatives == String.Empty)
				return result;
			else
				throw new FormatException("negatives not allowed:" + negatives);
		}

		static string[] GetNumbers(string numbers, string[] delimiters)
		{
			if (numbers.StartsWith("//"))
				numbers = numbers.Substring(numbers.IndexOf(@"\n")+2);
			return numbers.Split(delimiters, StringSplitOptions.None);
		}

		static string[] GetDelimiters(string input)
		{
			
			if (input.StartsWith("//"))
			{
				int endOfdelimitersLine = input.IndexOf(@"\n");
				string[] delimiters = input[2..endOfdelimitersLine].Split("][");
				delimiters[0] = delimiters[0][1..^0];
				delimiters[^1] = delimiters[^1][0..^1];
				return delimiters;
			}
			else
			{
				return new string[] { ",", "\n" };
			}
		}
	}	
}
