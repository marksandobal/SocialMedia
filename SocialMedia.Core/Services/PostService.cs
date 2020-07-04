using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Posts>> GetPosts()
        {
            var posts = await _postRepository.GetPosts();

            return posts;
        }

        public async Task<Posts> GetPostById(int id)
        {
            var post = await _postRepository.GetPostById(id);
            return post;
        }

        public async Task InsertPost(Posts post)
        {
            var user = await _userRepository.GetUserById(post.UserId);
            if (user.Equals(null))
            {
                throw new Exception("User doen't exist");
            }
            await _postRepository.InsertPost(post);
        }

        public async Task<bool> UpdatePost(int id, Posts post)
        {
            post.Id = id;
            var result = await _postRepository.UpdatePost(post);

            return result;
        }

        public async Task<bool> DeletePost(int id)
        {
            var result = await _postRepository.DeletePost(id);
            return result;
        }
    }
}
