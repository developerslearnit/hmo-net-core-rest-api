using System;

namespace AvonHMO.Entities
{
    public partial class Comment
    {
        public Guid Id { get; set; }
        public Guid CommentParentId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
