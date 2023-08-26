using Roles.Dto;
using Roles.Models;

namespace Roles.Interface
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<RolesModel>> GetRoles();

        public Task<Object> CreateRole(RolesDto roleDto );

        public Task<Object> UpdateRoles(RolesDto roleDto);

        public Task<Object> DeleteRole(int id);


    }
}
