using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;
using System.Collections.Generic;
using CatanUtility.Classes.Enums;

namespace CatanUtilityTests
{
    public class NetworkTests
    {
        Game game;
        [SetUp]
        public void Setup()
        {
            game = FileUtility.OpenSaveGame("../../../../CatanUtility.Console/Data/TestGame.data");
            GameUtility.SetupGraph(game.Board);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void CanPlaceOnVertex()
        {
            string playerColor = "Red";
            Assert.IsTrue(game.Build(BuildType.Settlement, GameUtility.HexVertices[0][5], playerColor, true));
            Assert.IsTrue(game.Build(BuildType.Road, GameUtility.HexEdges[0][0], playerColor, true));
            Assert.IsTrue(game.Build(BuildType.Road, GameUtility.HexEdges[0][1], playerColor, true));
            Assert.IsTrue(GameUtility.CanPlaceOnVertex(game, GameUtility.HexVertices[0][1], playerColor));
            Assert.IsFalse(GameUtility.CanPlaceOnVertex(game, GameUtility.HexVertices[0][0], playerColor));
            Assert.IsFalse(GameUtility.CanPlaceOnVertex(game, GameUtility.HexVertices[0][5], playerColor));
            Assert.IsFalse(GameUtility.CanPlaceOnVertex(game, GameUtility.HexVertices[0][2], playerColor));
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