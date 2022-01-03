using System;
namespace TaskAPI.Entities
{
	public class UserToken
	{
        public int UserId { get; set; }
        public string Token { get; set; }

		public UserToken()
		{
		}
	}
}

