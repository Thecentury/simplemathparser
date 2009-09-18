using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	[TestClass]
	public class PowerOperatorTest
	{
		[TestMethod]
		public void TestPowerOperator()
		{
			"x^2+2*x+1".ParseWithParameters("x").Evaluate(0).AssertIsEqualTo(1);
			"x^2*2+2*x+1".ParseWithParameters("x").Evaluate(1).AssertIsEqualTo(5);
			"x^(2*2)+2*x+1".ParseWithParameters("x").Evaluate(2).AssertIsEqualTo(21);
		}
	}
}
