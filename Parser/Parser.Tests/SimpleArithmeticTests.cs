using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	[TestClass]
	public class SimpleArithmeticTests
	{
		[TestMethod]
		public void Test1()
		{
			"1+(1+1)*6/4-2".ParseAndAssert(2.0);
		}

		[TestMethod]
		public void Test2()
		{
			"2+(1)+(1)-3*(2-1)".ParseAndAssert(1.0);
		}

		[TestMethod]
		public void TestSutraction()
		{
			"1-2".ParseAndAssert(-1);
		}

		[TestMethod]
		public void TestSubtractionInBrackets()
		{
			"(2-3)".ParseAndAssert(-1);
		}

		[TestMethod]
		public void TestUnaryNegativeSubtractioninBrackets()
		{
			"-(2-3.1)".ParseAndAssert(1.1);
		}

		[TestMethod]
		public void Test3()
		{
			"(1-1)*-1".ParseAndAssert(0);
		}
	}
}
