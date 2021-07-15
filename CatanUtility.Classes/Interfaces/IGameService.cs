using CatanUtility.Models;
using CatanUtility.Models.Enums;
using System.Collections.Generic;

namespace CatanUtility.Interfaces
{
    public interface IGameService
    {
        void DiceRoll(Game game, int value);
        void GivePlayersResources(Game game, IEnumerable<int> rolledHexIndexes);
        List<int> GetBestVertices();
        void BuildDevelopmentCard(Game game, string playerColor, bool free = true);
        bool Build(Game game, BuildType buildType, int buildPosition, string playerColor, bool free = false);
        int GetBoardIndex(int hex, int position);
        int GetVertexScore(List<int> hexValues);
        List<int> GetTouchingHexIndices(int vertexIndex);
        void SetupGraph(Board board);
        bool CanPlaceOnVertex(Game game, int vertexIndex, string playerColor);
        bool CanPlaceRoad(Game game, int edgeIndex, string playerColor);
        bool MoveRobber(Board board, int newPosition);
        List<List<Edge>> GetLongestRoad(Game game);
        void AddHarbor(Game game, int hexNumber, int edgeIndex, HarborType harborType);
        Board BuildRandomBoard();
        void AddPlayer(Game game, Player player);
    }
}
