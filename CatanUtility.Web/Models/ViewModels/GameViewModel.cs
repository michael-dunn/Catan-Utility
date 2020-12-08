using CatanUtility.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CatanUtility.Web.Models.ViewModels
{
    public class GameViewModel
    {
        public List<HexViewModel> Hexes { get; set; }

        public GameViewModel() { }
        public GameViewModel(Game game)
        {
            Hexes = new List<HexViewModel>() { };
            var spacerHex = new HexViewModel() { ResourceType = "spacer" };
            var waterHex = new HexViewModel() { ResourceType = "water" };
            var usedVertices = new List<int>();
            var usedEdges = new List<int>();

            //First Row
            Hexes.Add(spacerHex);
            Hexes.Add(waterHex);
            Hexes.Add(waterHex);
            Hexes.Add(waterHex);
            Hexes.Add(waterHex);

            //Rows 2 through 6
            for (int i = 0; i < game.Board.Hexes.Count; i++)
            {
                if (HexConstants.StartHexRows.Contains(i))
                {
                    if (i == HexConstants.StartHexRows.First() || i == HexConstants.StartHexRows.Last())
                    {
                        Hexes.Add(spacerHex);
                    }
                    Hexes.Add(waterHex);
                }
                Hexes.Add(new HexViewModel(game.Board.Hexes[i].Number, game.Board.Hexes[i].Resource.ToString()));
                if (game.Board.Hexes[i].VertexIndices != null)
                {
                    for (int j = 0; j < game.Board.Hexes[i].VertexIndices.Count; j++)
                    {
                        var vertexIndex = game.Board.Hexes[i].VertexIndices[j];
                        if (!usedVertices.Contains(vertexIndex) && game.Board.Vertices[vertexIndex].Occupied)
                        {
                            Hexes.Last().Vertices.Add(new VertexViewModel(game.Board.Vertices[vertexIndex], j));
                        }
                        usedVertices.Add(vertexIndex);
                    }
                }
                if (game.Board.Hexes[i].EdgeIndices != null)
                {
                    for (int j = 0; j < game.Board.Hexes[i].EdgeIndices.Count; j++)
                    {
                        var edgeIndex = game.Board.Hexes[i].EdgeIndices[j];
                        if (!usedEdges.Contains(edgeIndex) && game.Board.Edges[edgeIndex].Occupied)
                        {
                            Hexes.Last().Edges.Add(new EdgeViewModel(game.Board.Edges[edgeIndex], j));
                        }
                        usedEdges.Add(edgeIndex);
                    }
                }
                if (HexConstants.EndHexRows.Contains(i))
                {
                    Hexes.Add(waterHex);
                }
            }
            //Row 7
            Hexes.Add(spacerHex);
            Hexes.Add(waterHex);
            Hexes.Add(waterHex);
            Hexes.Add(waterHex);
            Hexes.Add(waterHex);
        }
    }

    public static class HexConstants
    {
        public static readonly List<int> StartHexRows = new List<int> { 0, 3, 7, 12, 16 };
        public static readonly List<int> EndHexRows = new List<int> { 2, 6, 11, 15, 18 };
    }
}
