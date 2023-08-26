using Roles.Models;


namespace Roles.Interface
{
    public interface IUserRolesRepository
    {
        public Task<IEnumerable<UserRolesModel>> GetUsersRoles();

        public Task<Object> CreateUserRole(UserRolesModel urmodel);

        public Task<Object> UpdateUserRole(UserRolesModel urmodel);

        public Task<Object> DeleteUserRole(int id);

        public Task<Object> GetUserRoleByUserID(int userId);
    }
}
