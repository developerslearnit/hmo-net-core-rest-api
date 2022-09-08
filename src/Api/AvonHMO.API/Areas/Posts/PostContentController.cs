using AvonHMO.API.Contracts;
using AvonHMO.API.Filters;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Post;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Posts
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class PostContentController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        public PostContentController(IRepositoryManager repository, IStorageRepoManager storageService, IConfiguration config)
        {
            _repository = repository;
            _storageService = storageService;
            _config = config;
        }

        [HttpGet]
        [Route(ApiRoutes.PostRoute.Category)]
        public IActionResult Categories([FromQuery] PagingParam pagination, [FromQuery] string postType)
        {
            var category = _repository.Posts.PostCategories(pagination, postType).ToList();

            return StatusCode(StatusCodes.Status200OK,
               new PagedResponse<postCategoryViewModel>
               {
                   Data = category,
                   hasError = false,
                   PageNumber = pagination.PageNumber,
                   PageSize = pagination.PageSize,
                   StatusCode = 200,

               });

        }


        [HttpGet(ApiRoutes.PostRoute.MainCategory)]
        [ProducesResponseType(typeof(ApiResponse<List<PostMainCategoryModel>>), StatusCodes.Status200OK)]
        public IActionResult MainCategories()
        {
            var category = _repository.Posts.GetMainCategories().ToList();

            if(!category.Any()) return StatusCode(StatusCodes.Status204NoContent);

            return StatusCode(StatusCodes.Status200OK,
               new ApiResponse<List<PostMainCategoryModel>>
               {
                  Data=category,
                  hasError = false,
                  StatusCode = 200,
               });
        }


        //PagedResponse<PostViewModel>

        /// <summary>
        /// Returns list of post categories
        /// </summary>
        /// <remarks>
        /// Sample post type:
        /// * video
        /// * lifestyle
        /// * press
        /// </remarks>
        /// <param name="pagination"></param>
        /// <param name="postType"></param>
        /// <response code="200">Returns list of posts</response>

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<PostViewModel>), StatusCodes.Status200OK)]
        [Route(ApiRoutes.PostRoute.Post)]
        public IActionResult PostList([FromQuery] PagingParam pagination, [FromQuery] string postType)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<PostViewModel>
                {
                    Data = _repository.Posts.Posts(pagination, postType),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<PostViewModel>), StatusCodes.Status200OK)]
        [Route(ApiRoutes.PostRoute.PostWithSearch)]
        public IActionResult PostSearchList([FromQuery] PagingParam pagination, [FromQuery] string category_name="")
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<PostViewModel>
                {
                    Data = _repository.Posts.AllPosts(pagination, category_name),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }



        [HttpGet]
        [Route(ApiRoutes.PostRoute.PostsByCat)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<PostViewModel>), StatusCodes.Status200OK)]
        public IActionResult PostByCategory([FromQuery] PagingParam pagination, [FromRoute] System.Guid categoryId,
            [FromQuery] string searchTerm="")
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<PostViewModel>
                {
                    Data = _repository.Posts.PostsByCategoryId(pagination, categoryId, searchTerm),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }

        [HttpGet]
        [Route(ApiRoutes.PostRoute.SinglePost)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<PostViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SinglePost([FromRoute] System.Guid postId)
        {

            var post = await _repository.Posts.SinglePost(postId);


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<PostViewModel>
                {
                    Data = post,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }


        [HttpPost]
        [Route(ApiRoutes.PostRoute.PostReaders)]
     
        public async Task<IActionResult> PostReadersInfo([FromBody] ProspectViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var errorMessages = ExceptionHelper.ModelRequiredFieldValidation<ProspectViewModel>(model);

            if (errorMessages.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessages)
                    });

            if (!model.email.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });

            var result = await _repository.Posts.PostReadersInfo(model);

            if (result)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<UserModel>
                    { Data = null, hasError = false, Message = "Success" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error processing the request"
                    });
            }



        }


        [HttpPost]
        [Route(ApiRoutes.PostRoute.Post)]
        public async Task<ActionResult> CreatePost()
        {
            //PostModel model = new();

            var postRequest = await Request.ReadFormAsync();
            if (postRequest == null) return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });

            if(!postRequest.Files.Any()) return StatusCode(StatusCodes.Status400BadRequest,
                     new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var categoryId = postRequest["categoryId"].FirstOrDefault();
            var postTitle = postRequest["postTitle"].FirstOrDefault();
            var postContent = postRequest["postContent"].FirstOrDefault();
            //var featuredImage = postRequest["categoryId"].FirstOrDefault();
            var postAuthor = postRequest["postAuthor"].FirstOrDefault();
            var postType = postRequest["postType"].FirstOrDefault();

            if(categoryId == null) return StatusCode(StatusCodes.Status200OK,
                     new ApiResponse<object> { Data = null,hasError=true, Message = "CategoryId is required" });

            if (postTitle == null) return StatusCode(StatusCodes.Status200OK,
                     new ApiResponse<object> { Data = null, hasError = true, Message = "Post Title is required" });

            if (postContent == null) return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object> { Data = null, hasError = true, Message = "Post Content is required" });

            var postImgFIle = postRequest.Files.FirstOrDefault();
            if(postImgFIle == null) return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object> { Data = null, hasError = true, Message = "Post featured image is required" });

            var imgExt = Path.GetExtension(postImgFIle.FileName);

            if(!StringExtensions.IsImageExtension(imgExt))
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object> { Data = null, hasError = true, Message = "Please upload a valid image" });


            var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;
            var uploadResponse = await _storageService.AzureStorage.UploadAsync(postImgFIle, storageContainer);
            if (uploadResponse != null)
            {

                var model = new PostModel()
                {
                    categoryId = System.Guid.Parse(categoryId.ToString()),
                    featuredImage = uploadResponse.fileUri,
                    postAuthor = postAuthor,
                    postContent =postContent,
                    postTitle = postTitle,
                    postType = postType                    
                };       
                


                await _repository.Posts.AddPost(model);

                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object> { Data = null, hasError = false, Message = "Post has been published successfully" });

            }


            return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object> { Data = null, hasError = true, Message = "Please upload a valid image" });


        }


    }
}
