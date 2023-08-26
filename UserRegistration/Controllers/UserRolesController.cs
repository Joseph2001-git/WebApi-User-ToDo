using Microsoft.AspNetCore.Mvc;
using Roles.Dto;
using Roles.Interface;
using Roles.Models;

namespace UserRegistration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController:ControllerBase
    {

        private readonly IUserRolesRepository _urint;
        public UserRolesController(IUserRolesRepository urint)
        {
            _urint = urint;
        }

        [HttpGet]
        [Route("All", Name = "GetAllUsersRoles")]
        public async Task<IActionResult> GetUsersRoles()
        {
            return Ok(await _urint.GetUsersRoles());
        }

        [HttpGet]
        [Route("Get/{userid:int}")]
        public async Task<IActionResult> GetUsersRolesByUserID(int userid)
        {
            return Ok(await _urint.GetUserRoleByUserID(userid));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UserRolesModel model)
        {

            var userrole = _urint.CreateUserRole(model);
            return Ok(await userrole);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UserRolesModel model)
        {

            var userrole = _urint.UpdateUserRole(model);
            return Ok(await userrole);

        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _urint.DeleteUserRole(id));

        }
    }
}
