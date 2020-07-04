using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.Data;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            //Con el mapper no necesitas mapperar manualmente el objeto de salida o entrada
            var postDto = _mapper.Map<IEnumerable<PostsDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostsDto>>(postDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPostById(id);
            var postDto = _mapper.Map<PostsDto>(post);
            var response = new ApiResponse<PostsDto>(postDto);
            return Ok(response);
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostsDto postDto)
        {
            //var post = new Posts() { 
            //    Id = postDto.Id,
            //    Date = postDto.Date,
            //    Description = postDto.Description,
            //    Image = postDto.Image,
            //    UserId = postDto.UserId
            //};
            var post = _mapper.Map<Posts>(postDto);
            await _postRepository.InsertPost(post);
            postDto = _mapper.Map<PostsDto>(post);
            var response = new ApiResponse<PostsDto>(postDto);
            return Ok(response);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostsDto postDto)
        {
            var post = _mapper.Map<Posts>(postDto);
            post.Id = id;
            var result = await _postRepository.UpdatePost(post);
            var response = new ApiResponse<PostsDto>(postDto);
            return Ok(response);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postRepository.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
