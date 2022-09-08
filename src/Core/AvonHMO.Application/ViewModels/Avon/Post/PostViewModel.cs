using System;

namespace AvonHMO.Application.ViewModels.Avon.Post
{
    public class PostViewModel
    {
        public Guid postId { get; set; }
        public Guid categoryId { get; set; }
        public string postCategory { get; set; }
        public string postTitle { get; set; }
        public string postSlug { get; set; }
        public string postContent { get; set; }
        public string postExcerpt { get; set; }
        public string featuredImage { get; set; }
        public string postAuthor { get; set; }
        public string postType { get; set; }
        public DateTime publishedDate { get; set; }
    }


    public class PostModel
    {
        public Guid categoryId { get; set; }

        public string postTitle { get; set; }

        public string postContent { get; set; }

        public string featuredImage { get; set; }

        public string postAuthor { get; set; }

        public string postType { get; set; }
    }

    public class PostMainCategoryModel
    {
        public string code { get; set; }

        public string name { get; set; }
    }
}
