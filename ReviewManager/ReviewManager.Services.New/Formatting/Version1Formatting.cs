using System;

namespace ReviewManager.Services.New.Formatting
{
	public class Version1Formatting : IFormatting
	{
		private const string separator = ":";

		public string GetString(byte rating, string comment)
		{
			return $"{rating}{separator}{comment}";
		}

		public Tuple<byte, string> GetTuple(string value)
		{
			var separatorLocation = value.IndexOf(separator);
			return new Tuple<byte, string>(byte.Parse(value.Substring(0, separatorLocation)), value.Substring(separatorLocation + 1));
		}
	}
}
