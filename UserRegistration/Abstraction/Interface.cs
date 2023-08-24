
using UserRegistration.Models;
using UserRegistration.Models.Dtos;

namespace UserRegistration.Abstraction
{
    public interface IRegistrationManager
    {

        /*
         * 
         * Check if Email already exist return error message if true
         * 
         * Validate Password return error message if not valid
         * 
         * Validate Required Inputs.
         * 
         * Add User In Database
         * 
         */
        Task<User> Register(UserDTO user);

        /* object (e.g. SignInDto) { username, password } */
        Task<bool> SignInUser();

        /*
         Todo List:
        Todo Model (userid, todo message)
        Todo Dto
        
        IEnumerable GetAll
        void Delete (id) 
        TodoModel Update TodoDto
        TodoModel Create TodoDti

         */
    }
}
