using System;
using Microsoft.EntityFrameworkCore;
using TaskAPI.DataAccess;
using TaskAPI.Entities;

namespace TaskAPI.Repositories
{
	public class UserRepository:IUserRepository
	{
		private readonly DataContext _context;
		public UserRepository(DataContext context) { _context = context; }
		public IEnumerable<User> GetUsers() => _context.Users.ToList();
        public User CreateUser(User u)
        {
            User user = new() { Id = u.Id, Username = u.Username, Password = u.Password };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public User GetUserByNameAndPassword(User user)
        {

            User foundUser = _context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            return foundUser;
        }
        public User GetUserById(int id)
        {

            var user = _context.Users
                           .Where(u => u.Id == id)
                           .Include(u => u.Todos)
                           .FirstOrDefault();
            return user;

        }
        public List<Todo> GetUserTodos(int userId)
        {
            var user = _context.Users
                          .Where(u => u.Id == userId)
                          .Include(u => u.Todos)
                          .FirstOrDefault();
            return user.Todos;
        }
        public Todo GetUserTodoDetails(int userId, int todoId)
        {
            var user = _context.Users
                          .Where(u => u.Id == userId)
                          .Include(u => u.Todos)
                     
 
                          .FirstOrDefault();
            var todo = user.Todos.Where(t => t.Id == todoId).FirstOrDefault();
            return todo;
        }
    }
}

