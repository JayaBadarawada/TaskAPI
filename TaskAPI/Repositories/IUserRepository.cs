using System;
using TaskAPI.Entities;

namespace TaskAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User CreateUser(User u);
        User GetUserByNameAndPassword(User user);
        User GetUserById(int id);
        List<Todo> GetUserTodos(int userId);
        Todo GetUserTodoDetails(int userId, int todoId);


    }
}

