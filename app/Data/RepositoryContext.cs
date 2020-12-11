using app.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Owner> Type { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}