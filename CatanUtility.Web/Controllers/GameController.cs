﻿using System.Collections.Generic;
using System.Linq;
using CatanUtility.Classes;
using CatanUtility.Web.Models;
using CatanUtility.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatanUtility.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private GameContext db = new GameContext();

        [HttpGet("GetNewGame")]
        public IActionResult GetNewGame()
        {
            var entityGame = db.Add(new Game()).Entity;
            db.SaveChanges();

            return Ok(entityGame);
        }

        [HttpGet("GetGame")]
        public IActionResult GetGame(int Id)
        {
            var dbGame = db.Games.FirstOrDefault(g => g.Id == Id);
            if (dbGame != null)
            {
                return Ok(new GameViewModel(dbGame));
            }
            return Ok("No data found");
        }

        [HttpGet("DeleteAllGames")]
        public IActionResult DeleteAllGames()
        {
            db.RemoveRange(db.Games.ToList());
            db.SaveChanges();
            return Ok();
        }
    }
}
