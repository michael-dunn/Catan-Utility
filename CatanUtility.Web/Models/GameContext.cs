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
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardHex> Hexes { get; set; }
        public DbSet<Edge> Edges { get; set; }
        public DbSet<Vertex> Vertices { get; set; }
        public DbSet<Harbor> Harbors { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
