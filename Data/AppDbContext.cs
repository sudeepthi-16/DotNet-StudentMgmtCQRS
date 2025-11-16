using Microsoft.EntityFrameworkCore;
using StudentMgmtCQRS.Models;
using System.Collections.Generic;

namespace StudentMgmtCQRS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students => Set<Student>();
    }
}
