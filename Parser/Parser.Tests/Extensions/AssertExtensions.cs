using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	public static class AssertExtensions
	{
		public static void AssertIsEqualTo<T>(this T actual, T expected)
		{
			Assert.AreEqual(expected, actual);
		}
	}
}
