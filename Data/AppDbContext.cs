using Microsoft.EntityFrameworkCore;
using Practica3_JeanEstrada.Models;

namespace Practica3_JeanEstrada.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
