using Microsoft.EntityFrameworkCore;
using Edu_Library.Models;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace Edu_Library.Data
{
    public class ApplicationDB_Context : DbContext
    {
        public ApplicationDB_Context(DbContextOptions<ApplicationDB_Context> options) : base(options) { 
        
        }

        public DbSet<Book_tb> Book_tb { get; set; }
        public DbSet<Category_tb> Category_tb { get; set; }
        public DbSet<User_tb> User_tb { get; set; }
    }
}
