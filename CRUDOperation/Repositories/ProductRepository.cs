using Dapper;
using CRUDOperation.Model;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Data;
using System.Data.SqlClient;


namespace CRUDOperation.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<Production> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM Production.brands";
                dbConnection.Open();
                return dbConnection.Query<Production>(query).ToList();
            }
        }
    }
}
