
using SocialMedia.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Posts>> GetPosts();
        Task<Posts> GetPostById(int id);
        Task InsertPost(Posts post);
        Task<bool> UpdatePost(Posts post);
        Task<bool> DeletePost(int id);
    }
}
