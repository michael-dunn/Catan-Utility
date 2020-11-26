using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CatanUtility.Classes.Enums;

namespace CatanUtility.Classes
{
    public class Game
    {
        public int Id { get; set; }
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        [NotMapped]
        public bool CloseGame { get; set; }
        public Game()
        {
            Board = new Board();
            Players = new List<Player>();
            CloseGame = false;
        }

        public Game(string file) : this()
        {
            SetBoardFromFile(file);
        }

        public void SetBoardFromFile(string file)
        {
            Board = new Board(file);
        }

        public void DiceRoll(int value)
        {
            var rolledHexIndexes = Board.Hexes.Select((hex, i) => new { hex.Number, i }).Where(h => h.Number == value).Select(h => h.i+1);
            GivePlayersResources(rolledHexIndexes);
        }

        private void GivePlayersResources(IEnumerable<int> rolledHexIndexes)
        {
            foreach (var hexIndex in rolledHexIndexes)
            {
                for (int i = 1; i <= 6; i++)
                {
                    var color = Board.Vertices[GameUtility.GetBoardIndex(hexIndex, i)].Color;
                    var buildingType = Board.Vertices[GameUtility.GetBoardIndex(hexIndex, i)].BuildingType;
                    if (color != null)
                    {
                        var player = Players.FirstOrDefault(p => p.Color.ToLower().Trim() == color.ToLower().Trim());
                        if (player != null)
                        {
                            player.Hand.Add(new Card() { Type = Board.Hexes[hexIndex - 1].Resource });
                            if (buildingType == BuildType.City)
                                player.Hand.Add(new Card() { Type = Board.Hexes[hexIndex - 1].Resource });
                        }
                    }
                }
            }
        }

        public List<int> GetBestVertices()
        {
            var topHexes = new List<BoardHex>();
            var hexScores = new List<int>();
            for (int i = 0; i<54; i++)
            {
                var hexValues = new List<int>();
                foreach(var hexIndex in GameUtility.GetTouchingHexIndices(i))
                {
                    hexValues.Add(Board.Hexes[hexIndex].Number);
                }
                hexScores.Add(GameUtility.GetVertexScore(hexValues));
            }
            var hexandindex = hexScores.Select((score, index) => new { score, index });
            return hexandindex.OrderByDescending(h => h.score).Take(5).Select(h=>h.index).ToList();
        }

        public void BuildDevelopmentCard(string playerColor, bool free = true)
        {
            var player = Players.First(p => p.Color == playerColor);
            if (!free)
            {
                player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wheat));
                player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Ore));
                player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Sheep));
            }
            Console.WriteLine("{0} built a development card", playerColor);
        }

        public bool Build(BuildType buildType, int buildPosition, string playerColor, bool free = false)
        {
            var player = Players.First(p => p.Color == playerColor);
            switch (buildType)
            {
                case BuildType.Road:
                    if (!free)
                    {
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Brick));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wood));
                    }
                    Board.Edges[buildPosition].Color = playerColor;
                    Board.Edges[buildPosition].Occupied = true;
                    break;
                case BuildType.Settlement:
                    if (!free)
                    {
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Brick));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wood));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wheat));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Sheep));
                    }
                    Board.Vertices[buildPosition].BuildingType = buildType;
                    Board.Vertices[buildPosition].Color = playerColor;
                    Board.Vertices[buildPosition].Occupied = true;
                    break;
                case BuildType.City:
                    if (!free)
                    {
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Ore));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Ore));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Ore));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wheat));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wheat));
                    }
                    Board.Vertices[buildPosition].BuildingType = buildType;
                    Board.Vertices[buildPosition].Color = playerColor;
                    Board.Vertices[buildPosition].Occupied = true;
                    break;
                default:
                    return false;   
            }
            return true;
        }
    }
}
