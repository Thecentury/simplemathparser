﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser.SyntaxTokens;
using AST = Parser.Tree<Parser.SyntaxToken>;

namespace Parser.SyntaxTokenReaders
{
	public class ConstantSyntaxTokenReader : SyntaxTokenReader
	{
		public override AST Read(LinkedList<MixedToken> tokens, Grammar grammar)
		{
			var node = tokens.FindFirst(t => t.IsLexicToken && t.LexicToken is DoubleToken);
			if (node != null)
			{
				var doubleToken = node.Value.LexicToken as DoubleToken;
				AST tree = new AST(new DoubleConstantSyntaxToken { Value = doubleToken.Value });

				node.Value.Tree = tree;

				return tree;
			}
			return null;
		}
	}
}
