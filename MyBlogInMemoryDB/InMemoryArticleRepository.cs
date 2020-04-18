using MyBlogCore.Models;
using MyBlogCore.Repositories;
using System;
using System.Collections.Generic;

namespace MyBlogInMemoryDB
{
    public class InMemoryArticleRepository : IArticleRepository
    {
        private List<Article> _articleList;

        public InMemoryArticleRepository()
        {
            _articleList = new List<Article>();
        }

        public Article Add(Article article)
        {
            DateTime now = DateTime.Now;
            Article articleWithId = new Article(article)
            {
                Id = _articleList.Count + 1,
                CreatedAt = now,
                LastModified = now
            };
            _articleList.Add(articleWithId);
            return articleWithId;
        }

        public List<Article> GetAll()
        {
            return _articleList;
        }

        public Article Get(int id)
        {
            return _articleList.Find(article => article.Id == id);
        }

        public Article Update(int id, Article modifiedArticle)
        {
            int index = FindIndex(id);

            if (index > -1)
            {
                modifiedArticle.LastModified = DateTime.Now;
                _articleList[index] = modifiedArticle;
            }
            return modifiedArticle;
        }

        public void Remove(int id)
        {
            int index = FindIndex(id);

            if (index > -1)
            {
                _articleList.RemoveAt(index);
            }
        }

        private int FindIndex(int id)
        {
            return _articleList.FindIndex(article => article.Id == id);
        }
    }
}