using System;
using System.Collections.Generic;
using System.Linq;
using CatanUtility.Classes.Structs;

namespace CatanUtility.Classes
{
    public class Game
    {
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public bool CloseGame { get; set; }
        public Game()
        {
            Board = new Board();
            Players = new List<Player>();
            CloseGame = false;
        }

        public void DiceRoll(int value)
        {
            if (value == 7)
            {
                Console.Write("Robber moved to hex position(1-19): ");
                int robberPosition = Board.Hexes.FindIndex(h => h.Robber);
                int nextPosition = Console.Read();
                if (robberPosition != nextPosition && nextPosition >= 1 && nextPosition <=19)
                {
                    Board.Hexes[robberPosition].Robber = false;
                    Board.Hexes[nextPosition-1].Robber = true;
                    Console.WriteLine("Robber moved from {0} to {1}", robberPosition + 1, nextPosition);
                }
                else
                {
                    Console.WriteLine("Robber failed to move");
                }
            }
            else
            {
                var rolledHexIndexes = Board.Hexes.Select((hex, i) => new { hex.Number, i }).Where(h => h.Number == value).Select(h => h.i+1);
                GivePlayersResources(rolledHexIndexes);
            }
        }

        private void GivePlayersResources(IEnumerable<int> rolledHexIndexes)
        {
            foreach (var hexIndex in rolledHexIndexes)
            {
                for (int i = 1; i <= 6; i++)
                {
                    var color = Board.Vertices[GameUtility.BoardIndex(hexIndex, i)].Color;
                    var buildingType = Board.Vertices[GameUtility.BoardIndex(hexIndex, i)].BuildingType;
                    if (color != null)
                    {
                        var player = Players.FirstOrDefault(p => p.Color.ToLower().Trim() == color.ToLower().Trim());
                        if (player != null)
                        {
                            player.Hand.Add(new Card() { Type = Board.Hexes[hexIndex-1].Resource });
                            if (buildingType == BuildType.City)
                                player.Hand.Add(new Card() { Type = Board.Hexes[hexIndex-1].Resource });
                        }
                    }
                }
            }
        }

        public void Build(BuildType developmentCard, string color, bool free = true)
        {
            Console.WriteLine("{0} built a development card", color);
        }

        public void Build(BuildType buildType, int buildPosition, string playerColor, bool free = true)
        {
            switch (buildType)
            {
                case BuildType.Road:
                    Board.Edges[buildPosition].Color = playerColor;
                    Board.Edges[buildPosition].Occupied = true;
                    Console.WriteLine("{0} built a road at index {1}", playerColor, buildPosition);
                    break;
                default:
                    Board.Vertices[buildPosition].BuildingType = buildType;
                    Board.Vertices[buildPosition].Color = playerColor;
                    Board.Vertices[buildPosition].Occupied = true;
                    Console.WriteLine("{0} built a {1} at {2}", playerColor, buildType, buildPosition);
                    break;
            }
        }

        public bool Over() => Players.Any(p=>p.VictoryPoints>10);
    }

    public enum BuildType
    {
        Road = 'R',
        Settlement = 'S',
        City = 'C',
        DevelopmentCard = 'D',
        None = 'N'
    }
}
