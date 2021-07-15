using CatanUtility.ConsoleServices;
using CatanUtility.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CatanUtility.Interfaces;

namespace CatanUtility.ConsoleInterface.Tests
{
    [TestClass]
    public class ConsoleServiceTests
    {
        ConsoleService sut;

        [TestInitialize]
        public void Setup()
        {
            var saveService = new Mock<ISaveLoad>();
            var gameService = new Mock<IGameService>();

            sut = new ConsoleService(gameService.Object, saveService.Object);
        }

        [TestMethod]
        public void ActOnInput_WhenNull_ShouldNotThrowError()
        {
            var response = sut.ActOnInput(new string[] { });

            Assert.IsFalse(response);
        }

        [TestMethod]
        public void ActOnInput_WhenLength1_ShouldNotThrowError()
        {
            var response = sut.ActOnInput(new string[] { "x" });

            Assert.IsFalse(response);
        }
    }
}
