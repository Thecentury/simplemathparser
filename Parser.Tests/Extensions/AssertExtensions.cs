using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParser.Tests
{
	public static class AssertExtensions
	{
		public static void AssertIsEqualTo<T>(this T expected, T actual)
		{
			Assert.AreEqual(expected, actual);
		}
	}
}
