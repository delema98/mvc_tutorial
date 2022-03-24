using Microsoft.EntityFrameworkCore;
using mvc_tutorial.Models;

namespace mvc_tutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get;set;}
    }
}