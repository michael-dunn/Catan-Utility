using NUnit.Framework;
using CatanUtility.Classes;

namespace CatanUtilityTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OpenGameFromSaveFile()
        {
            var game = FileUtility.OpenSaveGame("../../../../CatanUtility/Data/Game.data");
            Assert.IsNotNull(game);
        }
    }
}