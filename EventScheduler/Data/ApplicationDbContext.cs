using EventScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventScheduler.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
    }
}
