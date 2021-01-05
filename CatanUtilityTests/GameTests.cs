using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;
using System.Collections.Generic;
using CatanUtility.Classes.Enums;

namespace CatanUtilityTests
{
    public class GameTests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = FileUtility.OpenSaveGame("../../../../CatanUtility.Console/Data/TestGame.data");
        }

        [Test]
        public void GameIsNotNull()
        {
            Assert.IsNotNull(game);
        }

        [Test]
        public void BoardIsCorrect()
        {
            Assert.AreEqual(CatanResourceType.Sheep, game.Board.Hexes.First().Resource);
            Assert.AreEqual(6, game.Board.Hexes.First().Number);
        }

        [Test]
        public void BuildWorks()
        {
            var position = GameUtility.GetBoardIndex(1, 3);
            game.Build(BuildType.Settlement, position, "Red");

            Assert.AreEqual(BuildType.Settlement, game.Board.Vertices[position].BuildingType);
        }

        [Test]
        public void BuildSettlementCostsCorrectCards()
        {
            var hand = new List<Card>() {
                new Card() { Type = CatanResourceType.Brick },
                new Card() { Type = CatanResourceType.Wood },
                new Card() { Type = CatanResourceType.Wheat },
                new Card() { Type = CatanResourceType.Sheep },
            };
            game.Players.First(p => p.Color == "Red").Hand = hand;
            Assert.AreEqual(hand, game.Players.First(p => p.Color == "Red").Hand);
            var position = GameUtility.GetBoardIndex(1, 3);
            game.Build(BuildType.Settlement, position, "Red", false);

            Assert.IsEmpty(game.Players.First(p => p.Color == "Red").Hand);
        }

        [Test]
        public void GetTouchingHexesWorks()
        {
            Assert.AreEqual(new List<int>() { 0 }, GameUtility.GetTouchingHexIndices(GameUtility.GetBoardIndex(1, 1)));

            Assert.AreEqual(new List<int>() { 0, 1, 4 }, GameUtility.GetTouchingHexIndices(GameUtility.GetBoardIndex(1, 3)));

            Assert.AreEqual(new List<int>() { 13, 16, 17 }, GameUtility.GetTouchingHexIndices(GameUtility.GetBoardIndex(17, 2)));
        }

        [Test]
        public void BestVerticesOnBoardWorks()
        {
            List<int> bestVertices = game.GetBestVertices();

            List<List<int>> bestVerticesNeighboringVertices = bestVertices.Select(v => GameUtility.GetTouchingHexIndices(v)).ToList();
        }
    }
}