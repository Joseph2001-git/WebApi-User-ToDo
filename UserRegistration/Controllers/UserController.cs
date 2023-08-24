using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models.Dtos;
using UserRepository.Models.Interface;

namespace UserRegistration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRep;
        
        public UserController(IUserRepository userRep)
        {
            _userRep = userRep;
            
        }

        [HttpGet]
        [Route("All", Name = "GetAllUser")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUsers()
        {
           return Ok(await _userRep.GetUsers());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUserById")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> GetById(int id)
        {
            var user = _userRep.GetUserById(id);
            return Ok(await user);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserByName([FromQuery] string firstname, [FromQuery] string lastname)
        {

            var user = _userRep.GetUsersByName(firstname, lastname);
            return Ok(user);

        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(201, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(500)]
        
        public async Task<IActionResult> Create([FromBody] UserDTO model)
        {

            var user =_userRep.CreateUser(model);
            return Ok(await user);

        }

        [HttpPut]
        [Route("Update/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UserDTO model)
        {

            var user = _userRep.UpdateUser(model);
            return Ok(await user);

        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _userRep.GetUserById(id);
            await _userRep.DeleteUser(id);
            return Ok(user);
        }























      
















        //private readonly MyDbContext dbcontext;

        //public UserController(MyDbContext dbContext)
        //{
        //    this.dbcontext = dbContext;
        //}

        //[HttpGet]
        //[Route("GetList")]
        //public async Task<IActionResult> GetList()
        //{
        //    return null;
        //    //Ok(dbcontext.GetUsers());
        //}

        //[HttpPost]
        //[Route("PostUser")]
        //public async Task<IActionResult> PostUser(UserDTO obj)
        //{
        //    User user = new User();
        //    user.Id = obj.Id;
        //    user.FirstName = obj.FirstName;
        //    user.LastName = obj.LastName;
        //    user.Email = obj.Email;
        //    user.Password = obj.Password;
        //    user.CheckPassword = obj.CheckPassword;
        //    user.Country = obj.Country;
        //    user.State = obj.State;
        //    user.City = obj.City;

        //    dbcontext.Users.Add(user);
        //    dbcontext.SaveChanges();

        //    return Ok(user);
        //}

        //[HttpGet]
        //[Route("All", Name = "GetAllUser")]
        //[ProducesResponseType(200, Type = typeof(UserDTO))]
        //[ProducesResponseType(500)]
        //public ActionResult<IEnumerable<UserDTO>> GetUsers()
        //{
        //    var users = UserRepository.Users.Select(s => new UserDTO()
        //    {
        //        Id = s.Id,
        //        FirstName = s.FirstName,
        //        LastName = s.LastName,
        //        Email = s.Email,
        //        Password = s.Password,
        //        CheckPassword = s.CheckPassword,
        //        Country = s.Country,
        //        State = s.State,
        //        City = s.City
        //    });
        //    return Ok(users);
        //}

        //[HttpGet]
        //[Route("{id:int}", Name = "GetUserById")]
        //[ProducesResponseType(200, Type = typeof(UserDTO))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]

        //public ActionResult<UserDTO> GetUserById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }

        //    var user = UserRepository.Users.Where(n => n.Id == id).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return NotFound($"The user with id {id} not found");
        //    }

        //    return Ok(user);
        //}

        //[HttpGet("{firstname},{lastname}")]
        //[ProducesResponseType(200, Type = typeof(UserDTO))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public ActionResult<UserDTO> GetUserByName(string firstname, string lastname)
        //{
        //    if (string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname))
        //    {
        //        return BadRequest();
        //    }

        //    var user = UserRepository.Users.Where(n => n.FirstName == firstname && n.LastName == lastname).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return NotFound($"The user with name {firstname} {lastname} not found");
        //    }

        //    return Ok(user);

        //}

        //[HttpPost]
        //[Route("Create")]
        //[ProducesResponseType(201, Type = typeof(UserDTO))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(500)]
        ////api/student/create
        //public ActionResult<UserDTO> CreateStudent([FromBody] UserDTO model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }

        //    int newId = UserRepository.Users.LastOrDefault().Id + 1;

        //    User user = new User
        //    {
        //        Id = newId,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        Email = model.Email,
        //        Password = model.Password,
        //        CheckPassword = model.CheckPassword,
        //        Country = model.Country,
        //        State = model.State,
        //        City = model.City

        //    };
        //    UserRepository.Users.Add(user);

        //    model.Id = user.Id;

        //    //status-201 and create new student in new url and new student details
        //    return CreatedAtRoute("GetUserById", new { id = model.Id }, model);

        //}



        //[HttpDelete("{id}")]
        //[ProducesResponseType(200, Type = typeof(UserDTO))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public ActionResult<bool> DeleteUser(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }


        //    var user = UserRepository.Users.Where(n => n.Id == id).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return NotFound($"The user with id {id} not found");
        //    }


        //    UserRepository.Users.Remove(user);

        //    return Ok(true);
        //}

    }


}
