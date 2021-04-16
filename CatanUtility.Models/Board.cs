using System.Collections.Generic;

namespace CatanUtility.Models
{
    public class Board
    {
        public int Id { get; set; }
        public List<BoardHex> Hexes { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }
        public List<Harbor> Harbors { get; set; }

        public Board() { }
    }
}
