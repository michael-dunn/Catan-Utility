using CatanUtility.Classes;
using Microsoft.EntityFrameworkCore;

namespace CatanUtility.Web.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public GameContext()
        {

        }

        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Catan.db");
        }
    }
}
