using Microsoft.EntityFrameworkCore;
using DeepBreaths.API.Models;

namespace DeepBreaths.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MoodEntry> MoodEntries { get; set; }
    }
}
