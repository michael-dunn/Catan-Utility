using CatanUtility.Classes;
using CatanUtility.Classes.OLD;
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
            var usedVertices = new List<int>();
            var usedEdges = new List<int>();
            for (int i = 0; i < game.Board.Hexes.Count; i++)
            {
                Hexes.Add(new HexViewModel(game.Board.Hexes[i].Number, game.Board.Hexes[i].Resource.ToString()));
                if (game.Board.Hexes[i].VertexIndices != null)
                {
                    for (int j = 0; j < game.Board.Hexes[i].VertexIndices.Count; j++)
                    {
                        var vertexIndex = game.Board.Hexes[i].VertexIndices[j];
                        if (!usedVertices.Contains(vertexIndex) && game.Board.Vertices[vertexIndex].Occupied)
                        {
                            Hexes[i].Vertices.Add(new VertexViewModel(game.Board.Vertices[vertexIndex], j));
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
                            Hexes[i].Edges.Add(new EdgeViewModel(game.Board.Edges[edgeIndex], j));
                        }
                        usedEdges.Add(edgeIndex);
                    }
                }
            }
        }
    }
}
