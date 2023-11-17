using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp.SQLAdapter
{
    public class ProductSQLAdapter : ISQLAdapter<Product>
    {
        private readonly AppDbAdapter _dbAdapter;

        public ProductSQLAdapter(AppDbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            string sql = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_dbAdapter._connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }


        public Product GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            string sql = "INSERT INTO Products (Id, Name, Price) VALUES (@Id, @Name, @Price)";
            SqlParameter[] parameters =
            {
            new SqlParameter("@Id", product.Id),
            new SqlParameter("@Name", product.Name),
            new SqlParameter("@Price", product.Price)
        };

            _dbAdapter.ExecuteNonQuery(sql, parameters);
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }

        // Implement other ISQLAdapter methods for Product
    }

}
