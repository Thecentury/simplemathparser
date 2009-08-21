using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
	public sealed class ParameterCollection
	{
		public ParameterCollection() { }

		private readonly Dictionary<string, double> parameterValues = new Dictionary<string, double>();

		public double this[string parameterName]
		{
			get { return parameterValues[parameterName]; }
			set { parameterValues[parameterName] = value; }
		}

		public IEnumerable<string> ParameterNames
		{
			get { return parameterValues.Keys; }
		}
	}
}
