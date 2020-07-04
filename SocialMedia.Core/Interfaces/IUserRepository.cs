using SocialMedia.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserById(int id);   
        Task InsertUser(Users user);
        Task<bool> UpdateUser(Users user);
        Task<bool> DeleteUser(int id);
    }
}