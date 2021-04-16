using CatanUtility.ConsoleServices;
using CatanUtility.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CatanUtility.Interfaces;

namespace CatanUtility.Console.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        Game game;
        GameService sut;

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void ActOnInput_WhenNull_ShouldNotThrowError()
        {
            
        }
    }
}
