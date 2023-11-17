using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp.SQLAdapter
{
    public class OrderSQLAdapter : ISQLAdapter<Order>
    {
        private readonly AppDbAdapter _dbAdapter;

        public OrderSQLAdapter(AppDbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order order)
        {
            string sql = "INSERT INTO Orders (Id, UserId) VALUES (@Id, @UserId)";
            SqlParameter[] parameters =
            {
            new SqlParameter("@Id", order.Id),
            new SqlParameter("@UserId", order.User.Id)
        };

            _dbAdapter.ExecuteNonQuery(sql, parameters);

            // Insert products in the order into the OrderProduct table (assuming there's a table to store product-order relationships)
            foreach (var product in order.Products)
            {
                string productSql = "INSERT INTO OrderProduct (OrderId, ProductId) VALUES (@OrderId, @ProductId)";
                SqlParameter[] productParameters =
                {
                new SqlParameter("@OrderId", order.Id),
                new SqlParameter("@ProductId", product.Id)
            };

                _dbAdapter.ExecuteNonQuery(productSql, productParameters);
            }

            // Update other fields in the Orders table if needed
            string updateSql = "UPDATE Orders SET UserId = @UserId WHERE Id = @Id";
            SqlParameter[] updateParameters =
            {
            new SqlParameter("@UserId", order.User.Id),
            new SqlParameter("@Id", order.Id)
        };
            _dbAdapter.ExecuteNonQuery(updateSql, updateParameters);


            // Implement other ISQLAdapter methods for Order
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
