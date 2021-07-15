using CatanUtility.Interfaces;
using CatanUtility.Models;
using CatanUtility.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CatanUtility.ConsoleServices
{
    public class SaveLoadService : ISaveLoad
    {
        private string _file = "../../../Data/Game.data";
        public Game LoadGame()
        {
            StreamReader sr = new StreamReader(_file);
            var game = new Game()
            {
                Board = new Board()
                {
                    Edges = new List<Edge>(),
                    Harbors = new List<Harbor>(),
                    Hexes = new List<BoardHex>(),
                    Vertices = new List<Vertex>()
                },
                Players = new List<Player>()
            };
            sr.ReadLine();
            for (int i = 0; i < 19; i++)
            {
                var hexValues = sr.ReadLine().Split(',');
                game.Board.Hexes.Add(new BoardHex() { Number = int.Parse(hexValues[0]), Resource = (CatanResourceType)hexValues[1].First(), Robber = bool.Parse(hexValues[2]) });
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

        public bool SaveGame(Game game)
        {
            try
            {
                StreamWriter sw = new StreamWriter(_file);
                if (game.Board != null && game.Board.Edges[0] != null)
                {
                    sw.WriteLine("--Hexes--");
                    foreach (var hex in game.Board.Hexes)
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

                }
                if (game.Players != null)
                {
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

                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }
    }
}
