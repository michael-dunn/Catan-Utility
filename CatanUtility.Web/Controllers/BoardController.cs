﻿using System.Collections.Generic;
using CatanUtility.Classes;
using CatanUtility.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatanUtility.Web.Controllers
{
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        [HttpGet("GetHexes")]
        public IActionResult GetHexes()
        {
            var game = FileUtility.OpenSaveGame("../../CatanUtility/CatanUtility/Data/Game.data");
            GameUtility.SetupGraph(game.Board);

            var usedVertices = new List<int>();
            var usedEdges = new List<int>();
            var hexes = new List<HexViewModel>();
            for (int i =0; i<game.Board.Hexes.Count; i++)
            {
                hexes.Add(new HexViewModel(game.Board.Hexes[i].Number, game.Board.Hexes[i].Resource.ToString()));
                for (int j =0; j < game.Board.Hexes[i].VertexIndices.Count; j++)
                {
                    var vertexIndex = game.Board.Hexes[i].VertexIndices[j];
                    if (!usedVertices.Contains(vertexIndex) && game.Board.Vertices[vertexIndex].Occupied)
                    {
                        hexes[i].Vertices.Add(new VertexViewModel(game.Board.Vertices[vertexIndex],j));
                    }
                    usedVertices.Add(vertexIndex);
                }
                for (int j = 0; j < game.Board.Hexes[i].EdgeIndices.Count; j++)
                {
                    var edgeIndex = game.Board.Hexes[i].EdgeIndices[j];
                    if (!usedEdges.Contains(edgeIndex) && game.Board.Edges[edgeIndex].Occupied)
                    {
                        hexes[i].Edges.Add(new EdgeViewModel(game.Board.Edges[edgeIndex],j));
                    }
                    usedEdges.Add(edgeIndex);
                }
            }

            return Ok(hexes);
        }
    }
}
