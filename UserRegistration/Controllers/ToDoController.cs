using Microsoft.AspNetCore.Mvc;
using ToDoList.Dto;
using ToDoList.Interface;
using ToDoList.Models;


namespace UserRegistration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController :ControllerBase
    {
        private readonly IToDoRepository iToDo;

        public ToDoController(IToDoRepository iToDo)
        {
            this.iToDo = iToDo;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            return Ok(await this.iToDo.GetAll());
        }

        [HttpGet]
        [Route("Get/{userid:int}")]
        public async Task<IActionResult> GetToDoListByUserId(int userid)
        {
            return Ok(await this.iToDo.GetToDoByUserId(userid));
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetToDoById(int id)
        {
            return Ok(await this.iToDo.GetToDoById(id));
        }

        [HttpPost]
        [Route("Create/{userid:int}")]
        public async Task<IActionResult> CreateToDo(ToDoDTO toDo, int userid)
        {
            var todolist = iToDo.Create(toDo,userid);
            return Ok(await todolist);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateToDO(ToDoDTO toDo)
        {
            return Ok(await this.iToDo.Update(toDo));
        }

        //[HttpPut]
        //[Route("UpdateByUserId")]
        //public async Task<IActionResult> UpdateToDoByUserId(ToDoModel toDo,int userid)
        //{
        //    return Ok(await this.iToDo.UpdateByUserId(userid, toDo));
        //}

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<Object> DeleteToDo(int id)
        {
             return await this.iToDo.Delete(id);
            
        }

        
    }
}
