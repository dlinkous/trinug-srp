using System;
using System.Collections.Generic;
using ReviewManager.Services.New.Database;

namespace ReviewManager.Services.New.Product
{
    public interface IProduct
    {
		ProductOverview GenerateProductOverview(Guid productId, IEnumerable<Rating> ratings);
	}
}
