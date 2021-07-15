using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Models
{
    public class Board
    {
        public int Id { get; set; }
        public List<BoardHex> Hexes { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }
        public List<Harbor> Harbors { get; set; }

        public Board() {
            Hexes = CreateList.RepeatedDefault<BoardHex>(19);
            Vertices = CreateList.RepeatedDefault<Vertex>(54);
            Edges = CreateList.RepeatedDefault<Edge>(72);
            Harbors = CreateList.RepeatedDefault<Harbor>(9);
        }
    }

    public static class CreateList
    {
        public static List<T> RepeatedDefault<T>(int count)
        {
            return Repeated(default(T), count);
        }

        public static List<T> Repeated<T>(T value, int count)
        {
            List<T> ret = new List<T>(count);
            ret.AddRange(Enumerable.Repeat(value, count));
            return ret;
        }
    }
}
