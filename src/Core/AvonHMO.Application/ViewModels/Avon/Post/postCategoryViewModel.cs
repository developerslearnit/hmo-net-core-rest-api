using System;

namespace AvonHMO.Application.ViewModels.Avon.Post
{
    public class postCategoryViewModel
    {
        public Guid categoryId { get; set; }
        public string name { get; set; }
        public string postType { get; set; }
        public string categoryThumb { get; set; }

        public string  url { get; set; }
    }
}
