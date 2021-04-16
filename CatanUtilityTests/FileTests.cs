using CatanUtility.Classes;
using CatanUtility.Classes.OLD;
using NUnit.Framework;
using System.Linq;

namespace CatanUtility.TestsOld
{
    public class FileTests
    {
        Game game, unmodifiedGame;

        [SetUp]
        public void Setup()
        {
            game = FileUtility.OpenSaveGame("../../../../CatanUtility/Data/TestGame.data");
            unmodifiedGame = FileUtility.OpenSaveGame("../../../../CatanUtility/Data/TestGame.data");
        }

        [TearDown]
        public void TearDown()
        {
            FileUtility.SaveGame(unmodifiedGame, "../../../../CatanUtility/Data/TestGame.data");
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
            FileUtility.SaveGame(game, "../../../../CatanUtility/Data/TestGame.data");
            var changedGame = FileUtility.OpenSaveGame("../../../../CatanUtility/Data/TestGame.data");
            Assert.AreEqual(changedGame.Board.Edges.First().ToString(), edge.ToString());
        }
    }
}