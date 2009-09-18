using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AST = MathParser.Tree<MathParser.SyntaxToken>;

namespace MathParser.SyntaxTokenReaders
{
	public sealed class BracketSyntaxTokenReader : SyntaxTokenReader
	{
		public BracketSyntaxTokenReader()
		{
			Priority = Priorities.Brackets;
		}

		public override AST Read(LinkedList<MixedToken> tokens, Grammar grammar)
		{
			var leftNode = tokens.FindLast(t => t.IsLexicToken && t.LexicToken is LeftBracketToken);
			if (leftNode != null)
			{
				var rightNode = tokens.FindFirst(leftNode, t => t.IsLexicToken && t.LexicToken is RightBracketToken);
				if (rightNode == null)
					throw new ParserException("Unmatched left bracket.");

				var subList = leftNode.GetSubList(rightNode);
				var result = grammar.CreateAST(subList);
				tokens.AddBefore(leftNode, new MixedToken(result));
				leftNode.RemoveSubList(rightNode);

				return result;
			}

			return null;
		}
	}
}
