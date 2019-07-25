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
    }
}