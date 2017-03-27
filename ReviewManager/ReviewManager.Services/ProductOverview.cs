using System;

namespace ReviewManager.Services
{
    public class ProductOverview
    {
		public Guid ProductId { get; private set; }
		public int RatingQuantity { get; private set; }
		public byte RatingAverage { get; private set; }
		public string RatingMessage { get; private set; }

		public ProductOverview(Guid productId, int ratingQuantity, byte ratingAverage, string ratingMessage)
		{
			ProductId = productId;
			RatingQuantity = ratingQuantity;
			RatingAverage = ratingAverage;
			RatingMessage = ratingMessage;
		}
    }
}
