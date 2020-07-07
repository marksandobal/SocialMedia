
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Data;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    //public class PostRepository : IPostRepository //Cambiamos esta implementacion por la BAse
    public class PostRepository : BaseRepository<Posts>, IPostRepository
    {

        //private readonly SocialMediaContext _context;
        public PostRepository(SocialMediaContext context) : base(context)
        {

        }

        #region Las operaciones crud fueron remplazadas por el UnitiOfWork
        /*
        public async Task<IEnumerable<Posts>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Posts> GetPostById(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public async Task InsertPost(Posts post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Posts post)
        {
            _context.Posts.Update(post);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);
            _context.Posts.Remove(post);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        */
        #endregion

        public async Task<IEnumerable<Posts>> GetPostsByUser(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
