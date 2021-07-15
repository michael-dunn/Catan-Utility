using CatanUtility.ConsoleServices;
using CatanUtility.Models;
using System;

namespace CatanUtility.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ConsoleService consoleService = new ConsoleService(new GameService(), new SaveLoadService());
           
            while (!consoleService.stopGame)
            {
                if (!consoleService.GameInput())
                {
                    Console.WriteLine("Unsuccessful input");
                }
            }
        }
    }
}
