using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            //var postDto = posts.Select(x => new PostsDto
            //{ 
            //    Id = x.Id,
            //    Date = x.Date,
            //    Description = x.Description,
            //    Image = x.Image,
            //    UserId = x.UserId

            //});
            return Ok(postDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPostById(id);
            var postDto = _mapper.Map<PostsDto>(post);
            //var postDto = new PostsDto()
            //{ 
            //    Id = post.Id,
            //    Date = post.Date,
            //    Description = post.Description,
            //    Image = post.Image,
            //    UserId = post.UserId
            //};
            return Ok(post);
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
            return Ok(post);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
