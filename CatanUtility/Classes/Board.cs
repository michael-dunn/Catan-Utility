using System;
using System.Collections.Generic;
using System.Linq;
using CatanUtility.Classes.Enums;

namespace CatanUtility.Classes
{
    public class Board
    {
        public int Id { get; set; }
        public List<BoardHex> Hexes { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Board()
        {
            Hexes = new List<BoardHex>();
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            for (int i = 0; i < 72; i++)
            {
                if (i < 54) { Vertices.Add(new Vertex(i)); }
                if (i < 19) { Hexes.Add(new BoardHex()); }
                Edges.Add(new Edge(i));
            }
        }

        public Board(string file) : this()
        {
            GameUtility.SetupGraph(this);
        }

        public void BuildRandomBoard()
        {
            //TODO: implement rules like 8 and 6 cannot be touching
            if (Hexes.All(h => h.Robber))
            {
                var resources = new List<CatanResourceType>() { CatanResourceType.Brick, CatanResourceType.Brick, CatanResourceType.Brick,
                                                            CatanResourceType.Ore, CatanResourceType.Ore, CatanResourceType.Ore,
                                                            CatanResourceType.Wheat, CatanResourceType.Wheat, CatanResourceType.Wheat, CatanResourceType.Wheat,
                                                            CatanResourceType.Wood, CatanResourceType.Wood, CatanResourceType.Wood, CatanResourceType.Wood,
                                                            CatanResourceType.Sheep, CatanResourceType.Sheep, CatanResourceType.Sheep, CatanResourceType.Sheep };
                var values = new List<int>() { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };
                resources = resources.OrderBy(a => Guid.NewGuid()).ToList();
                values = values.OrderBy(a => Guid.NewGuid()).ToList();
                for (int i = 0; i < 18; i++)
                {
                    Hexes.Add(new BoardHex(resources[i], values[i], false));
                }
                Hexes.Insert(new Random().Next(1, 19), new BoardHex(CatanResourceType.Desert, 0, true));
            }
        }
        
    }
}
