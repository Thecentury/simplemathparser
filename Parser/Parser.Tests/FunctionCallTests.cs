using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	[TestClass]
	public class FunctionCallTests
	{
		[TestMethod]
		public void TestFunctionCall()
		{
			"sin(1)+2".Parse().Evaluate().AssertIsEqualTo(Math.Sin(1) + 2);
		}

		[TestMethod]
		public void TestFunctionCallWithAddition()
		{
			"sin(0+0)".ParseAndAssert(Math.Sin(0));
		}

		[TestMethod]
		public void TestFunctionCallWithParameter()
		{
			"sin(x)+2".ParseWithParameters("x").Evaluate(0).AssertIsEqualTo(Math.Sin(0) + 2);
		}

		[TestMethod]
		public void TestMoreComplicatedFunctionCallWithParameter()
		{
			"sin(x+sin(x+sin(x)))+2".ParseWithParameters("x").Evaluate(0).AssertIsEqualTo(Math.Sin(0) + 2);
		}

		[TestMethod]
		public void TestNegativeFunction()
		{
			"-sin(0)".Parse().Evaluate().AssertIsEqualTo(0);
		}
	}
}
