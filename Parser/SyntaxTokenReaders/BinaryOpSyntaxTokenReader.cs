﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser.SyntaxTokens;
using AST = Parser.Tree<Parser.SyntaxToken>;

namespace Parser.SyntaxTokenReaders
{
	public abstract class BinaryOpSyntaxTokenReader<TLexicToken, TSyntaxToken> : SyntaxTokenReader where TSyntaxToken : SyntaxToken, new()
	{
		private string opName;
		public string OpName
		{
			get { return opName; }
			set { opName = value; }
		}

		protected void VerifyNode(LinkedListNode<MixedToken> node, string opName)
		{
			if (node.Previous == null)
				throw new ParserException(String.Format("Operator '{0}': expected first parameter.", opName));
			if (node.Next == null)
				throw new ParserException(String.Format("Operator '{0}': expected second parameter.", opName));
		}

		public sealed override AST Read(LinkedList<MixedToken> tokens, Grammar grammar)
		{
			var node = tokens.FindFirst(t => t.IsLexicToken && t.LexicToken is TLexicToken);
			if (node != null)
			{
				VerifyNode(node, "+");

				var arg1 = node.Previous.Value;
				var arg2 = node.Next.Value;

				if (arg1.Tree == null)
					throw new Exception();
				if (arg2.Tree == null)
					throw new Exception();

				TSyntaxToken token = new TSyntaxToken();
				var tree = new AST(token);

				tree.Leafs.Add(arg1.Tree);
				tree.Leafs.Add(arg2.Tree);

				node.Value.Tree = tree;

				node.RemovePrevious();
				node.RemoveNext();

				return tree;
			}

			return null;
		}
	}

	public sealed class MultiplySyntaxTokenReader : BinaryOpSyntaxTokenReader<MultiplyToken, MultiplySyntaxToken>
	{
		public MultiplySyntaxTokenReader()
		{
			Priority = 2;
			OpName = "*";
		}
	}
	
	public sealed class DivideSyntaxTokenReader : BinaryOpSyntaxTokenReader<DivideToken, DivideSyntaxToken>
	{
		public DivideSyntaxTokenReader()
		{
			Priority = 2;
			OpName = "/";
		}
	}

	public sealed class AddSyntaxTokenReader : BinaryOpSyntaxTokenReader<AddToken, AddSyntaxToken>
	{
		public AddSyntaxTokenReader()
		{
			Priority = 3;
			OpName = "+";
		}
	}

	public sealed class SubtractSyntaxTokenReader : BinaryOpSyntaxTokenReader<SubtractToken, SubtractSyntaxToken>
	{
		public SubtractSyntaxTokenReader()
		{
			Priority = 3;
			OpName = "-";
		}
	}
}
