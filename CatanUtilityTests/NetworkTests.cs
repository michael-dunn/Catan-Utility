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
            var roads = GameUtility.GetLongestRoad(game);
            var ool = roads[0].Equals(roads[1]);
            var str = "";
        }
    }
}