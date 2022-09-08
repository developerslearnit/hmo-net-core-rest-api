using System;

namespace AvonHMO.Entities
{
    public partial class PostCategory
    {
        public Guid CategoryId { get; set; }

        public string PostType { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }

        public string Url { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
