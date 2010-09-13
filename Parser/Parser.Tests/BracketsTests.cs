using System;
using System.Collections.Generic;
using System.Linq;
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
			try
			{
				"1+(2".ParseAndAssert(3);
				Assert.Inconclusive();
			}
			catch (ParserException)
			{
			}
		}

		[TestMethod]
		public void Test3()
		{
			"1+(1+1)/4*6-2".Parse().Evaluate().AssertIsEqualTo(2.0);
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
