using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Repositories;

namespace TaskAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
     
        [HttpGet]
        public IActionResult GetUsers()
        {

            return Ok(_userRepository.GetUsers());
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {

            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }

      




        [HttpGet("{userId}/todos"), Authorize]
        public IActionResult GetUserTodos(int userId)
        {
            var todos = _userRepository.GetUserTodos(userId);
            if (todos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(todos);
            }
        }
        [HttpGet("{userId}/todos/{todoId}"), Authorize]
        public IActionResult GetUserTodoDetails(int userId,int todoId)
        {
            var todo = _userRepository.GetUserTodoDetails(userId,todoId);
            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(todo);
            }
        }

    }
}

