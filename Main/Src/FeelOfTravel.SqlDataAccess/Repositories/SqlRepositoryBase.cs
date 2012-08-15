using System;
using System.Data;
using System.Data.SqlClient;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlRepositoryBase
    {
        public static DbDataContext DataContext { get; private set; }

        public SqlRepositoryBase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            if (DataContext != null)
            {
                return;
            }

            IDbConnection connection = new SqlConnection(connectionString);
            DataContext = new DbDataContext(connection);
        }  
    }
}