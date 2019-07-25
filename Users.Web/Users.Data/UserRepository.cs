using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Users.BusinessLogic;

namespace Users.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<User> GetAll()
        {
            var list = new List<User>();

            var query = $"select * from users";
            var command = new SqlCommand
            {
                CommandText = query,
                Connection = _connection
            };

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var userId = (int)reader["id"];
                var userName = reader["username"] as string;
                var email = reader["email"] as string;
                var description = reader["description"] as string;
                var city = reader["city"] as string;
                var street = reader["street"] as string;

                list.Add(new User
                {
                    Id = userId,
                    Email = email,
                    Description = description,
                    Username = userName,
                    Street = street,
                    City = city
                });
            }

            return list;
        }

        public IList<User> GetAll()
        {
            string sqlString = "SELECT * FROM USERS";
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            // Create list to store users
            IList<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = (int)reader["ID"],
                    UserName = reader["USERNAME"] as string,
                    Email = reader["EMAIL"] as string,
                    Description = reader["DESCRIPTION"] as string,
                    City = reader["CITY"] as string,
                    Street = reader["STREET"] as string
                });
            }
            sqlConnection.Close();
            return users;
        }

        public User GetById(int id)
        {
            User user = new User();
            string sqlString = "SELECT * FROM USERS WHERE ID = @id";
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter { ParameterName = "id", Value = id });
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                user.Id = (int)reader["ID"];
                user.UserName = reader["USERNAME"] as string;
                user.Email = reader["EMAIL"] as string;
                user.Description = reader["DESCRIPTION"] as string;
                user.City = reader["CITY"] as string;
                user.Street = reader["STREET"] as string;
            }

            sqlConnection.Close();
            return user;
        }
    }
}