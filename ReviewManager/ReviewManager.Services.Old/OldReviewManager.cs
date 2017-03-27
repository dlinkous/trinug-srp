using System;
using System.Data.SqlClient;

namespace ReviewManager.Services.Old
{
	public class OldReviewManager : IReviewManager
	{
		private const string connectionString = @"Server=POSEIDON\EXPRESS1;Database=ReviewManager;Trusted_Connection=true";

		public void Add(int userId, Guid productId, byte rating, string comment)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				const string sql = @"INSERT INTO Ratings (UserId, ProductId, RatingInformation) VALUES (@UserId, @ProductId, @Rating + ':' + @Comment)";
				using (var com = new SqlCommand(sql, con))
				{
					com.Parameters.AddWithValue("UserId", userId);
					com.Parameters.AddWithValue("ProductId", productId);
					com.Parameters.AddWithValue("Rating", rating.ToString());
					com.Parameters.AddWithValue("Comment", comment.Replace("poo", "CENSORED").Replace("pee", "CENSORED").Replace("competitor", "CENSORED"));
					com.ExecuteNonQuery();
				}
			}
		}

		public void Remove(int userId, Guid productId)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				const string sql = @"DELETE Ratings WHERE UserId = @UserId AND ProductId = @ProductId";
				using (var com = new SqlCommand(sql, con))
				{
					com.Parameters.AddWithValue("UserId", userId);
					com.Parameters.AddWithValue("ProductId", productId);
					com.ExecuteNonQuery();
				}
			}
		}

		public ProductOverview GetProductOverview(Guid productId)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				const string sql = @"SELECT * FROM Ratings WHERE ProductId = @ProductId";
				using (var com = new SqlCommand(sql, con))
				{
					com.Parameters.AddWithValue("ProductId", productId);
					using (var rdr = com.ExecuteReader())
					{
						var count = 0;
						var sum = 0;
						while (rdr.Read())
						{
							count++;
							var ratingInformation = rdr.GetString(3);
							sum += byte.Parse(ratingInformation.Substring(0, ratingInformation.IndexOf(":")));
						}
						var average = (byte)0;
						if (count > 0)
						{
							average = Convert.ToByte(sum / count);
						}
						var message = String.Empty;
						if (count == 0)
						{
							message = "There are no ratings.  Please consider rating this item.";
						}
						else if (count > 0 && count <= 4)
						{
							message = "This item needs more ratings.  Please consider rating this item.";
						}
						else if(count >= 5 && average < 4)
						{
							message = "This item has been rated by many customers.";
						}
						else if(count >= 5 && average >= 4)
						{
							message = "Our customers love this item!";
						}
						else
						{
							throw new NotSupportedException();
						}
						return new ProductOverview(productId, count, average, message);
					}
				}
			}
		}
	}
}
