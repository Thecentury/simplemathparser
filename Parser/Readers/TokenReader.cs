using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Parser.Readers
{
	public abstract class TokenReader
	{
		public abstract InputStream TryRead(InputStream stream, out LexicToken token);
	}

	public class CharReader : TokenReader
	{
		private readonly char c;
		private readonly LexicToken token;
		public CharReader(char c, LexicToken token)
		{
			this.c = c;
			this.token = token;
		}

		public override InputStream TryRead(InputStream stream, out LexicToken token)
		{
			token = null;

			if (stream.Content[0] == c)
			{
				token = this.token;
				return stream.Move(1);
			}

			return stream;
		}

		public override string ToString()
		{
			return "CharReader: " + c;
		}
	}

	public class WhitespaceReader : TokenReader
	{
		public override InputStream TryRead(InputStream stream, out LexicToken token)
		{
			token = null;

			char firstChar = stream.Content[0];

			if (firstChar == ' ' ||
				firstChar == '\t' ||
				firstChar == '\n' ||
				firstChar == '\r')
			{
				token = new WhitespaceToken();
				return stream.Move(1);
			}

			return stream;
		}
	}

	public class IntegerReader : TokenReader
	{
		public override InputStream TryRead(InputStream stream, out LexicToken token)
		{
			token = null;

			char firstChar = stream.Content[0];
			int value = 0;
			if (Int32.TryParse(firstChar.ToString(), out value))
			{
				token = new DoubleToken(value);
				return stream.Move(1);
			}

			return stream;
		}
	}


	public class DoubleReader : TokenReader
	{
		public override InputStream TryRead(InputStream stream, out LexicToken token)
		{
			token = null;

			double value;
			if (Double.TryParse(stream.Content, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out value))
			{
				token = new DoubleToken(value);
				int shift = value.ToString(CultureInfo.InvariantCulture).Length;
				return stream.Move(shift);
			}

			return stream;
		}
	}
}
