using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using CatanUtility.Classes;

namespace CatanUtility
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = ConsoleUtility.OpenSavedGame();
            while (!game.CloseGame)
            {
                ConsoleUtility.GameInput(game);
            }
            Console.WriteLine("Game Closing . . .");
        }
    }
}
