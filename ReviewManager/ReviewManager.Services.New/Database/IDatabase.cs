using System;
using System.Collections.Generic;

namespace ReviewManager.Services.New.Database
{
    public interface IDatabase
    {
		void Add(int userId, Guid productId, string ratingInformation);
		void Remove(int userId, Guid productId);
		IEnumerable<Rating> GetRatings(Guid productId);
    }
}
