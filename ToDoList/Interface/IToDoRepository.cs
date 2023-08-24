using ToDoList.Dto;
using ToDoList.Models;


namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        
        public Task<IEnumerable<ToDoModel>> GetAll();
        public Task<Object> Delete(int id);

        public Task<Object> Update(ToDoDTO todo);

        public Task<ToDoModel> Create(ToDoDTO todo, int userID);


        public Task<Object> GetToDoByUserId(int userID);

        public Task<Object> GetToDoById(int id); 

        //public Task<Object> UpdateByUserId (int userId, ToDoModel todo);
    }
}
