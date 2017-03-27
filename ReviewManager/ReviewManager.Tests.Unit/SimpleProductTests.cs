using System;
using System.Collections.Generic;
using Xunit;
using ReviewManager.Services.New.Database;
using ReviewManager.Services.New.Product;
using ReviewManager.Tests.Unit.TestDoubles;

namespace ReviewManager.Tests.Unit
{
    public class SimpleProductTests
    {
		[Fact]
		public void GenerateProductOverview_CalculatesCorrectly()
		{
			var product = new SimpleProduct(new FormattingFake(), new ExperienceStub());
			var productId = new Guid("a85920f6-28ad-439c-9651-c93e0f16af08");
			var ratings = new List<Rating>
			{
				new Rating(1, productId, (3).ToString()),
				new Rating(2, productId, (3).ToString()),
				new Rating(3, productId, (3).ToString()),
				new Rating(4, productId, (5).ToString()),
				new Rating(5, productId, (5).ToString()),
				new Rating(6, productId, (5).ToString())
			};
			var overview = product.GenerateProductOverview(productId, ratings);
			Assert.Equal(productId, overview.ProductId);
			Assert.Equal(6, overview.RatingQuantity);
			Assert.Equal(4, overview.RatingAverage);
			Assert.Equal("UnitTestRatingMessage", overview.RatingMessage);
		}
    }
}
