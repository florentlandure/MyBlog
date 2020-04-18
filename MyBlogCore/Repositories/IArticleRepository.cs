

using MyBlogCore.Models;
using System.Collections.Generic;

namespace MyBlogCore.Repositories
{
    public interface IArticleRepository
    {
        Article Add(Article article);
        List<Article> GetAll();
        Article Get(int id);
        Article Update(int id, Article modifiedArticle);
        void Remove(int id);
    }
}
