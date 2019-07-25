using System.Collections.Generic;

namespace Users.BusinessLogic
{
    public interface IUserRepository
    {
        List<User> GetAll();
    }
}