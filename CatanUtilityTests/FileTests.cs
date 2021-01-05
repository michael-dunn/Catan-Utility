using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;

namespace CatanUtilityTests
{
    public class FileTests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = FileUtility.OpenSaveGame("../../../../CatanUtility.Console/Data/TestGame.data");
        }

        [TearDown]
        public void TearDown()
        {
            var staticGame = FileUtility.OpenSaveGame("../../../../CatanUtility.Console/Data/TestGameStatic.data");
            FileUtility.SaveGame(staticGame, "../../../../CatanUtility.Console/Data/TestGame.data");
        }

        [Test]
        public void OpenFromFileWorks()
        {
            Assert.IsNotNull(game);
        }

        [Test]
        public void SaveToFileWorks()
        {
            var edge = game.Board.Edges.First();
            edge.Color = "Red";
            edge.Occupied = true;
            FileUtility.SaveGame(game, "../../../../CatanUtility.Console/Data/TestGame.data");
            var changedGame = FileUtility.OpenSaveGame("../../../../CatanUtility.Console/Data/TestGame.data");
            Assert.AreEqual(changedGame.Board.Edges.First().ToString(), edge.ToString());
        }
    }
}