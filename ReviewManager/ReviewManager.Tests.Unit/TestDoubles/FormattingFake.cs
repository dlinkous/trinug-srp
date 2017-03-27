using System;
using ReviewManager.Services.New.Formatting;

namespace ReviewManager.Tests.Unit.TestDoubles
{
	internal class FormattingFake : IFormatting
	{
		public string GetString(byte rating, string comment)
		{
			return rating.ToString();
		}

		public Tuple<byte, string> GetTuple(string value)
		{
			return new Tuple<byte, string>(byte.Parse(value), value);
		}
	}
}
