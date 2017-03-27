using System;
using System.Collections.Generic;
using System.Linq;
using ReviewManager.Services.New.Database;
using ReviewManager.Services.New.Experience;
using ReviewManager.Services.New.Formatting;

namespace ReviewManager.Services.New.Product
{
	public class SimpleProduct : IProduct
	{
		private readonly IFormatting formatting;
		private readonly IExperience experience;

		public SimpleProduct(IFormatting formatting, IExperience experience)
		{
			this.formatting = formatting;
			this.experience = experience;
		}

		public ProductOverview GenerateProductOverview(Guid productId, IEnumerable<Rating> ratings)
		{
			var values = ratings.Select(r => formatting.GetTuple(r.RatingInformation).Item1).ToArray();
			var quantity = values.Count();
			var average = (byte)0;
			if (quantity > 0)
			{
				average = Convert.ToByte(values.Average(v => v));
			}
			return new ProductOverview(productId, quantity, average, experience.GenerateRatingMessage(quantity, average));
		}
	}
}
