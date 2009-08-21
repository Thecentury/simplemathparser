using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.LexicTokens
{
	public sealed class NamedConstantToken : LexicToken
	{
		public string Name { get; set; }
		public double Value { get; set; }

		public override string ToString()
		{
			return Name + " = " + Value;
		}
	}
}
