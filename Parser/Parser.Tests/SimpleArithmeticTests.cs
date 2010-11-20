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
		public void Subtraction()
		{
			"1-2".ParseAndAssert(-1);
		}

		[TestMethod]
		public void SubtractionInBrackets()
		{
			"(2-3)".ParseAndAssert(-1);
		}

		[TestMethod]
		public void UnaryNegativeSubtractioninBrackets()
		{
			"-(2-3.1)".ParseAndAssert(1.1);
		}

		[TestMethod]
		public void Test3()
		{
			"(1-1)*-1".ParseAndAssert(0);
		}

		[TestMethod]
		public void Artur_1()
		{
			"6+((7-2)/5-9)*0.5-2".ParseAndAssert(0);
		}

		[TestMethod]
		public void Artur_2()
		{
			"6+((7-2)/5-9)*0.5-2+1".ParseAndAssert(1);
		}

		[TestMethod]
		public void Artur_3()
		{
			Parser p = new Parser();
			var result = p.Parse("6+((7-2)/5-9)*0.5-2+1");
			var str = result.Tree.ToExpressionString();
		}

		[TestMethod]
		public void Artur_4()
		{
			"6+((7-2)/5-9)*0.5-2+1+1+1+1".ParseAndAssert(4);
		}

		[TestMethod]
		public void Artur_5()
		{
			"0+(-0)-0+1".ParseAndAssert(1);
		}

		[TestMethod]
		public void Artur_6()
		{
			"0+(-0)-0+1+1+1+1+1".ParseAndAssert(5);
		}

		[TestMethod]
		public void SubtractAndAdd()
		{
			"0*1-1+2".ParseAndAssert(1);
		}
	}
}
