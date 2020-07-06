﻿using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        // Removemos estos repositorios y agregamos el Generico
        //private readonly IPostRepository _postRepository;
        //private readonly IUserRepository _userRepository;

        // Remplazamos los repositorio9s genericos por los UnitiOfWork donde se
        // engloban todos los repositorios, es decir, nuestro repositorio de repositorios
        //private readonly IRepository<Posts> _postRepository;
        //private readonly IRepository<Users> _userRepository;

        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Posts>> GetPosts()
        {
            //var posts = await _postRepository.GetPosts();
            var posts = await _unitOfWork.PostRepository.GetAll();
            return posts;
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
            if (user.Equals(null))
            {
                throw new Exception("User doen't exist");
            }
            // await _postRepository.InsertPost(post); // removemos la linea por el repositorio generico
            // await _postRepository.Add(post); // removemos la lina por el repo de repos
            
            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<Posts> UpdatePost(int id, Posts post)
        {
            post.Id = id;
            //var result = await _postRepository.UpdatePost(post);
            await _unitOfWork.PostRepository.Update(post);
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
