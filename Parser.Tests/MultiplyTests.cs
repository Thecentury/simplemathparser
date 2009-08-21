using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	[TestClass]
	public class MultiplyTests
	{
		[TestMethod]
		public void TestMultiply()
		{
			Parser p = new Parser();
			var pRes = p.Parse("1*2");
			var res = pRes.Evaluate();
			Assert.AreEqual(2.0, res);
		}

		[TestMethod]
		public void TestMultiplyAndAdd()
		{
			"1+2*3".Parse().Evaluate().AssertIsEqualTo(7);
			"2*3+1".Parse().Evaluate().AssertIsEqualTo(7);
		}
	}
}
