using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	[TestClass]
	public class BracketsTests
	{
		[TestMethod]
		public void Test1()
		{
			"(1)".Parse().Evaluate().AssertIsEqualTo(1);
		}

		[TestMethod]
		public void Test2()
		{
			"(1)+(1)".Parse().Evaluate().AssertIsEqualTo(2);
		}

		[TestMethod]
		public void TestComplicatedArithmetic()
		{
			"(1+2)*1".ParseAndAssert(3);
		}

		[TestMethod]
		public void TestBracketMismatch()
		{
			var thrown = false;
			try
			{
				"1+(2".ParseAndAssert(3);
			}
			catch (ParserException)
			{
				thrown = true;
			}

			Assert.IsTrue(thrown);
		}

		[TestMethod]
		public void TestManyBrackets()
		{
			StringBuilder builder = new StringBuilder();
			const int num = 1000;
			for (int i = 0; i < num; i++)
			{
				builder.Append('(');
			}
			builder.Append('1');
			for (int i = 0; i < num; i++)
			{
				builder.Append(')');
			}

			builder.ToString().ParseAndAssert(1);
		}
	}
}
