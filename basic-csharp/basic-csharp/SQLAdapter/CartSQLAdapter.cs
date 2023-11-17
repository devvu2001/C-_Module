using basic_csharp.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp.SQLAdapter
{
    public class CartSQLAdapter : ISQLAdapter<Cart>
    {
        private readonly AppDbAdapter _dbAdapter;

        public CartSQLAdapter(AppDbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cart GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cart cart)
        {
            string sql = "INSERT INTO Carts (Id, UserId) VALUES (@Id, @UserId)";
            SqlParameter[] parameters =
            {
            new SqlParameter("@Id", cart.Id),
            new SqlParameter("@UserId", cart.UserId)
        };

            _dbAdapter.ExecuteNonQuery(sql, parameters);
        }

        public void Update(Cart item)
        {
            throw new NotImplementedException();
        }

        // Implement other ISQLAdapter methods for Cart
    }

}
