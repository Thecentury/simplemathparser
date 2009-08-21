using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser.Tests
{
	[TestClass]
	public class ParameterTests
	{
		[TestMethod]
		public void TestParameter1()
		{
			Parser parser = new Parser("x");
			var parserResult = parser.Parse("x+2");
			EvaluationContext context = new EvaluationContext();
			context.Parameters["x"] = 1;
			var result = parserResult.Evaluate(context);

			result.AssertIsEqualTo(3);
		}

		[TestMethod]
		public void TestParameter2()
		{
			"t/2".ParseWithParameters("t").Evaluate(2.0).AssertIsEqualTo(1);
		}

		[TestMethod]
		public void TestCompiledParameter1()
		{
			"t + t".ParseWithParameters("t").ToExpression<Func<double, double>>().Compile()(10).AssertIsEqualTo(20);
		}
	}
}
