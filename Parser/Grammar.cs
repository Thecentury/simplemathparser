using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser.Readers;
using Parser.SyntaxTokenReaders;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using AST = Parser.Tree<Parser.SyntaxToken>;

namespace Parser
{
	public class Grammar
	{
		private readonly List<TokenReader> lexicReaders = new List<TokenReader>();
		private readonly List<SyntaxTokenReader> syntaxReaders = new List<SyntaxTokenReader>();

		private ParameterTokenReader parameterReader = new ParameterTokenReader();
		private NamedConstantTokenReader namedConstantReader = new NamedConstantTokenReader();

		public Grammar()
		{
			lexicReaders.Add(new CharReader('+', new AddToken()));
			lexicReaders.Add(new CharReader('-', new SubtractToken()));
			lexicReaders.Add(new CharReader('*', new MultiplyToken()));
			lexicReaders.Add(new CharReader('/', new DivideToken()));
			lexicReaders.Add(new CharReader('(', new LeftBracketToken()));
			lexicReaders.Add(new CharReader(')', new RightBracketToken()));
			lexicReaders.Add(new WhitespaceReader());
			lexicReaders.Add(new IntegerReader());
			lexicReaders.Add(parameterReader);
			lexicReaders.Add(namedConstantReader);

			syntaxReaders.Add(new AddSyntaxTokenReader());
			syntaxReaders.Add(new ConstantSyntaxTokenReader());
			syntaxReaders.Add(new MultiplySyntaxTokenReader());
			syntaxReaders.Add(new DivideSyntaxTokenReader());
			syntaxReaders.Add(new SubtractSyntaxTokenReader());
			syntaxReaders.Add(new BracketSyntaxTokenReader());
			syntaxReaders.Add(new ParameterSyntaxTokenReader());
			syntaxReaders.Add(new ConstantSyntaxTokenReader());

			namedConstants.Add(new NamedConstant("Pi", Math.PI));
			namedConstants.Add(new NamedConstant("PI", Math.PI));
			namedConstants.Add(new NamedConstant("pi", Math.PI));

			namedConstants.Add(new NamedConstant("E", Math.E));
			namedConstants.Add(new NamedConstant("e", Math.E));
		}

		private readonly Collection<string> parameters = new Collection<string>();
		public Collection<string> Parameters
		{
			get { return parameters; }
		}

		private readonly NamedConstantCollection namedConstants = new NamedConstantCollection();
		public NamedConstantCollection NamedConstants
		{
			get { return namedConstants; }
		}

		public void AddNamedConstant(string name, double value)
		{
			namedConstants.Add(new NamedConstant(name, value));
		}

		private readonly Dictionary<string, ParameterExpression> parameterExpressions = new Dictionary<string, ParameterExpression>();
		public Dictionary<string, ParameterExpression> ParameterExpressions
		{
			get { return parameterExpressions; }
		}

		public IEnumerable<LexicToken> Parse(InputStream input)
		{
			parameterExpressions.Clear();

			// sorting to prevent situation when parameter 'x1' is parsed as parameter 'x' when 'x' is available, too.
			parameterReader.ParameterNames = parameters.OrderByDescending(s => s.Length);
			namedConstantReader.Constants = NamedConstants;

			List<LexicToken> tokens = new List<LexicToken>();

			do
			{
				var copy = input;

				foreach (var reader in lexicReaders)
				{
					LexicToken token = null;

					if (input.IsEmpty)
						break;

					input = reader.TryRead(input, out token);

					if (token != null)
					{
						tokens.Add(token);
					}
				}

				if (input == copy)
					throw new ParserException(String.Format("Unexpected character '{0}' in position {1}.", input.Content[0], input.Position));

			} while (!input.IsEmpty);

			return tokens;
		}

		// todo add external plugging-in filters for situations like '2x' or '2cos x'
		public IEnumerable<LexicToken> Filter(IEnumerable<LexicToken> tokens)
		{
			foreach (var token in tokens)
			{
				if (token is WhitespaceToken)
					continue;

				yield return token;
			}
		}

		public LinkedList<MixedToken> ConvertToMixed(IEnumerable<LexicToken> tokens)
		{
			return new LinkedList<MixedToken>(tokens.Select(t => new MixedToken(t)));
		}

		public AST CreateAST(LinkedList<MixedToken> tokens)
		{
			if (tokens.Count == 1 && tokens.First.Value.IsTree)
				return tokens.First.Value.Tree;

			syntaxReaders.Sort((r1, r2) => r1.Priority.CompareTo(r2.Priority));

			AST result = null;
			foreach (var reader in syntaxReaders)
			{
				AST tree = null;
				do
				{
					tree = reader.Read(tokens, this);
					if (tree != null)
					{
						result = tree;
					}
					else
					{
						break;
					}
				} while (tree != null);
			}

			foreach (var token in tokens)
			{
				if (!token.IsTree)
					throw new ParserException(String.Format("Unexpected token - {0}", token.LexicToken));
			}

			return result;
		}
	}
}
