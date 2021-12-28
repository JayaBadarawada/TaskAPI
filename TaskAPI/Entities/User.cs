using System;
namespace TaskAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();


    }
}

