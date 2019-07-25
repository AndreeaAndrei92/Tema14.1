using System.Collections.Generic;

namespace Users.BusinessLogic
{
    public interface IUserRepository
    {
        List<User> GetAll();
        IList<User> GetAll(int id);
        User GetById(int id);
    }
}