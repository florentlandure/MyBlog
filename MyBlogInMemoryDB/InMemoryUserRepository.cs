using MyBlogCore.Models;
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

        public List<User> GetAll()
        {
            return _userList;
        }

        public User Add(User user)
        {
            CheckEmailDuplicate(user.Email);
            DateTime now = DateTime.Now;
            User userWithId = new User(user.Email, user.Name)
            {
                Id = _userList.Count + 1,
                CreatedAt = now,
                LastModified = now
            };
            _userList.Add(userWithId);
            return userWithId;
        }

        public User Get(int id)
        {
            return _userList.Find(user => user.Id == id);
        }

        public User Update(int id, User modifiedUser)
        {
            int index = FindIndex(id);

            if (index > -1)
            {
                modifiedUser.LastModified = DateTime.Now;
                _userList[index] = modifiedUser;
            }
            return modifiedUser;
        }

        public void Remove(int id)
        {
            int index = FindIndex(id);
            
            if (index > -1)
            {
                _userList.RemoveAt(index);
            }
        }

        public void CheckEmailDuplicate(string email)
        {
            int index = _userList.FindIndex(user => user.Email == email);
            if (index > -1)
            {
                throw new Exception("Email already used");
            }
        }

        private int FindIndex(int id)
        {
            return _userList.FindIndex(user => user.Id == id);
        }
    }
}
