using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatanUtility.Classes;
using CatanUtility.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatanUtility.Web.Controllers
{
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var game = FileUtility.OpenSaveGame();
            GameUtility.SetupGraph(game.Board);

            var usedVertices = new List<int>();
            var usedEdges = new List<int>();
            var hexes = new List<HexViewModel>();
            for (int i =0; i<game.Board.Hexes.Count; i++)
            {
                hexes.Add(new HexViewModel());
                for (int j =0; j < game.Board.Hexes[i].VertexIndices.Count; j++)
                {
                    var vertexIndex = game.Board.Hexes[i].VertexIndices[j];
                    if (!usedVertices.Contains(vertexIndex))
                    {
                        hexes[i].Vertices.Add(game.Board.Vertices[vertexIndex]);
                    } else {
                        hexes[i].Vertices.Add(new Vertex());
                    }
                    usedVertices.Add(vertexIndex);
                }
                for (int j = 0; j < game.Board.Hexes[i].EdgeIndices.Count; j++)
                {
                    var edgeIndex = game.Board.Hexes[i].EdgeIndices[j];
                    if (!usedEdges.Contains(edgeIndex))
                    {
                        hexes[i].Edges.Add(game.Board.Edges[edgeIndex]);
                    } else {
                        hexes[i].Edges.Add(new Edge());
                    }
                    usedEdges.Add(edgeIndex);
                }
            }

            return Ok(hexes);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
