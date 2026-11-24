using Microsoft.EntityFrameworkCore;
using Instrutorcasestudy.Models;

namespace Instrutorcasestudy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}