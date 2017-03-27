using System;
using ReviewManager.Services.New.Database;
using ReviewManager.Services.New.Formatting;
using ReviewManager.Services.New.Product;
using ReviewManager.Services.New.Standards;

namespace ReviewManager.Services.New
{
    public class NewReviewManager : IReviewManager
    {
		private readonly IDatabase database;
		private readonly IFormatting formatting;
		private readonly IStandards standards;
		private readonly IProduct product;

		public NewReviewManager(IDatabase database, IFormatting formatting, IStandards standards, IProduct product)
		{
			this.database = database;
			this.formatting = formatting;
			this.standards = standards;
			this.product = product;
		}

		public void Add(int userId, Guid productId, byte rating, string comment)
		{
			database.Add(userId, productId, formatting.GetString(rating, standards.CleanComment(comment)));
		}

		public void Remove(int userId, Guid productId)
		{
			database.Remove(userId, productId);
		}

		public ProductOverview GetProductOverview(Guid productId)
		{
			return product.GenerateProductOverview(productId, database.GetRatings(productId));
		}
	}
}
