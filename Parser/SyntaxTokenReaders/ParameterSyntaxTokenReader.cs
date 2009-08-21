﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser.SyntaxTokens;
using System.Linq.Expressions;
using AST = Parser.Tree<Parser.SyntaxToken>;

namespace Parser.SyntaxTokenReaders
{
	public sealed class ParameterSyntaxTokenReader : SyntaxTokenReader
	{
		public override AST Read(LinkedList<MixedToken> tokens, Grammar grammar)
		{
			var node = tokens.FindFirst(t => t.IsLexicToken && t.LexicToken is ParameterToken);
			if (node != null)
			{
				var paramToken = node.Value.LexicToken as ParameterToken;

				var paramName = paramToken.ParameterName;
				ParameterExpression expression = null;
				if (!grammar.ParameterExpressions.TryGetValue(paramName, out expression))
				{
					expression = Expression.Parameter(typeof(double), paramName);
					grammar.ParameterExpressions.Add(paramName, expression);
				}
				ParameterSyntaxToken parameterSyntaxToken = new ParameterSyntaxToken { ParameterName = paramName, ParameterExpression = expression };

				var tree = new AST(parameterSyntaxToken);
				node.Value.Tree = tree;
				return tree;
			}
			return null;
		}
	}
}
