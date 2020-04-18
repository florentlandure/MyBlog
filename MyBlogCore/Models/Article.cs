using MyBlogCore.Utils;
using System;

namespace MyBlogCore.Models
{
    public class Article : Entity
    {
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Banner { get; set; }

        public Article(string authorId, string title, string content)
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

        private void ValidateArguments(string authorId, string title, string content)
        {
            ValidationUtils.ValidateEmptyArgument(authorId, "Author is not defined");
            ValidationUtils.ValidateEmptyArgument(title, "Title is not defined");
            ValidationUtils.ValidateEmptyArgument(content, "Content is not defined");
        }
    }
}
