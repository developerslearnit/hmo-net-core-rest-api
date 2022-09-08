using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Post;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using AvonHMO.Persistence.StorageContexts.Avon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Services.Avon
{
    public class PostRepository : IPostRepository
    {
        private readonly AvonDbContext _context;
        public PostRepository(AvonDbContext context)
        {
            _context = context;
        }

        public async Task<PostViewModel> SinglePost(Guid postId)
        {
            var postQuery = from post in _context.Posts.AsNoTracking()
                            join pcat in _context.PostCategories.AsNoTracking()
on post.CategoryId equals pcat.CategoryId
                            select new PostViewModel
                            {
                                categoryId = post.CategoryId,
                                featuredImage = post.FeaturedImage,
                                postAuthor = post.Author,
                                postCategory = pcat.CategoryName,
                                postContent = post.Content,
                                postExcerpt = post.Excerpt,
                                postId = post.Id,
                                postSlug = post.Slug,
                                postTitle = post.Title,
                                publishedDate = post.PublishedDate,

                            };

            return await postQuery.FirstOrDefaultAsync(x => x.postId == postId);
        }

        public IQueryable<postCategoryViewModel> PostCategories(PagingParam param, string postType)
        {

            var skip = (param.PageNumber - 1) * param.PageSize;

            var categoryQuery = _context.PostCategories.AsNoTracking();

            //.OrderBy(x => x.CategoryName)


            if (!string.IsNullOrEmpty(postType))
            {
                categoryQuery = categoryQuery.Where(x => x.PostType == postType);
            }

            return categoryQuery.Select(x => new postCategoryViewModel
            {
                categoryId = x.CategoryId,
                categoryThumb = x.CategoryImage,
                name = x.CategoryName,
                url = x.Url
            }).Skip(skip)
                     .Take(param.PageSize);


        }

        public IQueryable<PostViewModel> Posts(PagingParam param, string postType)
        {
            var postQuery = from post in _context.Posts.AsNoTracking()
                            join pcat in _context.PostCategories.AsNoTracking()
                            on post.CategoryId equals pcat.CategoryId
                            select new PostViewModel
                            {
                                categoryId = post.CategoryId,
                                featuredImage = post.FeaturedImage,
                                postAuthor = post.Author,
                                postCategory = pcat.CategoryName,
                                postContent = post.Content,
                                postExcerpt = post.Excerpt,
                                postId = post.Id,
                                postSlug = post.Slug,
                                postTitle = post.Title,
                                publishedDate = post.PublishedDate,
                                postType = post.PostType

                            };

            if (!string.IsNullOrEmpty(postType))
            {
                postQuery = postQuery.Where(x => x.postType == postType);
            }

            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }

        public IQueryable<PostViewModel> PostsByCategoryId(PagingParam param, Guid categoryId,string searchTerm="")
        {
            var postQuery = from post in _context.Posts.AsNoTracking()
                            join pcat in _context.PostCategories.AsNoTracking()
                            on post.CategoryId equals pcat.CategoryId
                            where post.CategoryId == categoryId
                            select new PostViewModel
                            {
                                categoryId = post.CategoryId,
                                featuredImage = post.FeaturedImage,
                                postAuthor = post.Author,
                                postCategory = pcat.CategoryName,
                                postContent = post.Content,
                                postExcerpt = post.Excerpt,
                                postId = post.Id,
                                postSlug = post.Slug,
                                postTitle = post.Title,
                                publishedDate = post.PublishedDate

                            };


            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                postQuery = from post in _context.Posts.AsNoTracking()
                            join pcat in _context.PostCategories.AsNoTracking()
                            on post.CategoryId equals pcat.CategoryId
                            where post.CategoryId == categoryId
                            && post.Title.ToLower().Contains(searchTerm.ToLower())
                            select new PostViewModel
                            {
                                categoryId = post.CategoryId,
                                featuredImage = post.FeaturedImage,
                                postAuthor = post.Author,
                                postCategory = pcat.CategoryName,
                                postContent = post.Content,
                                postExcerpt = post.Excerpt,
                                postId = post.Id,
                                postSlug = post.Slug,
                                postTitle = post.Title,
                                publishedDate = post.PublishedDate

                            };
            }



            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }

        public IQueryable<PostViewModel> AllPosts(PagingParam param,string categoryName)
        {
            var postQuery = from post in _context.Posts.AsNoTracking()
                            join pcat in _context.PostCategories.AsNoTracking()
                            on post.CategoryId equals pcat.CategoryId
                            select new PostViewModel
                            {
                                categoryId = post.CategoryId,
                                featuredImage = post.FeaturedImage,
                                postAuthor = post.Author,
                                postCategory = pcat.CategoryName,
                                postContent = post.Content,
                                postExcerpt = post.Excerpt,
                                postId = post.Id,
                                postSlug = post.Slug,
                                postTitle = post.Title,
                                publishedDate = post.PublishedDate

                            };

            if(!string.IsNullOrEmpty(categoryName))
                postQuery = from post in _context.Posts.AsNoTracking()
                            join pcat in _context.PostCategories.AsNoTracking()
                            on post.CategoryId equals pcat.CategoryId
                            where pcat.CategoryName.ToLower().Contains(categoryName.ToLower())
                            select new PostViewModel
                            {
                                categoryId = post.CategoryId,
                                featuredImage = post.FeaturedImage,
                                postAuthor = post.Author,
                                postCategory = pcat.CategoryName,
                                postContent = post.Content,
                                postExcerpt = post.Excerpt,
                                postId = post.Id,
                                postSlug = post.Slug,
                                postTitle = post.Title,
                                publishedDate = post.PublishedDate

                            };
            



            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }

        public async Task<bool> PostReadersInfo(ProspectViewModel model)
        {
            var newReader = new Prospect()
            {
                DateCreated = DateTime.Now,
                Email = model.email,
                Name =model.readersName,
                PhoneNumber =model.phoneNumber
            };


            await _context.Prospects.AddAsync(newReader);

            return _context.SaveChanges() > 0;
        }

        public async Task<bool> AddPost(PostModel model)
        {
            var newPost = new Post()
            {
                Author =model.postAuthor,
                CategoryId = model.categoryId,
                FeaturedImage = model.featuredImage,
                Content =model.postContent,
                Title=model.postTitle,
                Slug = model.postTitle.Replace(" ","-").ToLower(),
                DateCreated = DateTime.Now,
                PostType = model.postType,
                PublishedDate = DateTime.Now,
                Excerpt = String.Empty,

            };

            await _context.Posts.AddAsync(newPost); 

            return _context.SaveChanges() > 0;
        }

        public IQueryable<PostMainCategoryModel> GetMainCategories()
        {
            return _context.MainCategories.AsNoTracking().Select(c => new PostMainCategoryModel { 
                code =c.Code,
                name =c.Name,
            });
        }
    }
}
