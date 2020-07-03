
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Data;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;
        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

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
            _context.SaveChangesAsync();
        }
    }
}
