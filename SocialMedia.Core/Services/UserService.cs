using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users;
            //var user_
        }
    }
}
