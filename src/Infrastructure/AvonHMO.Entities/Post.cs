using System;

namespace AvonHMO.Entities
{
    public partial class Post
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string PostType { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string Author { get; set; }
        public string FeaturedImage { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
