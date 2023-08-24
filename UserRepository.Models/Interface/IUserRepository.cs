using UserRegistration.Models;
using UserRegistration.Models.Dtos;

namespace UserRepository.Models.Interface
{
    public interface IUserRepository
    {

        public Task<IEnumerable<User>> GetUsers();

        public Task<Object> GetUserById(int id);

        public Task<Object> GetUsersByName(string firstname, string lastname);

        public Task<Object> CreateUser(UserDTO userDTO);

        public Task<Object> UpdateUser(UserDTO userDTO);

        public Task<Object> DeleteUser(int id);

        
    }
}
