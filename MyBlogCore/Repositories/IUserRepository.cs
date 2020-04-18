using System.Collections.Generic;

namespace MyBlogCore.Repositories
{
    public interface IUserRepository
    {
        List<User> getAll();

        User Add(User user);

        User Get(string id);

        User Update(string id, User modifiedUser);

        void Remove(string id);
    }
}
