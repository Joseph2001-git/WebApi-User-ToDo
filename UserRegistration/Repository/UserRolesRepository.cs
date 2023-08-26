using Microsoft.EntityFrameworkCore;
using Roles.Interface;
using Roles.Models;

namespace UserRegistration.Repository
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly MyDbContext _context;
        public UserRolesRepository(MyDbContext context)
        {

            _context = context;

        }

        public async Task<Object> CreateUserRole(UserRolesModel urmodel)
        {
            var model = new UserRolesModel
            {
                UserId= urmodel.UserId,
                RoleId=urmodel.RoleId,
            };

            _context.AddAsync(model);
            _context.SaveChangesAsync();
            return model;
        }

        public async Task<Object> DeleteUserRole(int id)
        {
            var model=_context.UsersRoles.FirstOrDefault(x => x.Id == id);
            _context.Remove(model);
            _context.SaveChangesAsync();
            return model;
        }

        public async Task<object> GetUserRoleByUserID(int userId)
        {
            var model=_context.UsersRoles.FirstOrDefault(p=>p.UserId == userId);
            return model;
        }

        public async Task<IEnumerable<UserRolesModel>> GetUsersRoles()
        {
            return await _context.UsersRoles.ToListAsync();
        }

        public async Task<Object> UpdateUserRole(UserRolesModel urmodel)
        {
            var model=_context.UsersRoles.FirstOrDefault(p=>p.Id==urmodel.Id);
            model.UserId=urmodel.UserId;
            model.RoleId=urmodel.RoleId;
            _context.SaveChangesAsync();
            return model;
        }
    }
}
