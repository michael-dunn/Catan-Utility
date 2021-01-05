using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CatanUtility.Classes.Enums;

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
                sw.Write("{0},{1},{2}", player.Color, player.Name, player.VictoryPoints);
                foreach (var card in player.Hand)
                {
                    sw.Write(",{0}", (char)card.Type);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        public static Game OpenSaveGame(string file = "../../../../../CatanUtility/CatanUtility.Console/Data/Game.data")
        {
            StreamReader sr = new StreamReader(file);
            var game = new Game();
            sr.ReadLine();
            for (int i = 0; i< 19; i++)
            {
                var hexValues = sr.ReadLine().Split(',');
                game.Board.Hexes.Add(new BoardHex()
                {
                    Number = int.Parse(hexValues[0]),
                    Resource = (CatanResourceType)hexValues[1].First(),
                    Robber = bool.Parse(hexValues[2])
                });
            }
            sr.ReadLine();
            for (int i = 0; i < 72; i++)
            {
                var edgeValues = sr.ReadLine().Split(',');
                game.Board.Edges.Add(new Edge()
                {
                    Color = edgeValues[0],
                    Occupied = bool.Parse(edgeValues[1])
                });
            }
            sr.ReadLine();
            for (int i = 0; i < 54; i++)
            {
                var stringvalue = sr.ReadLine();
                var vertexValues = stringvalue.Split(',');
                game.Board.Vertices.Add(new Vertex()
                {
                    Color = vertexValues[0],
                    BuildingType = (BuildType)vertexValues[1].FirstOrDefault(),
                    Occupied = bool.Parse(vertexValues[2])
                });
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
                        player.Hand.Add(new Card() { Type = type });
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

        public static List<Edge> SetEdgeGraph(List<Edge> edges)
        {
            for (int i = 0; i < GameUtility.EdgeEdges.Count; i++)
            {
                edges[i].LinkedEdges = GameUtility.EdgeEdges[i];
            }
            return edges;
        }
        public static List<Vertex> SetVertexGraph(List<Vertex> vertices)
        {
            for (int i = 0; i < GameUtility.VertexEdges.Count; i++)
            {
                vertices[i].LinkedVertices = GameUtility.VertexEdges[i];
            }
            return vertices;
        }
        public static List<BoardHex> SetBoardHexIndices(List<BoardHex> hexes)
        {
            for (int i = 0; i < GameUtility.HexVertices.Count; i++)
            {
                hexes[i].VertexIndices = GameUtility.HexVertices[i];
                hexes[i].EdgeIndices = GameUtility.HexEdges[i];
            }
            return hexes;
        }
    }
}
