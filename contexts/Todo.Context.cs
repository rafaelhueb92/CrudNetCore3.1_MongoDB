using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}