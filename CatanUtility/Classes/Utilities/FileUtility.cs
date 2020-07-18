using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CatanUtility.Classes
{
    public static class FileUtility
    {
        public static void SaveGame(Game game, string file = "../../../Data/Game.data")
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("--Hexes--");
            foreach(var hex in game.Board.Hexes)
            {
                sw.WriteLine("{0},{1},{2}", hex.Number, (char)hex.Resource, hex.Robber);
            }
            sw.WriteLine("--Edges--");
            foreach (var edge in game.Board.Edges)
            {
                sw.WriteLine("{0},{1}", edge.Color, edge.Occupied);
            }
            sw.WriteLine("--Vertices--");
            foreach (var vertex in game.Board.Vertices)
            {
                sw.WriteLine("{0},{1},{2}", vertex.Color, (char)vertex.BuildingType, vertex.Occupied);
            }
            sw.WriteLine("--Players--");
            foreach (var player in game.Players)
            {
                sw.Write("{0},{1},{2},", player.Color, player.Name, player.VictoryPoints);
                foreach (var card in player.Hand)
                {
                    sw.Write("{0},", (char)card.Type);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        public static Game OpenSaveGame(string file = "../../../repos/CatanUtility/CatanUtility/Data/Game.data")
        {
            StreamReader sr = new StreamReader(file);
            var game = new Game();
            sr.ReadLine();
            for (int i = 0; i< 19; i++)
            {
                var hexValues = sr.ReadLine().Split(',');
                game.Board.Hexes.Add(new BoardHex() { Number = int.Parse(hexValues[0]), Resource = (CatanResourceType)hexValues[1].First(), Robber = bool.Parse(hexValues[2]) });
            }
            sr.ReadLine();
            for (int i = 0; i < 54; i++)
            {
                var edgeValues = sr.ReadLine().Split(',');
                game.Board.Edges[i].Color = edgeValues[0];
                game.Board.Edges[i].Occupied = bool.Parse(edgeValues[1]);
            }
            sr.ReadLine();
            for (int i = 0; i < 54; i++)
            {
                var vertexValues = sr.ReadLine().Split(',');
                game.Board.Vertices[i].Color = vertexValues[0];
                game.Board.Vertices[i].BuildingType = (BuildType)vertexValues[1].First();
                game.Board.Vertices[i].Occupied = bool.Parse(vertexValues[2]);
            }
            sr.ReadLine();
            var line = sr.ReadLine();
            while (line != null)
            {
                string[] playerValues = line.Split(',');
                var player = new Player() { Color = playerValues[0], Name = playerValues[1], VictoryPoints = int.Parse(playerValues[2]) };
                foreach (var cardType in playerValues.Skip(3))
                {
                    var type = (CatanResourceType)cardType.FirstOrDefault();
                    if (type != 0)
                        player.Hand.Add(new Card() { Type =  type});
                }
                game.Players.Add(player);
                line = sr.ReadLine();
            }
            sr.Close();
            return game;
        }
        public static List<BoardHex> OpenBoardFile(string file = "../../../Data/BoardSetup.txt")
        {
            StreamReader sr = new StreamReader(file);
            var Hexes = new List<BoardHex>();
            for (int i = 0; i < 19; i++)
            {
                var hexValues = sr.ReadLine().Split(',');
                if (hexValues[1] == "D")
                {
                    Hexes.Add(new BoardHex() { Number = 0, Resource = CatanResourceType.Desert, Robber = true });
                }
                else
                {
                    Hexes.Add(new BoardHex() { Number = int.Parse(hexValues[0]), Resource = (CatanResourceType)hexValues[1].First(), Robber = false });
                }
            }
            sr.Close();
            return Hexes;
        }
        public static List<Player> OpenPlayersFile(string file = "../../../Data/Players.txt")
        {
            StreamReader sr = new StreamReader(file);
            var Players = new List<Player>();
            var line = sr.ReadLine();
            while (line != null)
            {
                string[] playerValues = line.Split(',');
                var col = ConsoleUtility.VerifyColorIsAllowed(playerValues[0]);
                var player = new Player() { Color = col, Name = playerValues[1] };
                Players.Add(player);
                line = sr.ReadLine();
            }
            sr.Close();
            return Players;
        }

        public static List<Edge> SetEdgeGraph(List<Edge> edges, string file = "../../../Data/EdgeEdges.txt")
        {
            StreamReader sr = new StreamReader(file);
            var line = sr.ReadLine();
            while (line != null)
            {
                var ints = line.Split('\t').Where(i=>!string.IsNullOrWhiteSpace(i)).Select(i=>int.Parse(i)).ToList();
                edges[ints[0]].LinkedEdges = ints.Skip(1).ToList();
                line = sr.ReadLine();
            }
            sr.Close();
            return edges;
        }

        public static List<Vertex> SetVertexGraph(List<Vertex> vertices, string file = "../../../Data/EdgeEdges.txt")
        {
            StreamReader sr = new StreamReader(file);
            var line = sr.ReadLine();
            while (line != null)
            {
                var ints = line.Split('\t').Where(i => !string.IsNullOrWhiteSpace(i)).Select(i => int.Parse(i)).ToList();
                vertices[ints[0]].LinkedVertices = ints.Skip(1).ToList();
                line = sr.ReadLine();
            }
            sr.Close();
            return vertices;
        }
    }
}
