using System;

namespace ReviewManager.Services.New.Formatting
{
	public interface IFormatting
    {
		string GetString(byte rating, string comment);
		Tuple<byte, string> GetTuple(string value);
    }
}
