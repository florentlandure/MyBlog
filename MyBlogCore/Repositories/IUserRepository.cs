using System.Collections.Generic;
using MyBlogCore.Models;

namespace MyBlogCore.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User Add(User user);

        User Get(string id);

        User Update(string id, User modifiedUser);

        void Remove(string id);

        void CheckEmailDuplicate(string email);
    }
}
