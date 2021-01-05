using NUnit.Framework;
using CatanUtility.Classes;
using CatanUtility.Web.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CatanUtility.Classes.Enums;

namespace CatanUtilityTests
{
    public class DbTests
    {
        Game game;
        GameContext db = new GameContext(new DbContextOptionsBuilder<GameContext>()
                .UseSqlite("Data Source = /Users/MichaelDunn/Documents/Development/repos/CatanUtility/CatanUtility.Web/Catan.db")
                .Options);
        [SetUp]
        public void Setup()
        {
            var fileGame = FileUtility.OpenSaveGame("../../../../CatanUtility.Console/Data/TestGame.data");
            fileGame.Build(BuildType.Road, GameUtility.HexEdges[0][0], fileGame.Players.First().Color, true);
            var entityGame = db.Games.Add(fileGame).Entity;
            var changes = db.SaveChanges();
            game = db.Games.FirstOrDefault(g => g.Id == entityGame.Id);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.IsNotNull(game);
        }
    }
}