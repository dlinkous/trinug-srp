using System;

namespace ReviewManager.Services.New.Experience
{
	public class AmiableExperience : IExperience
	{
		public string GenerateRatingMessage(int ratingQuantity, byte ratingAverage)
		{
			if (ratingQuantity == 0)
			{
				return "There are no ratings.  Please consider rating this item.";
			}
			else if (ratingQuantity > 0 && ratingQuantity <= 4)
			{
				return "This item needs more ratings.  Please consider rating this item.";
			}
			else if (ratingQuantity >= 5 && ratingAverage < 4)
			{
				return "This item has been rated by many customers.";
			}
			else if (ratingQuantity >= 5 && ratingAverage >= 4)
			{
				return "Our customers love this item!";
			}
			else
			{
				throw new NotSupportedException();
			}
		}
	}
}
