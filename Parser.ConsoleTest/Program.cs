using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestManyBrackets();
			Test1();

			Console.ReadLine();
		}

		public static void TestManyBrackets()
		{
			StringBuilder builder = new StringBuilder();
			const int num = 10000;
			for (int i = 0; i < num; i++)
			{
				builder.Append('(');
			}
			builder.Append('1');
			for (int i = 0; i < num; i++)
			{
				builder.Append(')');
			}

			Parser p = new Parser();
			var parserResult = p.Parse(builder.ToString());
			if (parserResult.Evaluate() != 1)
				throw new Exception();
		}

		static void Test1()
		{
			Parser parser = new Parser("x");
			var parsingResult = parser.Parse("x+(1)+(1)-3*(2-1)");

			Console.WriteLine(parsingResult.Tree.ToPolishInversedNotationString());

			var optimizedTree = parsingResult.Tree.Optimize();
			Console.WriteLine(optimizedTree.ToPolishInversedNotationString());

			var result = parsingResult.Evaluate(0);
		}
	}
}
