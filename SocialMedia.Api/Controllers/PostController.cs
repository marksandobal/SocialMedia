using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Data;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;
        public PostController(IPostService postService, IMapper mapper, IUrlService urlService)
        {
            _postService = postService;
            _mapper = mapper;
            _urlService = urlService;
        }
        // GET: api/<PostController>
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PostsDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostsDto>>))]
        public async Task<IActionResult> GetPosts([FromQuery] PostQueryFilter filters)
        {
            var posts = _postService.GetPosts(filters);
            //Con el mapper no necesitas mapperar manualmente el objeto de salida o entrada
            var postDto = _mapper.Map<IEnumerable<PostsDto>>(posts);

            var metadata = new MetaData()
            {
                TotalCount = posts.TotalCount,
                PageSize = posts.PageSize,
                CurrentPage = posts.CurrentPage,
                TotalPages = posts.TotalPages,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = _urlService.GetPostPaginationUrl(filters, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _urlService.GetPostPaginationUrl(filters, Url.RouteUrl(nameof(GetPosts))).ToString()
            };

            var response = new ApiResponse<IEnumerable<PostsDto>>(postDto) 
            { 
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPostById(id);
            var postDto = _mapper.Map<PostsDto>(post);
            var response = new ApiResponse<PostsDto>(postDto);
            return Ok(response);
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostsDto postDto)
        {
            var post = _mapper.Map<Posts>(postDto);
            await _postService.InsertPost(post);
            postDto = _mapper.Map<PostsDto>(post);
            var response = new ApiResponse<PostsDto>(postDto);
            return Ok(response);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostsDto postDto)
        {
            var post = _mapper.Map<Posts>(postDto);
            var result = await _postService.UpdatePost(id, post);
            var postDtoResult = _mapper.Map<PostsDto>(result);
            var response = new ApiResponse<PostsDto>(postDtoResult);
            return Ok(response);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
