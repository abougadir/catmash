using CatMashAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CatMashAPI.Data
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
