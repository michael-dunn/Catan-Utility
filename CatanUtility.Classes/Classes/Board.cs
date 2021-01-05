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
        public List<Harbor> Harbors { get; set; }

        public Board()
        {
            Hexes = new List<BoardHex>();
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            Harbors = new List<Harbor>();
        }

        public Board(string boardHexesFile)
        {
            Hexes = FileUtility.OpenBoardFile(boardHexesFile);
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            Harbors = new List<Harbor>();
            GameUtility.SetupGraph(this);
        }

        public void BuildRandomBoard()
        {
            //TODO: implement rules like 8 and 6 cannot be touching
            Hexes = new List<BoardHex>();
            var resources = new List<CatanResourceType>() { CatanResourceType.Brick, CatanResourceType.Brick, CatanResourceType.Brick,
                                                        CatanResourceType.Ore, CatanResourceType.Ore, CatanResourceType.Ore,
                                                        CatanResourceType.Wheat, CatanResourceType.Wheat, CatanResourceType.Wheat, CatanResourceType.Wheat,
                                                        CatanResourceType.Wood, CatanResourceType.Wood, CatanResourceType.Wood, CatanResourceType.Wood,
                                                        CatanResourceType.Sheep, CatanResourceType.Sheep, CatanResourceType.Sheep, CatanResourceType.Sheep };
            var values = new List<int>() { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };
            //randomize lists
            resources = resources.OrderBy(a => Guid.NewGuid()).ToList();
            values = values.OrderBy(a => Guid.NewGuid()).ToList();
            //create board
            for (int i = 0; i < 18; i++)
            {
                Hexes.Add(new BoardHex(resources[i], values[i], false));
            }
            Hexes.Insert(new Random().Next(0, 19), new BoardHex(CatanResourceType.Desert, 0, true));
        }

        public void AddHarbor(int hexNumber, int edgeIndex, HarborType harborType)
        {
            Harbors.Add(new Harbor(Edges[GameUtility.HexEdges[hexNumber][edgeIndex]], harborType));
        }
    }
}
