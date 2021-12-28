using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Entities;
using TaskAPI.Repositories;




namespace TaskAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        public readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        [HttpPost("{userId}")]
        public ActionResult CreateTodo(int userId,Todo todo)
        {
            _todoRepository.CreateTodo(userId,todo);
            return Ok();
        }

    }
}

