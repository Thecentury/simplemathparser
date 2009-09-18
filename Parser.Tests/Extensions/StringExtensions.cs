using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathParser;
using MathParser.Tests;

namespace MathParser.Tests
{
	public static class StringExtensions
	{
		public static void ParseAndAssert(this string expected, double actual)
		{
			expected.Parse().Evaluate().AssertIsEqualTo(actual);
		}
	}
}
