using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatanUtility.Classes;
using CatanUtility.Web.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatanUtility.Web.Controllers
{
    public class GameController : Controller
    {
        Game game;
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Game()
        {
            game = FileUtility.OpenSaveGame();
            GameUtility.SetupGraph(game.Board);
            
            return View(new GameViewModel(game));
        }

    }
}
