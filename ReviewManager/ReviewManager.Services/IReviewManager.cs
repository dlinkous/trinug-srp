using System;

namespace ReviewManager.Services
{
    public interface IReviewManager
    {
		void Add(int userId, Guid productId, byte rating, string comment);
		void Remove(int userId, Guid productId);
		ProductOverview GetProductOverview(Guid productId);
	}
}
