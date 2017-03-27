using System;
using Xunit;
using ReviewManager.Services;
using ReviewManager.Services.New;
using ReviewManager.Services.New.Database;
using ReviewManager.Services.New.Experience;
using ReviewManager.Services.New.Formatting;
using ReviewManager.Services.New.Product;
using ReviewManager.Services.New.Standards;
using ReviewManager.Services.Old;

namespace ReviewManager.Tests.Integration
{
	public class ReviewManagerTests
	{
		[Fact]
		public void GetProductOverview_HasCorrect_ProductId()
		{
			PrepareIntegrationTest();
			var manager = GetReviewManager();
			var id = new Guid("a85920f6-28ad-439c-9651-c93e0f16af08");
			var overview = manager.GetProductOverview(id);
			Assert.Equal(id, overview.ProductId);
		}

		[Fact]
		public void GetProductOverview_HasCorrect_RatingQuantity()
		{
			PrepareIntegrationTest();
			var manager = GetReviewManager();
			var id = new Guid("a85920f6-28ad-439c-9651-c93e0f16af08");
			manager.Add(1, id, 3, string.Empty);
			manager.Add(2, id, 3, string.Empty);
			manager.Add(117, id, 4, string.Empty);
			manager.Add(485, id, 3, string.Empty);
			manager.Remove(117, id);
			var overview = manager.GetProductOverview(id);
			Assert.Equal(3, overview.RatingQuantity);
		}

		[Fact]
		public void GetProductOverview_HasCorrect_RatingAverage()
		{
			PrepareIntegrationTest();
			var manager = GetReviewManager();
			var id = new Guid("a85920f6-28ad-439c-9651-c93e0f16af08");
			manager.Add(1, id, 3, string.Empty);
			manager.Add(2, id, 3, string.Empty);
			manager.Add(117, id, 4, string.Empty);
			manager.Add(485, id, 3, string.Empty);
			manager.Add(62, id, 5, string.Empty);
			manager.Add(49, id, 5, string.Empty);
			manager.Add(426, id, 5, string.Empty);
			var overview = manager.GetProductOverview(id);
			Assert.Equal(4, overview.RatingAverage);
		}

		[Fact]
		public void GetProductOverview_HasCorrect_RatingMessage()
		{
			PrepareIntegrationTest();
			var manager = GetReviewManager();
			var id = new Guid("a85920f6-28ad-439c-9651-c93e0f16af08");
			var overview = manager.GetProductOverview(id);
			Assert.Equal("There are no ratings.  Please consider rating this item.", overview.RatingMessage);
			manager.Add(1, id, 1, string.Empty);
			overview = manager.GetProductOverview(id);
			Assert.Equal("This item needs more ratings.  Please consider rating this item.", overview.RatingMessage);
			manager.Add(2, id, 2, string.Empty);
			manager.Add(3, id, 3, string.Empty);
			manager.Add(4, id, 4, string.Empty);
			manager.Add(5, id, 5, string.Empty);
			overview = manager.GetProductOverview(id);
			Assert.Equal("This item has been rated by many customers.", overview.RatingMessage);
			manager.Remove(1, id);
			manager.Remove(2, id);
			manager.Remove(3, id);
			manager.Remove(4, id);
			manager.Remove(5, id);
			manager.Add(1, id, 5, string.Empty);
			manager.Add(2, id, 5, string.Empty);
			manager.Add(3, id, 4, string.Empty);
			manager.Add(4, id, 4, string.Empty);
			manager.Add(5, id, 5, string.Empty);
			overview = manager.GetProductOverview(id);
			Assert.Equal("Our customers love this item!", overview.RatingMessage);
		}

		private void PrepareIntegrationTest()
		{
			var databaseManager = new DatabaseManager();
			databaseManager.PrepareCleanDatabase();
		}

		private IReviewManager GetReviewManager()
		{
			//var formatting = new Version1Formatting();
			//return new NewReviewManager(new SqlDatabase(), formatting, new LooseStandards(), new SimpleProduct(formatting, new AmiableExperience()));
			return new OldReviewManager();
		}
	}
}
