using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Data;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        PagedList<Posts> GetPosts(PostQueryFilter filters);
        Task<Posts> GetPostById(int id);
        Task InsertPost(Posts post);
        Task<Posts> UpdatePost(int id, Posts post);
        Task<bool> DeletePost(int id);
    }
}
