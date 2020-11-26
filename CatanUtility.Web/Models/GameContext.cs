using CatanUtility.Classes;
using Microsoft.EntityFrameworkCore;

namespace CatanUtility.Web.Models
{
    public class GameContext : DbContext
    {
public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Kellertim;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlite("Data Source = Catan.db");
        }
    }
}
