using LPInfotech.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Collections.Generic;

namespace LPInfotech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }
        public DbSet<Setting> Settings { get; set; }

    }
}
