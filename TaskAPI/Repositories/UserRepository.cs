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
        public void CreateUser(User u)
        {
            User foundUser = _context.Users.Where(user => user.Username == u.Username).FirstOrDefault();
            if (foundUser == null) {
                User user = new() { Id = u.Id, Username = u.Username, Password = u.Password };
                _context.Users.Add(user);
                _context.SaveChanges();
               
            }
         

           
        }
        public User GetUserByNameAndPassword(User user)
        {

            User foundUser = _context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            return foundUser;
        }

        //public User GetUserByUserName(string userName) {
        //    User foundUser = _context.Users.Where(u => u.Username == userName ).FirstOrDefault();
        //    return foundUser;
        //}


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

