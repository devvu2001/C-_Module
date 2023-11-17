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
            List<User> users = new List<User>();

            string sql = "SELECT * FROM Users";
            using (var connection = new SqlConnection(_dbAdapter._connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName"))
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string userName)
        {
            string sql = "SELECT * FROM Users WHERE UserName = @UserName";
            SqlParameter[] parameters = { new SqlParameter("@UserName", userName) };

            // Sử dụng ExecuteScalar để lấy một bản ghi duy nhất từ cơ sở dữ liệu
            var result = _dbAdapter.ExecuteScalar<User>(sql, parameters);

            // Kiểm tra xem kết quả có hợp lệ hay không
            if (result != null && result is User)
            {
                return (User)result;
            }

            return null;
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
