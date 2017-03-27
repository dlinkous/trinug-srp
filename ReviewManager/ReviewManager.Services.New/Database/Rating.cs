using System;

namespace ReviewManager.Services.New.Database
{
	public class Rating
    {
		public int UserId { get; private set; }
		public Guid ProductId { get; private set; }
		public string RatingInformation { get; private set; }

		public Rating(int userId, Guid productId, string ratingInformation)
		{
			UserId = userId;
			ProductId = productId;
			RatingInformation = ratingInformation;
		}
	}
}
