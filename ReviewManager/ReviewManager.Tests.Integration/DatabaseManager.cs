using System;
using System.Data.SqlClient;

namespace ReviewManager.Tests.Integration
{
    internal class DatabaseManager
    {
		private const string connectionString = @"Server=POSEIDON\EXPRESS1;Database=ReviewManager;Trusted_Connection=true";

		internal void PrepareCleanDatabase()
		{
			const string sql = @"
				IF EXISTS (SELECT * FROM sys.tables t WHERE t.name = 'Ratings')
				BEGIN
					DELETE Ratings
				END
				ELSE
				BEGIN
					CREATE TABLE Ratings (Id INT NOT NULL IDENTITY(1, 1), UserId INT NOT NULL, ProductId UNIQUEIDENTIFIER NOT NULL, RatingInformation VARCHAR(MAX) NOT NULL, CONSTRAINT PK_Ratings PRIMARY KEY CLUSTERED (Id ASC))
				END
				";
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand(sql, con))
				{
					com.ExecuteNonQuery();
				}
			}
		}
    }
}
