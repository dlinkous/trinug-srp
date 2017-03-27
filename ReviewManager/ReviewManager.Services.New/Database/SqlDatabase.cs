using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ReviewManager.Services.New.Database
{
	public class SqlDatabase : IDatabase
	{
		private const string connectionString = @"Server=POSEIDON\EXPRESS1;Database=ReviewManager;Trusted_Connection=true";

		public void Add(int userId, Guid productId, string ratingInformation)
		{
			const string sql = @"INSERT INTO Ratings (UserId, ProductId, RatingInformation) VALUES (@UserId, @ProductId, @RatingInformation)";
			ExecuteNonQuery(sql, p => 
			{
				p.AddWithValue("UserId", userId);
				p.AddWithValue("ProductId", productId);
				p.AddWithValue("RatingInformation", ratingInformation);
			});
		}

		public void Remove(int userId, Guid productId)
		{
			const string sql = @"DELETE Ratings WHERE UserId = @UserId AND ProductId = @ProductId";
			ExecuteNonQuery(sql, p =>
			{
				p.AddWithValue("UserId", userId);
				p.AddWithValue("ProductId", productId);
			});
		}

		public IEnumerable<Rating> GetRatings(Guid productId)
		{
			const string sql = @"SELECT * FROM Ratings WHERE ProductId = @ProductId";
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand(sql, con))
				{
					com.Parameters.AddWithValue("ProductId", productId);
					using (var rdr = com.ExecuteReader())
					{
						while (rdr.Read())
						{
							yield return new Rating(rdr.GetInt32(1), rdr.GetGuid(2), rdr.GetString(3));
						}
					}
				}
			}
		}

		private void ExecuteNonQuery(string sql, Action<SqlParameterCollection> fillParameters)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand(sql, con))
				{
					fillParameters(com.Parameters);
					com.ExecuteNonQuery();
				}
			}
		}
	}
}
