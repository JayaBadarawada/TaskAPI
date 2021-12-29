using System;
using TaskAPI.Entities;
using TaskAPI.DataAccess;
namespace TaskAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context) { _context = context; }

        public Todo CreateTodo(int userId,Todo todo)


        {
            User user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            Todo todoTask = new() { Id = todo.Id, Title = todo.Title };

            user.Todos.Add(todoTask);
            // _context.Tasks.Add(task);
            _context.SaveChanges();

            return todoTask;
        }
        public bool DeleteTodo(int id)
        {
            Todo todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateTodo(int id, Todo t)
        {
            Todo todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.Title = t.Title;
                todo.IsCompleted = t.IsCompleted;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

