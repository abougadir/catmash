using Catmash.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catmash.Data
{
    public class ApiDbContext : IdentityDbContext<User, UserRole, int>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}
