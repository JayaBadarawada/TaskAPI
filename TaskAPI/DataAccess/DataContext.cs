using System;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Entities;

namespace TaskAPI.DataAccess
{
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
        public DbSet<User> Users { get; set; }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new { Id = 1, Username = "Atlal",Password="1234" });

            modelBuilder.Entity<Todo>().HasData(new { Id = 1, Title = "sleep!!",IsCompleted=false });



        }
    }


}

