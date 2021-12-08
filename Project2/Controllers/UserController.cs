using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.MongoDb.Repositories;

namespace Project2.Controllers {
    [Route("users")]
    public class UserController : Controller {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IList<User>> ListAll() {
            return await _userRepository.ListAllAsync();
        }

        [HttpGet("{username}")]
        public async Task<User?> GetByUsername(string username) {
            var allUsers = await _userRepository.ListAllAsync();
            var user = allUsers.FirstOrDefault(x => x.Username == username);
            return user;
        }

        [HttpPost]
        public async Task<User> Create([FromBody] CreateUserModel model) {
            var user = new User();
            user.FirstName = model.FirstName;
            user.SecondName = model.SecondName;
            user.MiddleName = model.MiddleName;
            user.Username = model.Username;
            user.Password = model.Password;
            user.UserType = model.UserType;

            return await _userRepository.CreateAsync(user);
        }

        [HttpGet("{userId:guid}")]
        public async Task<User?> Get(Guid userId) {
            var user = await _userRepository.GetByIdAsync(userId);
            return user;
        }

        [HttpPut("{userId:guid}")]
        public async Task<User?> Update(Guid userId, [FromBody] User model) {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) {
                return null;
            }

            user.Update(model);
            return await _userRepository.UpdateAsync(user);
        }

        [HttpDelete("{userId:guid}")]
        public async Task Delete(Guid userId) {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null) {
                await _userRepository.DeleteAsync(user);
            }
        }
    }
}
