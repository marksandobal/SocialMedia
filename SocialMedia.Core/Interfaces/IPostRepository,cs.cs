
using SocialMedia.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository : IRepository<Posts>
    {
        //El CRUD fue remplazado por el UnitiOfWork
        //Task<IEnumerable<Posts>> GetPosts();
        //Task<Posts> GetPostById(int id);
        //Task InsertPost(Posts post);
        //Task<bool> UpdatePost(Posts post);
        //Task<bool> DeletePost(int id);

        Task<IEnumerable<Posts>> GetPostsByUser(int userId);
    }
}
