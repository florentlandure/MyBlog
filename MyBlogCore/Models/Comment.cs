using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogCore.Models
{
    public class Comment : Entity
    {
        public string AuthorId { get; set; }
        public string ArticleId { get; set; }
        public string Content { get; set; }
    }
}
