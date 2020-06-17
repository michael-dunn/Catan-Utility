using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatanUtility.Classes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatanUtility.Web.Controllers
{
    public class GameController : Controller
    {
        Game game;
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Game()
        {
            game = FileUtility.OpenSaveGame();
            //game.Players = new List<Player>() {
            //    new Player() { Name = "Michael", Color = "Red" },
            //    new Player() { Name = "Emma", Color = "White" },
            //    new Player() { Name = "Mom", Color = "Orange" },
            //};
            return View(game);
        }
    }
}
