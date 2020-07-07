using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IPostRepository _postRepository;
        //private readonly IRepository<Posts> _postRepository;
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<Comments> _commentRepository;


        public UnitOfWork(SocialMediaContext context) 
        {
            _context = context;
        }

        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public IRepository<Users> UserRepository => _userRepository ?? new BaseRepository<Users>(_context);

        public IRepository<Comments> CommentRepository => _commentRepository ?? new BaseRepository<Comments>(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
