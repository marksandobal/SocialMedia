using SocialMedia.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Posts> GetPosts();
        Task<Posts> GetPostById(int id);
        Task InsertPost(Posts post);
        Task<Posts> UpdatePost(int id, Posts post);
        Task<bool> DeletePost(int id);
    }
}
