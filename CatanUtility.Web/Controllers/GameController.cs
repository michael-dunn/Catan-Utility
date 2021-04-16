using CatanUtility.Classes.OLD;
using CatanUtility.Web.Models;
using CatanUtility.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatanUtility.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private GameContext db = new GameContext();

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
