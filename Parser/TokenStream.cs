using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
	public class TokenStream
	{
		private readonly LinkedList<LexicToken> tokens;

		public TokenStream(IEnumerable<LexicToken> tokens)
		{
			if (tokens == null)
				throw new ArgumentNullException("tokens");

			this.tokens = new LinkedList<LexicToken>(tokens);
		}
	}
}
