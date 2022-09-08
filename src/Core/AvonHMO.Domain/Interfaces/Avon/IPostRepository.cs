using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Post;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface IPostRepository
    {
        IQueryable<postCategoryViewModel> PostCategories(PagingParam param,string postType);

        IQueryable<PostViewModel> Posts(PagingParam param,string postType);

        IQueryable<PostMainCategoryModel> GetMainCategories();

        Task<PostViewModel> SinglePost(Guid postId);

        IQueryable<PostViewModel> PostsByCategoryId(PagingParam param, Guid categoryId, string searchTerm="");
        IQueryable<PostViewModel> AllPosts(PagingParam param, string categoryName);

        Task<bool> PostReadersInfo(ProspectViewModel model);

        Task<bool> AddPost(PostModel model);

    }
}
