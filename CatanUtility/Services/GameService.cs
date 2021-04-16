using CatanUtility.Interfaces;
using CatanUtility.Models;
using CatanUtility.Models.Enums;
using System.Collections.Generic;

namespace CatanUtility.ConsoleServices
{
    public class GameService : IGameService
    {
        public void AddHarbor(Game game, int hexNumber, int edgeIndex, HarborType harborType)
        {
            throw new System.NotImplementedException();
        }

        public bool Build(BuildType buildType, int buildPosition, string playerColor, bool free = false)
        {
            throw new System.NotImplementedException();
        }

        public void BuildDevelopmentCard(string playerColor, bool free = true)
        {
            throw new System.NotImplementedException();
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

        public void DiceRoll(int value)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetBestVertices()
        {
            throw new System.NotImplementedException();
        }

        public int GetBoardIndex(int hex, int position)
        {
            throw new System.NotImplementedException();
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

        public void GivePlayersResources(IEnumerable<int> rolledHexIndexes)
        {
            throw new System.NotImplementedException();
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
