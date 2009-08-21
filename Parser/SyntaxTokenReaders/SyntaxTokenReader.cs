using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AST = Parser.Tree<Parser.SyntaxToken>;

namespace Parser
{
	public abstract class SyntaxTokenReader
	{
		private int priority = 0;
		public int Priority
		{
			get { return priority; }
			set { priority = value; }
		}

		public abstract AST Read(LinkedList<MixedToken> tokens, Grammar grammar);
	}
}
