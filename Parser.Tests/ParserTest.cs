using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser.Tests
{
	/// <summary>
	/// Summary description for ParserTest
	/// </summary>
	[TestClass]
	public class ParserTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestMethod1()
		{
			Parser parser = new Parser();
			var result = parser.Parse("1");
			Assert.AreEqual(1.0, result.Evaluate());
		}

		[TestMethod]
		public void TestMethod2()
		{
			Parser parser = new Parser();
			var result = parser.Parse("1+1").Evaluate();
			Assert.AreEqual(2.0, result);
		}

		[TestMethod]
		public void TestMethod3()
		{
			Parser parser = new Parser();
			bool thrown = false;
			try
			{
				var result = parser.Parse("1+").Evaluate();
			}
			catch (ParserException exc)
			{
				thrown = true;
			}

			Assert.IsTrue(thrown);
		}

		[TestMethod]
		public void TestTwoAdditions()
		{
			var parseRes = "1+1+1".Parse();
			var res = parseRes.Evaluate();
			Assert.AreEqual(3.0, res);
		}

		[TestMethod]
		public void ParseLongAdditionExpression()
		{
			StringBuilder builder = new StringBuilder("1");
			for (int i = 0; i < 1000; i++)
			{
				builder.Append("+1");
			}
			Parser parser = new Parser();
			var res = parser.Parse(builder.ToString());

			var eval = res.Evaluate();
			Assert.AreEqual(1001, eval);
		}

		[TestMethod]
		public void TestCompile1()
		{
			Parser p = new Parser();
			var result = p.Parse("1+1");
			var expr = result.ToExpression<Func<double>>();
			var res = expr.Compile();
		}
	}
}
