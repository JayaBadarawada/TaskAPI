using System;
using TaskAPI.Entities;

namespace TaskAPI.Repositories
{
	public interface ITodoRepository
	{
		Todo CreateTodo(int userId, Todo todo);
		bool DeleteTodo(int id);
		bool UpdateTodo(int id, Todo t);
	}
}

