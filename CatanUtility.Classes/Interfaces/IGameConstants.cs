using System.Collections.Generic;

namespace CatanUtility.Interfaces
{
    public interface IGameConstants
    {
        List<List<int>> HexVertices { get; }
        List<List<int>> HexEdges { get; }
        List<List<int>> EdgeEdges { get; }
        List<List<int>> VertexEdges { get; }
    }
}
