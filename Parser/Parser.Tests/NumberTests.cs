using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathParser.Tests;

namespace Parser.Tests
{
	/// <summary>
	/// Tests for numbers.
	/// </summary>
	[TestClass]
	public class NumberTests
	{
		[TestMethod]
		public void TestSimpleNumber()
		{
			"1".ParseAndAssert(1);
		}

		[TestMethod]
		public void TestLongNumber()
		{
			"47231864".ParseAndAssert(47231864);
		}

		[TestMethod]
		public void TestFractionNumber()
		{
			"0.134567".ParseAndAssert(0.134567);
		}

		[TestMethod]
		public void TestNegativeNumber()
		{
			"-1".ParseAndAssert(-1);
		}

		[TestMethod]
		public void TestNegativeFractional()
		{
			"-0.2345789".ParseAndAssert(-0.2345789);
		}

		[TestMethod]
		public void TestWhitespaceBefore()
		{
			" 1".ParseAndAssert(1);
		}

		[TestMethod]
		public void TestWhitespaceAfter()
		{
			"1 ".ParseAndAssert(1);
		}
	}
}
