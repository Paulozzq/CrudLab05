using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class DbConnectionFactory
    {
        private static readonly string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=Neptuno;User Id=PauloDev;Password=12345678;TrustServerCertificate=True;";

        public static DbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
