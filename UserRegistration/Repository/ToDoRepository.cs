using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDoList.Dto;
using ToDoList.Interface;
using ToDoList.Models;
using UserRegistration;


namespace ToDoList.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly MyDbContext _context;


        public ToDoRepository(MyDbContext context)
        {
            _context = context;

        }
        public async Task<ToDoModel> Create(ToDoDTO todo,int userId)
        {
            ToDoModel model = new ToDoModel
            {
                ToDoMessage = todo.toDoMessage,
                UserId=userId
            };
            await _context.ToDos.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Object> Delete(int id)
        {
            var todo = CheckId(id);
            if (!(todo is ObjectResult))
            {
                _context.ToDos.Remove(todo);
                _context.SaveChanges();
                return todo;
            }
            else
            {
                return todo;
            }

        }
        public async Task<IEnumerable<ToDoModel>> GetAll()
        {

            return await _context.ToDos.ToListAsync();

        }

        public async Task<Object> Update(ToDoDTO todo)
        {
            var model = CheckId(todo.Id);
            if (!(model is ObjectResult))
            {
                model.ToDoMessage = todo.toDoMessage;
                await _context.SaveChangesAsync();
                return model;
            }
            else
            {
                return model;
            }
        }

        public async Task<Object> GetToDoByUserId(int userID)
        {
            if (userID <= 0)
            {
                return new ObjectResult("UserId should be bigger than 0") { StatusCode = 500 };
            }
            var user = _context.Users.Where(p => p.Id == userID).FirstOrDefault();
            if (user != null)
            {
                var model = _context.ToDos.Where(p => p.UserId == userID).ToList();
                if (!model?.Any() ?? true)
                {
                    return new ObjectResult($"User with ID {userID} does not have any ToDO") { StatusCode = 404 };
                }
                return model;
            }
            else
            {
                return new ObjectResult($"User with id {userID} does not exists") { StatusCode = 404 };
            }


        }
        public async Task<Object> GetToDoById(int id)
        {

            var model=CheckId(id);
            return  model;
        }

        //public async Task<Object> UpdateByUserId(int userId, ToDoModel todo)
        //{
        //    if (userId <= 0)
        //    {
        //        return new ObjectResult("UserId should be bigger than 0") { StatusCode=500};
        //    }
        //    var model = CheckId(todo.Id);
        //    if (model.UserId != userId)
        //    {
        //        return new ObjectResult($"User does not have ToDo with id {todo.Id}") { StatusCode=404};
        //    }
        //    if (!(model is ObjectResult))
        //    {
        //        model.ToDoMessage = todo.ToDoMessage;
        //        await _context.SaveChangesAsync();
        //        return model;
        //    }
        //    else
        //    {
        //        return model;
        //    }
        //}

        public dynamic CheckId(int id)
        {
            if (id <= 0)
            {
                return new ObjectResult("The ID should be bigger Than 0") { StatusCode = 500 };
            }
            var todo = _context.ToDos.Where(p => p.Id == id).FirstOrDefault();
            if (todo == null)
            {
                return new ObjectResult("The ToDo with ID {id} can Not Be Found") { StatusCode = 404 };
            }
            else
            {
                return todo;
            }
        }

        
    }
}

