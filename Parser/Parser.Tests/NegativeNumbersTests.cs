using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathParser.Tests;

namespace Parser.Tests
{
	[TestClass]
	public class NegativeNumbersTests
	{
		[TestMethod]
		public void TestSubtraction()
		{
			"1-1".ParseAndAssert(0);
		}

		[TestMethod]
		public void TestSubtractionInBrackets()
		{
			"(1-1)+1".ParseAndAssert(1);
		}

		[TestMethod]
		public void TestSubtractMultiplication()
		{
			"(1)-1*(1-1)".ParseAndAssert(1);
		}
	}
}
