using Microsoft.AspNetCore.Mvc;
using Roles.Dto;
using Roles.Interface;


namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRepository _roleint;

        public RoleController(IRoleRepository roleint)
        {
            _roleint = roleint;
        }

        [HttpGet]
        [Route("All", Name = "GetAllRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _roleint.GetRoles());
        }

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Create([FromBody] RolesDto model)
        {

            var role = _roleint.CreateRole(model);
            return Ok(await role);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RolesDto model)
        {

            var role = _roleint.UpdateRoles(model);
            return Ok(await role);

        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _roleint.DeleteRole(id));

        }


    }
}
