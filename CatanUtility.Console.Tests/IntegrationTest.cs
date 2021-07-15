using CatanUtility.ConsoleServices;
using CatanUtility.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CatanUtility.Interfaces;

namespace CatanUtility.ConsoleInterface.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        ConsoleService consoleService;
        [TestInitialize]
        public void Setup()
        {
            consoleService = new ConsoleService(new GameService(), new SaveLoadService());
            consoleService.SetGame(new Game());
        }

        [TestMethod]
        public void PlayGame()
        {
            consoleService.ActOnInput("s ".Split(' '));
        }
    }
}
