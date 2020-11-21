using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Classes
{
    public static class ConsoleUtility
    {
        public static bool GameInput(Game game)
        {
            FileUtility.SaveGame(game);
            Console.Write("Enter Input Here: (press h for help)");
            var input = Console.ReadLine().Split(' ');
            int hex, position, buildIndex, diceValue;
            string color;
            bool initialBuild = input.LastOrDefault() == "i";
            switch (input[0])
            {
                case "b"://build
                    if (game.Players.Any())
                    {
                        switch (input[1])
                        {
                            case "s"://settlement
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                position = ParseIntBetweenValues(input[3], "hex position", 1, 6);
                                buildIndex = GameUtility.GetBoardIndex(hex, position);
                                color = VerifyColorInGame(input[4], game.Players);
                                game.Build(BuildType.Settlement, buildIndex, color, initialBuild);
                                return true;
                            case "r"://road
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                position = ParseIntBetweenValues(input[3], "hex position", 1, 6);
                                buildIndex = GameUtility.GetBoardIndex(hex, position);
                                color = VerifyColorInGame(input[4], game.Players);
                                game.Build(BuildType.Road, buildIndex, color, initialBuild);
                                return true;
                            case "c"://city
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                position = ParseIntBetweenValues(input[3], "hex position", 1, 6);
                                buildIndex = GameUtility.GetBoardIndex(hex, position);
                                color = VerifyColorInGame(input[4], game.Players);
                                game.Build(BuildType.City, buildIndex, color, initialBuild);
                                return true;
                            case "d"://development card
                                color = VerifyColorInGame(input[2], game.Players);
                                game.Build(BuildType.DevelopmentCard, color, initialBuild);
                                return true;
                            default:
                                Console.WriteLine("Incorrect building type (s,r,c,d)");
                                return false;
                        }
                    }
                    Console.WriteLine("Add players to game first");
                    return false;
                case "p"://print
                    if (input.Length >= 2)
                    {
                        switch (input[1])
                        {
                            case "h"://hex
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                game.Board.PrintHex(hex);
                                return true;
                            case "b"://board
                                game.Board.PrintBoard();
                                return true;
                            case "p":
                                switch (input[2])
                                {
                                    case "h":
                                        color = VerifyColorInGame(input[3], game.Players);
                                        game.Players.FirstOrDefault(p => p.Color == color).PrintHand();
                                        return true;
                                    case "p":
                                        foreach (var player in game.Players)
                                            Console.WriteLine("{0} - {1}", player.Name, player.Color);
                                        return true;
                                    default:
                                        Console.WriteLine("Incorrect player input (h,p)");
                                        return false;
                                }
                            default:
                                Console.WriteLine("Incorrect print type (h, b, p)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect print input (h, b, p)");
                    return false;
                case "r"://roll
                    if (input.Length == 2)
                    {
                        diceValue = ParseIntBetweenValues(input[1], "dice value", 2, 12);
                        Console.WriteLine("A {0} was rolled.", diceValue);
                        game.DiceRoll(diceValue);
                        return true;
                    }
                    Console.WriteLine("Incorrect role input (h,r)");
                    return false;
                case "s"://setup
                    if (input.Length == 2)
                    {
                        switch (input[1])
                        {
                            case "b": //board
                                game.Board.PromptToBuildBoard();
                                return true;
                            case "p": //player
                                color = VerifyColorIsAllowed(input[3]);
                                game.Players.Add(new Player() { Name = input[2], Color = color });
                                return true;
                            case "pf":
                                game.Players = FileUtility.OpenPlayersFile();
                                return true;
                            default:
                                Console.WriteLine("Incorrect setup input (b,p)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect setup input (b, p)");
                    return false;
                case "q"://quit
                    game.CloseGame = true;
                    return true;
                case "m"://manage game
                    if (input.Length == 2)
                    {
                        switch (input[1])
                        {
                            case "s"://save game
                                FileUtility.SaveGame(game);
                                return true;
                            default:
                                Console.WriteLine("Incorrect manage input (s)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect manage input (s)");
                    return false;
                case "h":
                    Console.WriteLine("Help Section");

                    Console.WriteLine("b - Build");
                    Console.WriteLine("\ts - settlement (b s hex pos col)");
                    Console.WriteLine("\tr - road  (b s hex pos col)");
                    Console.WriteLine("\tc - city  (b s hex pos col)");
                    Console.WriteLine("\td - development card (b d col)");

                    Console.WriteLine("p - Print");
                    Console.WriteLine("\th - hex (p h hex)");
                    Console.WriteLine("\tb - board  (p b)");
                    Console.WriteLine("\tp - player");
                    Console.WriteLine("\t\th - player hand (p p h col)");
                    Console.WriteLine("\t\tp - players (p p p)");

                    Console.WriteLine("r - Roll");
                    Console.WriteLine("\tr (r num)");

                    Console.WriteLine("s - Setup");
                    Console.WriteLine("\tb- Board (s b)");
                    Console.WriteLine("\tp- Player (s p nam col)");
                    Console.WriteLine("\tpf- PlayersFile (s pf)");

                    Console.WriteLine("q - Quit");

                    Console.WriteLine("m - Manage");
                    Console.WriteLine("\ts- Save game (m s)");
                    return true;
                case "v"://verify
                    if (input.Length == 2) {
                        switch (input[1])
                        {
                            case "b"://board
                                var hexes = game.Board.Hexes.Count() == 19;
                                var edges = game.Board.Edges.Count() == 54;
                                var vertices = game.Board.Vertices.Count() == 54;
                                Console.WriteLine("Hexes: {0}, Edges: {1}, Vertices: {2}", hexes, edges, vertices);
                                return true;
                            default:
                                Console.WriteLine("Incorrect verify input (b)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect verify input (b)");
                    return false;
                default:
                    Console.WriteLine("Incorrect action type (b,p,r,s)");
                    return false;
            }
        }

        public static Game OpenSavedGame()
        {
            Console.Write("Would you like to open a saved game from game.data? (Y/N): ");
            return Console.ReadLine() == "Y" ? FileUtility.OpenSaveGame() : new Game();
        }

        public static int ParseInt(string num, string numFor)
        {
            int returnNum = 0;
            if (int.TryParse(num, out returnNum))
                return returnNum;
            Console.WriteLine("{0} is not a number", num);
            Console.Write("Enter a new number for {0}: ", numFor);
            var input = Console.ReadLine();
            return ParseInt(input, numFor);
        }
        public static int ParseIntBetweenValues(string num, string numFor, int min, int max)
        {
            int returnNum = 0;
            if (int.TryParse(num, out returnNum) && returnNum >= min && returnNum <= max)
                return returnNum;
            Console.WriteLine("{0} is not a number or not between {1} and {2}", num, min, max);
            Console.Write("Enter a new number for {0}: ", numFor);
            var input = Console.ReadLine();
            return ParseIntBetweenValues(input, numFor, min, max);
        }
        public static string VerifyColorInGame(string col, List<Player> players)
        {
            if (players.Any(p => p.Color == col))
                return col;
            Console.WriteLine("{0} is not a color of a player.", col);
            Console.Write("Colors include: ");
            foreach (var player in players.Take(players.Count() - 1))
            {
                Console.Write("{0}, ", player.Color);
            }
            Console.Write("{0}, ", players.LastOrDefault().Color);
            Console.Write("Enter correct color: ");
            return VerifyColorInGame(Console.ReadLine(), players);
        }
        public static string VerifyColorIsAllowed(string col)
        {
            var colors = new List<string>() { "Red", "Blue", "White", "Orange" };
            if (colors.Any(p => p.Trim().ToLower() == col.Trim().ToLower()))
                return colors.First(p => p == col);
            Console.WriteLine("{0} is not a color in the game.", col);
            Console.Write("Colors include: ");
            foreach (var color in colors.Take(colors.Count() - 1))
            {
                Console.Write("{0}, ", color);
            }
            Console.Write("{0}, ", colors.LastOrDefault());
            Console.Write("Enter correct color: ");
            return VerifyColorIsAllowed(Console.ReadLine());
        }
    }
}
