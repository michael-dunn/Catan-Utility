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
            var edges = new List<Edge>() {
                new Edge() { Index = 0 },
                new Edge() { Index = 1 },
                null,
                new Edge() { Index = 1 },
                null,
            };
            var moreEdges = edges.Select(e => e).ToList();

            var list = new List<List<Edge>>() { edges, moreEdges };

            var distinctLists = list.Distinct(new ListEdgeComparer()).ToList();

            Assert.IsTrue(distinctLists.Count == 1);
        }

        [Test]
        public void GetLongestRoad()
        {
            var roads = GameUtility.GetLongestRoad(game);
        }
    }
}