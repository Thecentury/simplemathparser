using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	[TestClass]
	public class ConstantTests
	{
		[TestMethod]
		public void TestConstants1()
		{
			"pi+1".Parse().Evaluate().AssertIsEqualTo(Math.PI + 1);
			"PI+1".Parse().Evaluate().AssertIsEqualTo(Math.PI + 1);
			"e+1 + pi".Parse().Evaluate().AssertIsEqualTo(Math.E + 1 + Math.PI);
		}
	}
}
