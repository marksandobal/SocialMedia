using SocialMedia.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Posts> PostRepository { get; }
        IRepository<Users> UserRepository { get; }

        IRepository<Comments> CommentRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
