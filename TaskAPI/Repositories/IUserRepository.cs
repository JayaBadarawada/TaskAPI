using System;
using TaskAPI.Entities;

namespace TaskAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User u);
        User GetUserByNameAndPassword(User user);
        //User GetUserByUserName(string userName);
        User GetUserById(int id);
        List<Todo> GetUserTodos(int userId);
        Todo GetUserTodoDetails(int userId, int todoId);


    }
}

