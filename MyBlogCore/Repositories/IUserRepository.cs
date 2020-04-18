using System.Collections.Generic;
using MyBlogCore.Models;

namespace MyBlogCore.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User Add(User user);

        User Get(int id);

        User Update(int id, User modifiedUser);

        void Remove(int id);

        void CheckEmailDuplicate(string email);
    }
}
