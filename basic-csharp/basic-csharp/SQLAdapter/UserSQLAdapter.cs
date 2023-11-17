using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp.SQLAdapter
{
    public class UserSQLAdapter : ISQLAdapter<User>
    {
        private readonly AppDbAdapter _dbAdapter;

        public UserSQLAdapter(AppDbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User user)
        {
            string sql = "INSERT INTO Users (Id, UserName) VALUES (@Id, @UserName)";
            SqlParameter[] parameters =
            {
            new SqlParameter("@Id", user.Id),
            new SqlParameter("@UserName", user.UserName)
        };

            _dbAdapter.ExecuteNonQuery(sql, parameters);
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        // Implement other ISQLAdapter methods for User
    }

}
