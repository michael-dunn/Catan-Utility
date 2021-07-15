using CatanUtility.Interfaces;
using CatanUtility.Models;
using CatanUtility.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.ConsoleServices
{
    public class GameService : IGameService
    {
        public void AddHarbor(Game game, int hexNumber, int edgeIndex, HarborType harborType)
        {
            throw new System.NotImplementedException();
        }

        public bool Build(Game game, BuildType buildType, int buildPosition, string playerColor, bool free = false)
        {
            var player = game.Players.First(p => p.Color == playerColor);
            switch (buildType)
            {
                case BuildType.Road:
                    if (!free)
                    {
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Brick));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wood));
                    }
                    game.Board.Edges[buildPosition].Color = playerColor;
                    game.Board.Edges[buildPosition].Occupied = true;
                    break;
                case BuildType.Settlement:
                    if (!free)
                    {
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Brick));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wood));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wheat));
                        player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Sheep));
                    }
                    game.Board.Vertices[buildPosition].BuildingType = buildType;
                    game.Board.Vertices[buildPosition].Color = playerColor;
                    game.Board.Vertices[buildPosition].Occupied = true;
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
                    game.Board.Vertices[buildPosition].BuildingType = buildType;
                    game.Board.Vertices[buildPosition].Color = playerColor;
                    game.Board.Vertices[buildPosition].Occupied = true;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public void BuildDevelopmentCard(Game game, string playerColor, bool free = true)
        {
            var player = game.Players.First(p => p.Color == playerColor);
            if (!free)
            {
                player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Wheat));
                player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Ore));
                player.Hand.Remove(player.Hand.FirstOrDefault(c => c.Type == CatanResourceType.Sheep));
            }
            Console.WriteLine("{0} built a development card", playerColor);
            //Distribute card
            throw new NotImplementedException();
        }

        public Board BuildRandomBoard()
        {
            throw new System.NotImplementedException();
        }

        public bool CanPlaceOnVertex(Game game, int vertexIndex, string playerColor)
        {
            throw new System.NotImplementedException();
        }

        public bool CanPlaceRoad(Game game, int edgeIndex, string playerColor)
        {
            throw new System.NotImplementedException();
        }

        public void DiceRoll(Game game, int value)
        {
            var rolledHexIndexes = game.Board.Hexes.Select((hex, i) => new { hex.Number, i }).Where(h => h.Number == value).Select(h => h.i + 1);
            GivePlayersResources(game, rolledHexIndexes);
        }

        public List<int> GetBestVertices()
        {
            throw new System.NotImplementedException();
        }

        public int GetBoardIndex(int hex, int position)
        {
            int topNumber;
            int returnNumber = 0;
            if (1 <= hex && hex <= 3)
            {
                switch (position)
                {
                    case 1:
                        returnNumber = hex;
                        break;
                    case 2:
                        returnNumber = hex + 4;
                        break;
                    case 3:
                        returnNumber = hex + 8;
                        break;
                    case 4:
                        returnNumber = hex + 12;
                        break;
                    case 5:
                        returnNumber = hex + 7;
                        break;
                    case 6:
                        returnNumber = hex + 3;
                        break;
                }
            }
            else if (4 <= hex && hex <= 7)
            {
                topNumber = (hex * 2) - (hex - 4);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 5;
                        break;
                    case 3:
                        returnNumber = topNumber + 10;
                        break;
                    case 4:
                        returnNumber = topNumber + 15;
                        break;
                    case 5:
                        returnNumber = topNumber + 9;
                        break;
                    case 6:
                        returnNumber = topNumber + 4;
                        break;
                }
            }
            else if (8 <= hex && hex <= 12)
            {
                topNumber = hex * 2 - (hex - 9);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 6;
                        break;
                    case 3:
                        returnNumber = topNumber + 12;
                        break;
                    case 4:
                        returnNumber = topNumber + 17;
                        break;
                    case 5:
                        returnNumber = topNumber + 11;
                        break;
                    case 6:
                        returnNumber = topNumber + 5;
                        break;
                }
            }
            else if (13 <= hex && hex <= 16)
            {
                topNumber = hex * 2 - (hex - 16);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 6;
                        break;
                    case 3:
                        returnNumber = topNumber + 11;
                        break;
                    case 4:
                        returnNumber = topNumber + 15;
                        break;
                    case 5:
                        returnNumber = topNumber + 10;
                        break;
                    case 6:
                        returnNumber = topNumber + 5;
                        break;
                }
            }
            else if (17 <= hex && hex <= 19)
            {
                topNumber = hex * 2 - (hex - 23);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 5;
                        break;
                    case 3:
                        returnNumber = topNumber + 9;
                        break;
                    case 4:
                        returnNumber = topNumber + 12;
                        break;
                    case 5:
                        returnNumber = topNumber + 8;
                        break;
                    case 6:
                        returnNumber = topNumber + 4;
                        break;
                }
            }
            if (returnNumber == 0)
                returnNumber = -2;
            return returnNumber - 1;
        }

        public List<List<Edge>> GetLongestRoad(Game game)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTouchingHexIndices(int vertexIndex)
        {
            throw new System.NotImplementedException();
        }

        public int GetVertexScore(List<int> hexValues)
        {
            throw new System.NotImplementedException();
        }

        public void GivePlayersResources(Game game, IEnumerable<int> rolledHexIndexes)
        {
            foreach (var hexIndex in rolledHexIndexes)
            {
                for (int i = 1; i <= 6; i++)
                {
                    var color = game.Board.Vertices[GetBoardIndex(hexIndex, i)].Color;
                    var buildingType = game.Board.Vertices[GetBoardIndex(hexIndex, i)].BuildingType;
                    if (color != null)
                    {
                        var player = game.Players.FirstOrDefault(p => p.Color.ToLower().Trim() == color.ToLower().Trim());
                        if (player != null)
                        {
                            player.Hand.Add(new Card() { Type = game.Board.Hexes[hexIndex - 1].Resource });
                            if (buildingType == BuildType.City)
                                player.Hand.Add(new Card() { Type = game.Board.Hexes[hexIndex - 1].Resource });
                        }
                    }
                }
            }
        }

        public bool MoveRobber(Board board, int newPosition)
        {
            throw new System.NotImplementedException();
        }

        public void SetupGraph(Board board)
        {
            throw new System.NotImplementedException();
        }


    }
}
