using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
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

		[TestMethod]
		public void CompiledParameters()
		{
			var function = "x/x+t".ParseWithParameters("x", "t").ToExpression<Func<double, double, double>>().Compile();

			Assert.AreEqual(3.0, function(1.0, 2.0));
			Assert.AreEqual(4.0, function(1.0, 3.0));
			Assert.AreEqual(4.0, function(2.0, 3.0));
		}

		[TestMethod]
		public void CompiledParameters_2()
		{
			var function = "t/t+x".ParseWithParameters("x", "t").ToExpression<Func<double, double, double>>();
			var compiled = function.Compile();

			Assert.AreEqual(2.0, compiled(1.0, 2.0));
			Assert.AreEqual(2.0, compiled(1.0, 4.0));
			Assert.AreEqual(5.0, compiled(4.0, 2.0));
		}
	}
}
