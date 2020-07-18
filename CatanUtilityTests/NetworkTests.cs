using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;
using System.Collections.Generic;

namespace CatanUtilityTests
{
    public class NetworkTests
    {
        Game game;
        [SetUp]
        public void Setup()
        {
            game = FileUtility.OpenSaveGame("../../../../CatanUtility/Data/TestGame.data");
            GameUtility.SetupGraph(game.Board, "../../../../CatanUtility/Data/");
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void CanPlaceSettlement()
        {

        }

        [Test]
        public void CanPlaceRoad()
        {

        }

        [Test]
        public void GetLongestRoad()
        {
            List<Edge> roads = GameUtility.GetLongestRoad(game);
        }
    }
}