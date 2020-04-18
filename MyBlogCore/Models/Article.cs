using MyBlogCore.Utils;
using Newtonsoft.Json;
using System;

namespace MyBlogCore.Models
{
    public class Article : Entity
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Banner { get; set; }

        public Article() { }

        public Article(int authorId, string title, string content)
        {
            ValidateArguments(authorId, title, content);
            AuthorId = authorId;
            Title = title;
            Content = content;
        }

        public Article(Article article) : this(article.AuthorId, article.Title, article.Content)
        {
            Id = article.Id;
            CreatedAt = article.CreatedAt;
            LastModified = article.LastModified;
            Thumbnail = article.Thumbnail;
            Banner = article.Banner;
        }

        private void ValidateArguments(int authorId, string title, string content)
        {
            if (authorId == 0)
            {
                throw new ArgumentException("Author is not defined");
            }
            ValidationUtils.ValidateEmptyArgument(title, "Title is not defined");
            ValidationUtils.ValidateEmptyArgument(content, "Content is not defined");
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
