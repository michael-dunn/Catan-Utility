using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;
using System.Collections.Generic;

namespace CatanUtilityTests
{
    public class GameTests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = FileUtility.OpenSaveGame("../../../../CatanUtility/Data/TestGame.data");
        }

        [Test]
        public void GameIsNotNull()
        {
            Assert.IsNotNull(game);
        }

        [Test]
        public void BoardIsCorrect()
        {
            Assert.AreEqual(game.Board.Hexes.First().Resource, CatanResourceType.Ore);
            Assert.AreEqual(game.Board.Hexes.First().Number, 10);
        }

        [Test]
        public void BuildWorks()
        {
            var position = GameUtility.GetBoardIndex(1, 3);
            game.Build(BuildType.Settlement, position, "Red");

            Assert.AreEqual(game.Board.Vertices[position].BuildingType, BuildType.Settlement);
        }

        [Test]
        public void BuildCostsCorrectCards()
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

            Assert.IsEmpty(game.Players.First(p=>p.Color == "Red").Hand);
        }

        [Test]
        public void BestBoardSpotsWorks()
        {
            Assert.AreEqual(new List<int>() { 0 },GameUtility.GetTouchingHexIndices(GameUtility.GetBoardIndex(1,1)));

            Assert.AreEqual(new List<int>() { 0, 1, 4 },GameUtility.GetTouchingHexIndices(GameUtility.GetBoardIndex(1, 3)));

            Assert.AreEqual(new List<int>() { 13, 16, 17 }, GameUtility.GetTouchingHexIndices(GameUtility.GetBoardIndex(17, 2)));
        }
    }
}