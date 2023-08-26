using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roles.Dto;
using Roles.Interface;
using Roles.Models;

namespace UserRegistration.Repository
{
    public class RolesRepository : IRoleRepository
    {
        private readonly MyDbContext _context;
        public RolesRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Object> CreateRole(RolesDto roleDto)
        {
            var role = new RolesModel
            {
                Role=roleDto.Role,
            };
            _context.AddAsync(role);
            _context.SaveChangesAsync();
            return role;
        }

        public async Task<IEnumerable<RolesModel>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Object> UpdateRoles(RolesDto roleDto)
        {
            var model=_context.Roles.FirstOrDefault(p=>p.Id==roleDto.Id);
            model.Role= roleDto.Role;

            _context.SaveChangesAsync();
            return model;
        }

        public async Task<Object> DeleteRole(int id)
        {
            var model= _context.Roles.FirstOrDefault(p=> p.Id==id);
            _context.Remove(model);
            _context.SaveChangesAsync();
            return model;
        }
    }
}
