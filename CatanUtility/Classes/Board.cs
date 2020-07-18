using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Classes
{
    public class Board
    {
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
                Edges.Add(new Edge(i));
            }
        }

        public Board(string file) : this()
        {
            GameUtility.SetupGraph(this, file);
        }

        public void PrintBoard()
        {
            PrintRow(Hexes.Take(3), 6);
            PrintRow(Hexes.Skip(3).Take(4), 3);
            PrintRow(Hexes.Skip(7).Take(5), 0);
            PrintRow(Hexes.Skip(12).Take(4), 3);
            PrintRow(Hexes.Skip(15).Take(3), 6);
        }

        public void PrintHex(int hexNumber)
        {
            Console.WriteLine("{0,25}", Vertices[GameUtility.GetBoardIndex(hexNumber, 1)]);
            Console.WriteLine("{0,15}{1,17}", Edges[GameUtility.GetBoardIndex(hexNumber, 6)], Edges[GameUtility.GetBoardIndex(hexNumber, 1)]);
            Console.WriteLine("{0,0}{1,30}", Vertices[GameUtility.GetBoardIndex(hexNumber, 6)], Vertices[GameUtility.GetBoardIndex(hexNumber, 2)]);
            Console.WriteLine("{0,0}{1,15}{2,15}", Edges[GameUtility.GetBoardIndex(hexNumber, 5)], Hexes[hexNumber - 1], Edges[GameUtility.GetBoardIndex(hexNumber, 2)]);
            Console.WriteLine("{0,0}{1,30}", Vertices[GameUtility.GetBoardIndex(hexNumber, 5)], Vertices[GameUtility.GetBoardIndex(hexNumber, 3)]);
            Console.WriteLine("{0,15}{1,17}", Edges[GameUtility.GetBoardIndex(hexNumber, 4)], Edges[GameUtility.GetBoardIndex(hexNumber, 3)]);
            Console.WriteLine("{0,25}", Vertices[GameUtility.GetBoardIndex(hexNumber, 4)]);
        }

        private void PrintRow(IEnumerable<BoardHex> hexLine, int startSpaces)
        {
            Console.Write(new string(' ', startSpaces));
            foreach (var hex in hexLine)
                Console.Write(hex + " ");
            Console.WriteLine('\n');
        }

        public void BuildRandomBoard()
        {
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
        public void BuildBoard()
        {
            Console.Write("Open saved board? (Y/N) ");
            var response = Console.Read();
            Console.WriteLine();
            if (response == 'Y')
            {
                Hexes = FileUtility.OpenBoardFile();
            }
            else
            {
                BuildRandomBoard();
            }
        }
    }
}
