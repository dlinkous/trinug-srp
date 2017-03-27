using System;
using Xunit;
using ReviewManager.Services.New.Formatting;

namespace ReviewManager.Tests.Unit
{
    public class Version1FormattingTests
    {
		[Fact]
		public void ConvertsStringsAsExpected()
		{
			var formatting = new Version1Formatting();
			var str = formatting.GetString(197, "this is a comment");
			Assert.Equal("197:this is a comment", str);
			var tup = formatting.GetTuple("219:great stuff");
			Assert.Equal(219, tup.Item1);
			Assert.Equal("great stuff", tup.Item2);
		}
    }
}
