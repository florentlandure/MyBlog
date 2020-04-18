using NUnit.Framework;
using MyBlogCore;
using System.Collections.Generic;
using MyBlogCore.Repositories;
using MyBlogInMemoryDB;
using System;

namespace MyBlogUnitTests
{
    class UserTests
    {
        IUserRepository inMemoryUserRepository;
        User user1, user2;

        [SetUp]
        public void Setup()
        {
            inMemoryUserRepository = new InMemoryUserRepository();
            user1 = new User("user1@email.com", "User 1");
            user2 = new User("user2@email.com", "User 2");
        }

        [Test]
        public void AddOneUserTest()
        {
            user1 = inMemoryUserRepository.Add(user1);
            List<User> userList = inMemoryUserRepository.getAll();
            Assert.AreEqual(userList.Count, 1);
            Assert.AreEqual(userList[0].Id, "1");
            Assert.AreSame(userList[0], user1);
        }

        [Test]
        public void AddMultipleUsersTest()
        {
            user1 = inMemoryUserRepository.Add(user1);
            user2 = inMemoryUserRepository.Add(user2);
            List<User> userList = inMemoryUserRepository.getAll();
            Assert.AreEqual(userList.Count, 2);
            Assert.AreEqual(userList[0], user1);
            Assert.AreEqual(userList[1], user2);
            Assert.AreEqual(userList[0].Id, "1");
            Assert.AreEqual(userList[1].Id, "2");
        }

        [Test]
        public void GetUserTest()
        {
            IUserRepository inMemoryUserRepository = new InMemoryUserRepository();

            inMemoryUserRepository.Add(user1);
            user2 = inMemoryUserRepository.Add(user2);
            Assert.AreEqual(inMemoryUserRepository.Get(user2.Id), user2);
        }

        [Test]
        public void UpdateUserTest()
        {
            user1 = inMemoryUserRepository.Add(user1);
            User updatedUser = new User(user1)
            {
                Password = "Password"
            };
            updatedUser = inMemoryUserRepository.Update(user1.Id, updatedUser);
            Assert.AreEqual(updatedUser.Id, user1.Id);
            Assert.AreNotEqual(updatedUser.Password, user1.Password);
            Assert.AreNotEqual(user1.LastModified, updatedUser.LastModified);
        }

        [Test]
        public void UpdateUserFailTest()
        {
            user1.Id = "1";
            User updatedUser = new User(user1)
            {
                Password = "Password"
            };
            updatedUser = inMemoryUserRepository.Update(user1.Id, updatedUser);
            Assert.AreEqual(updatedUser.Id, user1.Id);
            Assert.AreEqual(user1.LastModified, updatedUser.LastModified);
        }

        [Test]
        public void DeleteUserTest()
        {
            user1 = inMemoryUserRepository.Add(user1);
            user2 = inMemoryUserRepository.Add(user2);
            inMemoryUserRepository.Remove(user1.Id);
            Assert.AreEqual(inMemoryUserRepository.getAll().Count, 1);
        }
    }
}
