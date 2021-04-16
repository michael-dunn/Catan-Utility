using CatanUtility.ConsoleServices;
using CatanUtility.Models;

namespace CatanUtility.ConsoleConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            ConsoleService consoleService = new ConsoleService(new GameService(), new SaveLoadService());
            while (!consoleService.stopGame)
            {
                consoleService.GameInput(game);
            }
        }
    }
}
