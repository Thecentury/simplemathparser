using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser.Tests
{
	[TestClass]
	public class SimpleArithmeticTests
	{
		[TestMethod]
		public void Test1()
		{
			"1+2*6/4-2".Parse().Evaluate().AssertIsEqualTo(2.0);
		}
	}
}
