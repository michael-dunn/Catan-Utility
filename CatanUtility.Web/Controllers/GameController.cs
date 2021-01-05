using System.Linq;
using CatanUtility.Classes;
using CatanUtility.Classes.Enums;
using CatanUtility.Web.Models;
using CatanUtility.Web.Models.ViewModels;
using CatanUtility.Web.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CatanUtility.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly GameContext _context;

        public GameController(GameContext context)
        {
            _context = context;
        }

        [HttpGet("{action}")]
        public IActionResult GetTestGame()
        {
            var game = _context.Add(new Game()).Entity;
            game.Board.SetupLists();
            game.Board.BuildRandomBoard();
            game.Players.Add(new Player() { Color = "Orange", Name = "Michael" });
            game.Players.Add(new Player() { Color = "White", Name = "Emma" });
            game.Players.Add(new Player() { Color = "Blue", Name = "Dad" });
            game.Build(BuildType.Road, GameUtility.HexEdges[0][0], "Orange");
            game.Build(BuildType.Road, GameUtility.HexEdges[0][1], "Orange");
            game.Build(BuildType.Road, GameUtility.HexEdges[0][2], "Orange");
            game.Build(BuildType.Road, GameUtility.HexEdges[1][4], "Orange");
            game.Build(BuildType.City, GameUtility.HexVertices[0][5], "Orange");
            game.Build(BuildType.City, GameUtility.HexVertices[1][4], "Orange");

            GameUtility.SetupGraph(game.Board);

            var changes = _context.SaveChanges();

            return Ok(new GameViewModel(game));
        }

        [HttpGet("{action}")]
        public IActionResult GetNewGame()
        {
            var entityGame = _context.Add(new Game()).Entity;
            _context.SaveChanges();

            return Ok(new GameViewModel(entityGame));
        }

        [HttpGet("{action}")]
        public IActionResult GetGame(int Id)
        {
            var dbGame = _context.Games.FirstOrDefault(g => g.Id == Id);
            if (dbGame != null)
            {
                return Ok(new GameViewModel(dbGame));
            }
            return Ok("No data found");
        }

        [HttpGet("{action}")]
        public IActionResult DeleteAllGames()
        {
            _context.RemoveRange(_context.Games.Include(g=>g.Board).ToList());
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("{action}")]
        public IActionResult SetHex([FromBody] HexViewModel hexViewModel)
        {
            return Ok();
        }

        [HttpPost("{action}")]
        public IActionResult AddBuilding(int boardId, [FromBody]BuildingForm buildingForm)
        {
            var entityGame = _context.Games
                .Include(g => g.Players)
                .Include(g => g.Board)
                    .ThenInclude(b => b.Hexes)
                .FirstOrDefault(g => g.Id == boardId);
            var entityBoard = _context.Boards
                .Include("Hexes")
                .Include("Edges")
                .Include("Vertices")
                .FirstOrDefault(b => b.Id == boardId);
            if (buildingForm.BuildingType == BuildType.Road.ToString())
            {
                var position = GameUtility.HexEdges[int.Parse(buildingForm.Hex)][int.Parse(buildingForm.Position)];
                entityGame.Build(BuildType.Road, position, "Orange", true);
            }
            else
            {
                var position = GameUtility.HexVertices[int.Parse(buildingForm.Hex)][int.Parse(buildingForm.Position)];
                var type = (BuildType)Enum.Parse(typeof(BuildType), buildingForm.BuildingType);
                entityGame.Build(type, position, "Orange", true);
            }
            int changes = _context.SaveChanges();

            return Ok(new GameViewModel(entityGame));
        }
    }
}
