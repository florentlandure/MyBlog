using NUnit.Framework;
using MyBlogCore.Repositories;
using MyBlogCore.Models;
using System;
using System.Collections.Generic;
using MyBlogInMemoryDB;

namespace MyBlogUnitTests
{
    class ArticleTests
    {
        IArticleRepository inMemoryArticleRepository;
        Article article1, article2;

        [SetUp]
        public void Setup()
        {
            inMemoryArticleRepository = new InMemoryArticleRepository();
            article1 = new Article(1, "Title 1", "Content 1");
            article2 = new Article(2, "Title 2", "Content 2");
        }

        [Test]
        public void InvalidArticleAuthor()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(delegate
            {
                new Article(0, "", "");
            });
            Assert.AreEqual(exception.Message, "Author is not defined");
        }

        [Test]
        public void InvalidArticleTitle()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(delegate
            {
                new Article(1, "", "");
            });
            Assert.AreEqual(exception.Message, "Title is not defined");
        }

        [Test]
        public void InvalidArticleContent()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(delegate
            {
                new Article(1, "Title", "");
            });
            Assert.AreEqual(exception.Message, "Content is not defined");
        }

        [Test]
        public void ValidArticleTest()
        {
            Assert.AreEqual(article1.AuthorId, 1);
            Assert.AreEqual(article1.Title, "Title 1");
            Assert.AreEqual(article1.Content, "Content 1");
        }

        [Test]
        public void AddOneArticleTest()
        {
            article1 = inMemoryArticleRepository.Add(article1);
            List<Article> articleList = inMemoryArticleRepository.GetAll();
            Assert.AreEqual(articleList.Count, 1);
            Assert.AreEqual(article1.Id, 1);
            Assert.AreNotEqual(article1.CreatedAt, new DateTime());
            Assert.AreNotEqual(article1.LastModified, new DateTime());
        }

        [Test]
        public void AddMultipleArticlesTest()
        {
            article1 = inMemoryArticleRepository.Add(article1);
            article2 = inMemoryArticleRepository.Add(article2);
            List<Article> articleList = inMemoryArticleRepository.GetAll();
            Assert.AreEqual(articleList.Count, 2);
            Assert.AreEqual(articleList[0], article1);
            Assert.AreEqual(articleList[1], article2);
            Assert.AreEqual(article1.Id, 1);
            Assert.AreEqual(article2.Id, 2);
        }

        [Test]
        public void GetArticleTest()
        {
            article1 = inMemoryArticleRepository.Add(article1);
            article2 = inMemoryArticleRepository.Add(article2);
            Assert.AreEqual(inMemoryArticleRepository.Get(article1.Id), article1);
            Assert.AreEqual(inMemoryArticleRepository.Get(article2.Id), article2);
        }

        public void UpdateUserTest()
        {
            article1 = inMemoryArticleRepository.Add(article1);
            Article updatedArticle = new Article(article1)
            {
                Thumbnail = "Thumbnail"
            };
            updatedArticle = inMemoryArticleRepository.Update(article1.Id, updatedArticle);
            Assert.AreEqual(updatedArticle.Id, article1.Id);
            Assert.AreNotEqual(updatedArticle.Thumbnail, article1.Thumbnail);
            Assert.AreNotEqual(article1.LastModified, updatedArticle.LastModified);
        }

        [Test]
        public void UpdateArticleFailTest()
        {
            article1.Id = 1;
            Article updatedArticle = new Article(article1)
            {
                Thumbnail = "Thumbnail"
            };
            updatedArticle = inMemoryArticleRepository.Update(article1.Id, updatedArticle);
            Assert.AreEqual(updatedArticle.Id, article1.Id);
            Assert.IsNull(article1.Thumbnail);
            Assert.AreEqual(article1.LastModified, updatedArticle.LastModified);
        }

        [Test]
        public void DeleteArticleTest()
        {
            article1 = inMemoryArticleRepository.Add(article1);
            article2 = inMemoryArticleRepository.Add(article2);
            inMemoryArticleRepository.Remove(article1.Id);
            Assert.AreEqual(inMemoryArticleRepository.GetAll().Count, 1);
        }
    }
}
