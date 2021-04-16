using System.Collections.Generic;

namespace CatanUtility.Models
{
    public class Game
    {
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public Game() { }
    }
}
