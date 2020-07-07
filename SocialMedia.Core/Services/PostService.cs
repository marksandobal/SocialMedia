using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Data;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        // Removemos estos repositorios y agregamos el Generico
        //private readonly IPostRepository _postRepository;
        //private readonly IUserRepository _userRepository;
        /* 
         * Remplazamos los repositorio9s genericos por los UnitiOfWork donde se 
         * engloban todos los repositorios, es decir, nuestro repositorio de repositorios
        */

        //private readonly IRepository<Posts> _postRepository;
        //private readonly IRepository<Users> _userRepository;

        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedList<Posts> GetPosts(PostQueryFilter filters)
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            if(filters.UserId != null)
            {
                posts = posts.Where(x => x.UserId == filters.UserId);
            }

            if(filters.Date != null) 
            {
                posts = posts.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null)
            {
                posts = posts.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            var pagedPosts = PagedList<Posts>.Create(posts, filters.PageNumber, filters.PageSize);
            return pagedPosts;
        }

        public async Task<Posts> GetPostById(int id)
        {
            //var post = await _postRepository.GetPostById(id);
            var post = await _unitOfWork.PostRepository.GetById(id);
            return post;
        }

        public async Task InsertPost(Posts post)
        {
            //var user = await _userRepository.GetUserById(post.UserId);
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
            {
                throw new BusinessException("User doen't exist");
            }

            var userPosts = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if (userPosts.Count() < 10)
            {
                var lastPost = userPosts.LastOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7) 
                {
                    throw new BusinessException("You are not able to publish the post");
                }
            }
            // await _postRepository.InsertPost(post); // removemos la linea por el repositorio generico
            // await _postRepository.Add(post); // removemos la lina por el repo de repos
            
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Posts> UpdatePost(int id, Posts post)
        {
            post.Id = id;
            //var result = await _postRepository.UpdatePost(post);
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();

            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            //var result = await _postRepository.DeletePost(id);
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}
