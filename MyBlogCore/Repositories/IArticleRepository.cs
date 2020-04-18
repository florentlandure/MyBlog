

using MyBlogCore.Models;
using System.Collections.Generic;

namespace MyBlogCore.Repositories
{
    public interface IArticleRepository
    {
        Article Add(Article article);
        List<Article> GetAll();
        Article Get(string id);
        Article Update(string id, Article modifiedArticle);
        void Remove(string id);
    }
}
