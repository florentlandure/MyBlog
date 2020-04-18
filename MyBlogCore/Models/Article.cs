namespace MyBlogCore.Models
{
    public class Article : Entity
    {
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Banner { get; set; }
    }
}
