using GitHubActionsProject.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GitHubActionsProject.API.Data.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
