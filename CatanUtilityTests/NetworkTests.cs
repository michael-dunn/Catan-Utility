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
            GameUtility.SetupGraph(game.Board, "../../../../CatanUtility/Data/Constants/");
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
            string playerColor = "Red";
            game.Build(BuildType.Settlement, game.Board.Hexes[0].VertexIndices[0], playerColor);
            Assert.IsTrue(GameUtility.CanPlaceRoad(game, game.Board.Hexes[0].EdgeIndices[0], playerColor));
            Assert.IsTrue(GameUtility.CanPlaceRoad(game, game.Board.Hexes[0].EdgeIndices[1], playerColor));
            Assert.IsFalse(GameUtility.CanPlaceRoad(game, game.Board.Hexes[0].EdgeIndices[2], playerColor));
        }

        [Test]
        public void GetLongestRoad()
        {
            game.Build(BuildType.Road, game.Board.Hexes[0].EdgeIndices[0], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[0].EdgeIndices[1], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[0].EdgeIndices[2], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[0].EdgeIndices[3], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[0].EdgeIndices[4], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[0].EdgeIndices[5], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[1].EdgeIndices[0], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[1].EdgeIndices[1], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[1].EdgeIndices[2], "Red");
            game.Build(BuildType.Road, game.Board.Hexes[2].EdgeIndices[5], "Red");
            var roads = GameUtility.GetLongestRoad(game);
        }
    }
}