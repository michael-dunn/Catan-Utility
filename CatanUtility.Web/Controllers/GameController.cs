using System.Collections.Generic;
using System.Linq;
using CatanUtility.Classes;
using CatanUtility.Web.Models;
using CatanUtility.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatanUtility.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private GameContext db = new GameContext();

        [HttpGet("{action}")]
        public IActionResult GetTestGame()
        {
            var game = new Game();
            game.Board.BuildRandomBoard();
            game.Players.Add(new Player() { Color = "Orange", Name = "Michael" });
            game.Players.Add(new Player() { Color = "White", Name = "Emma" });
            game.Players.Add(new Player() { Color = "Blue", Name = "Dad" });
            game.Build(Classes.Enums.BuildType.Road, GameUtility.HexEdges[0][0], "Orange");
            game.Build(Classes.Enums.BuildType.Road, GameUtility.HexEdges[0][1], "Orange");
            game.Build(Classes.Enums.BuildType.Road, GameUtility.HexEdges[0][2], "Orange");
            game.Build(Classes.Enums.BuildType.Road, GameUtility.HexEdges[1][4], "Orange");
            game.Build(Classes.Enums.BuildType.City, GameUtility.HexVertices[0][5], "Orange");
            game.Build(Classes.Enums.BuildType.City, GameUtility.HexVertices[1][4], "Orange");

            GameUtility.SetupGraph(game.Board);

            return Ok(new GameViewModel(game));
        }

        [HttpGet("{action}")]
        public IActionResult GetNewGame()
        {
            var entityGame = db.Add(new Game()).Entity;
            db.SaveChanges();

            return Ok(new GameViewModel(entityGame));
        }

        [HttpGet("{action}")]
        public IActionResult GetGame(int Id)
        {
            var dbGame = db.Games.FirstOrDefault(g => g.Id == Id);
            if (dbGame != null)
            {
                return Ok(new GameViewModel(dbGame));
            }
            return Ok("No data found");
        }

        [HttpGet("{action}")]
        public IActionResult DeleteAllGames()
        {
            db.RemoveRange(db.Games.Include(g=>g.Board).ToList());
            db.SaveChanges();
            return Ok();
        }

        [HttpPost("{action}")]
        public IActionResult SetHex([FromBody] HexViewModel hexViewModel)
        {

            return Ok();
        }
    }
}
