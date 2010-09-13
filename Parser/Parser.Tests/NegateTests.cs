using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathParser.Tests;

namespace Parser.Tests
{
	[TestClass]
	public class NegateTests
	{
		[TestMethod]
		public void TestNegate()
		{
			"--1".ParseAndAssert(1);
		}

		[TestMethod]
		public void TestNegateAndSum()
		{
			"--1+1".ParseAndAssert(2);
		}

		[TestMethod]
		public void TestSumAndNegate()
		{
			"1--1".ParseAndAssert(2);
		}

		[TestMethod]
		public void TestNegateAndSubtract()
		{
			"--1-1".ParseAndAssert(0);
		}

		[TestMethod]
		public void TripleNegate()
		{
			"1---1".ParseAndAssert(0);
		}

		[TestMethod]
		public void TestDoubleNegate()
		{
			"--1".ParseAndAssert(1);
		}

		[TestMethod]
		public void TestNegateAndMultiply()
		{
			"--1*2".ParseAndAssert(2);
		}

		[TestMethod]
		public void TestNegateAndPower()
		{
			"--1**1".ParseAndAssert(1);
		}

		[TestMethod]
		public void NegateFunctionCall()
		{
			"--sin(0)".ParseAndAssert(Math.Sin(0));
		}

		[TestMethod]
		public void TestNegateAndBrackets()
		{
			"-(1+1)".ParseAndAssert(-2);
		}
	}
}
