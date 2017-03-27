using System;
using Xunit;
using ReviewManager.Services.New.Standards;

namespace ReviewManager.Tests.Unit
{
    public class LooseStandardsTests
    {
		[Fact]
		public void CleansCommentCorrectly()
		{
			var standards = new LooseStandards();
			var comment = standards.CleanComment("this product is poo and i want to pee on it and buy from competitor instead");
			Assert.Equal("this product is CENSORED and i want to CENSORED on it and buy from CENSORED instead", comment);
		}
    }
}
