using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;
using UserRegistration.Models.Dtos;
using UserRepository.Models.Interface;

namespace UserRegistration.Repository;

public class UsersRepository : IUserRepository
{
    private readonly MyDbContext _context;
    public UsersRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Object> CreateUser(UserDTO userDTO)
    {
        if(userDTO == null)
        {
            return new ObjectResult("The model provided is null") { StatusCode = 500 }; ;
        }

        var user = new User
        {
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            Email = userDTO.Email,
            Password = userDTO.Password,
            CheckPassword = userDTO.CheckPassword,
            Country = userDTO.Country,
            State = userDTO.State,
            City = userDTO.City,
        };

        if(user.Password != user.CheckPassword)
        {
            return new ObjectResult("Passwords Do Not Match") { StatusCode = 500 }; ;
        }

        var userchecked = CheckEmail(user);
        if(!(userchecked is ObjectResult))
        {
            _context.Users.AddAsync(userchecked);
            _context.SaveChangesAsync();
            return userchecked;
        } else
        {
            return userchecked;
        }

       
    }

    public async Task<Object> DeleteUser(int id)
    {
        var user = CheckId(id);
        if (!(user is ObjectResult))
        {
            _context.Remove(user);
            _context.SaveChangesAsync();

            return  user;
        } else
        {
            return user;
        }
        
    }

    public async Task<Object> GetUserById(int id)
    {
        var model = CheckId(id);
        if (!(model is ObjectResult))
        {
            return model;
        }
        return model;
        
    }

    public async Task<Object> GetUsersByName(string firstname, string lastname)
    {
        return  CheckName(firstname, lastname);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Object> UpdateUser(UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return new ObjectResult("The model provided is null") { StatusCode=500};
        }


        var model = CheckId(userDTO.Id);
        if (userDTO.Password != userDTO.CheckPassword)
        {
            return new ObjectResult("Passwords Do Not Match") { StatusCode = 500 };
        }
        if (!(model is ObjectResult)) 
        {
            model.FirstName = userDTO.FirstName;
            model.LastName = userDTO.LastName;
            model.Password = userDTO.Password;
            model.CheckPassword = userDTO.CheckPassword;
            model.Country = userDTO.Country;
            model.State = userDTO.State;
            model.City = userDTO.City;
        }

            _context.SaveChanges();
            return model;
        
        
    }

    public dynamic CheckId(int id)
    {
        if (id <= 0)
        {
            return new ObjectResult("The ID should be bigger Than 0") { StatusCode = 500 };
        }
        var todo = _context.Users.Where(p => p.Id == id).FirstOrDefault();
        if (todo == null)
        {
            return new ObjectResult($"The user with ID {id} can Not Be Found") { StatusCode = 404 };
        }
        else
        {
            return todo;
        }
    }

    public dynamic CheckEmail(User userDTO)
    {
        var model=_context.Users.Where(p=>p.Email== userDTO.Email).FirstOrDefault();
        if(model == null)
        {
            return userDTO;
        } else
        {
            return new ObjectResult("The Email is not available") { StatusCode = 404 };
        }

    }

    public dynamic CheckName(string fn, string ln) 
    { 
        if(fn == null)
        {
            return new ObjectResult ("FirstName is Null")  { StatusCode = 500 };
        }
        if (ln == null)
        {
            return new ObjectResult("LastName is Null") { StatusCode = 500 };
        }
        var model=_context.Users.Where(p=>p.FirstName== fn && p.LastName== ln);
        if(!model?.Any() ?? true)
        {
            return new ObjectResult($"No User with Firstname {fn} and Lastname {ln} was found") { StatusCode = 404 };
        }


        return model;
    }

}
