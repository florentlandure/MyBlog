using MyBlogCore;
using MyBlogCore.Repositories;
using System;
using System.Collections.Generic;

namespace MyBlogInMemoryDB
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _userList;

        public InMemoryUserRepository()
        {
            _userList = new List<User>();
        }

        public List<User> getAll()
        {
            return _userList;
        }

        public User Add(User user)
        {
            DateTime now = DateTime.Now;
            User userWithId = new User(user.Email, user.Name)
            {
                Id = $"{_userList.Count + 1}",
                CreatedAt = now,
                LastModified = now
            };
            _userList.Add(userWithId);
            return userWithId;
        }

        public User Get(string id)
        {
            return _userList.Find(user => user.Id == id);
        }

        public User Update(string id, User modifiedUser)
        {
            int index = _userList.FindIndex(user => user.Id == id);

            if (index > -1)
            {
                modifiedUser.LastModified = DateTime.Now;
                _userList[index] = modifiedUser;
            }
            return modifiedUser;
        }

        public void Remove(string id)
        {
            int index = _userList.FindIndex(user => user.Id == id);
            
            if (index > -1)
            {
                _userList.RemoveAt(index);
            }
        }
    }
}
