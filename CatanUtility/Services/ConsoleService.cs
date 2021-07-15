using CatanUtility.Interfaces;
using CatanUtility.Models;
using CatanUtility.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.ConsoleServices
{
    public class ConsoleService
    {
        private Game _game { get; set; }
        private IGameService _gameService { get; set; }
        private ISaveLoad _saveLoadService { get; set; }
        public bool stopGame { get; private set; }
        public ConsoleService(IGameService gameService, ISaveLoad saveLoadService)
        {
            stopGame = false;
            _gameService = gameService;
            _saveLoadService = saveLoadService;
        }
        public bool GameInput()
        {
            if (_game is null)
            {
                SelectGame();
            }
            _saveLoadService.SaveGame(_game);

            Console.Write("Enter Input Here: (press h for help)");
            var input = Console.ReadLine().Split(' ');

            return ActOnInput(input);
        }
        public bool ActOnInput(string[] input)
        {
            int hex, position, buildIndex, diceValue;
            string color;
            bool initialBuild = input.LastOrDefault() == "i";
            if (input.Length == 0)
                return false;
            switch (input[0])
            {
                case "b"://build
                    if (_game.Players.Any())
                    {
                        switch (input[1])
                        {
                            case "s"://settlement
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                position = ParseIntBetweenValues(input[3], "hex position", 1, 6);
                                buildIndex = _gameService.GetBoardIndex(hex, position);
                                color = VerifyColorInGame(input[4], _game.Players);

                                _gameService.Build(_game, BuildType.Settlement, buildIndex, color, initialBuild);
                                return true;
                            case "r"://road
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                position = ParseIntBetweenValues(input[3], "hex position", 1, 6);
                                buildIndex = _gameService.GetBoardIndex(hex, position);
                                color = VerifyColorInGame(input[4], _game.Players);

                                _gameService.Build(_game, BuildType.Road, buildIndex, color, initialBuild);
                                return true;
                            case "c"://city
                                hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                position = ParseIntBetweenValues(input[3], "hex position", 1, 6);
                                buildIndex = _gameService.GetBoardIndex(hex, position);
                                color = VerifyColorInGame(input[4], _game.Players);

                                _gameService.Build(_game, BuildType.City, buildIndex, color, initialBuild);
                                return true;
                            case "d"://development card
                                color = VerifyColorInGame(input[2], _game.Players);

                                _gameService.BuildDevelopmentCard(_game, color, initialBuild);
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
                                if (input.Length == 3)
                                {

                                    hex = ParseIntBetweenValues(input[2], "hex", 1, 19);
                                    PrintHex(_game.Board, hex);
                                    return true;
                                }
                                return false;
                            case "b"://board
                                PrintBoard(_game.Board);
                                return true;
                            case "p":
                                if (input.Count() < 3)
                                {
                                    return false;
                                }
                                switch (input[2])
                                {
                                    case "h":
                                        color = VerifyColorInGame(input[3], _game.Players);
                                        PrintHand(_game.Players.FirstOrDefault(p => p.Color == color));
                                        return true;
                                    case "p":
                                        foreach (var player in _game.Players)
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
                        if (diceValue != 7)
                        {
                            _gameService.DiceRoll(_game, diceValue);
                        }
                        else
                        {
                            _gameService.MoveRobber(_game.Board, GetNextRobberPosition());
                        }
                        return true;
                    }
                    Console.WriteLine("Incorrect role input (h,r)");
                    return false;
                case "s"://setup
                    if (input.Length > 1)
                    {
                        switch (input[1])
                        {
                            case "b": //board
                                PromptToBuildBoard();
                                return true;
                            case "h": //harbor
                                PromptToAddHarbor();
                                return true;
                            case "p": //player
                                color = VerifyColorIsAllowed(input[3]);
                                _gameService.AddPlayer(_game, new Player() { Name = input[2], Color = color });
                                return true;
                            default:
                                Console.WriteLine("Incorrect setup input (b,p)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect setup input (b, p)");
                    return false;
                case "q"://quit
                    stopGame = true;
                    return true;
                case "m"://manage game
                    if (input.Length == 2)
                    {
                        switch (input[1])
                        {
                            case "s"://save game
                                _saveLoadService.SaveGame(_game);
                                return true;
                            default:
                                Console.WriteLine("Incorrect manage input (s)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect manage input (s)");
                    return false;
                case "h":
                    PrintHelp();
                    return true;
                case "v"://verify
                    if (input.Length == 2)
                    {
                        switch (input[1])
                        {
                            case "b"://board
                                var hexes = _game.Board.Hexes.Count() == 19;
                                var edges = _game.Board.Edges.Count() == 54;
                                var vertices = _game.Board.Vertices.Count() == 54;
                                Console.WriteLine("Hexes: {0}, Edges: {1}, Vertices: {2}", hexes, edges, vertices);
                                return true;
                            default:
                                Console.WriteLine("Incorrect verify input (b)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect verify input (b)");
                    return false;
                case "g"://get
                    if (input.Count() > 1)
                    {
                        switch (input[1])
                        {
                            case "s"://best spots
                                var bestVertices = _gameService.GetBestVertices();
                                for (int i = 0; i < bestVertices.Count() - 1; i++)
                                {
                                    Console.Write("{0}, ", bestVertices[i]);
                                }
                                Console.WriteLine("{0}", bestVertices.Last());
                                return true;
                            default:
                                Console.WriteLine("Incorrect verify input (g)");
                                return false;
                        }
                    }
                    Console.WriteLine("Incorrect verify input (g)");
                    return false;
                default:
                    Console.WriteLine("Incorrect action type (b,p,r,s)");
                    return false;
            }
        }

        private void PrintHelp()
        {
            Console.WriteLine("Help Section");

            if (_game.Players != null &&_game.Players.Count > 2)
            {
                Console.WriteLine("b - Build");
                Console.WriteLine("\ts - settlement (b s hex pos col)");
                Console.WriteLine("\tr - road  (b s hex pos col)");
                Console.WriteLine("\tc - city  (b s hex pos col)");
                Console.WriteLine("\td - development card (b d col)");
            }
            if (_game.Board != null && _game.Board.Hexes.Count > 0)
            {
                Console.WriteLine("p - Print");
                Console.WriteLine("\th - hex (p h hex)");
                Console.WriteLine("\tb - board  (p b)");
                if (_game.Players != null && _game.Players.Count > 2)
                {
                    Console.WriteLine("\tp - player");
                    Console.WriteLine("\t\th - player hand (p p h col)");
                    Console.WriteLine("\t\tp - players (p p p)");

                    Console.WriteLine("r - Roll");
                    Console.WriteLine("\tr (r num)");
                }
            }

            Console.WriteLine("s - Setup");
            Console.WriteLine("\tb- Board (s b)");
            Console.WriteLine("\tp- Player (s p nam col)");
            Console.WriteLine("\tpf- PlayersFile (s pf)");

            Console.WriteLine("q - Quit");

            Console.WriteLine("m - Manage");
            Console.WriteLine("\ts- Save game (m s)");
        }

        private void SelectGame()
        {
            Console.Write("Would you like to open a saved game from game.data? (Y/N): ");
            string userInput = Console.ReadLine().ToUpper().Trim();
            while (!new List<string>() { "Y", "N" }.Contains(userInput)){
                Console.WriteLine("Must be either 'Y' or 'N'");
                userInput = Console.ReadLine().ToUpper().Trim();
            }
            _game = userInput == "Y" ? _saveLoadService.LoadGame() : new Game();
        }
        public void SetGame(Game game)
        {
            _game = game;
        }
        private int ParseInt(string num, string numFor)
        {
            int returnNum = 0;
            if (int.TryParse(num, out returnNum))
                return returnNum;
            Console.WriteLine("{0} is not a number", num);
            Console.Write("Enter a new number for {0}: ", numFor);
            return ParseInt(Console.ReadLine(), numFor);
        }
        private int ParseIntBetweenValues(string num, string numFor, int min, int max)
        {
            int returnNum = 0;
            if (int.TryParse(num, out returnNum) && returnNum >= min && returnNum <= max)
                return returnNum;
            Console.WriteLine("{0} is not a number or not between {1} and {2}", num, min, max);
            Console.Write("Enter a new number for {0}: ", numFor);
            return ParseIntBetweenValues(Console.ReadLine(), numFor, min, max);
        }
        private HarborType ParseHarborType(string harborType)
        {
            if (Enum.IsDefined(typeof(HarborType), (HarborType)harborType.First()))
            {
                return (HarborType)harborType.First();
            }
            Console.WriteLine("{0} is not a Harbor Type", harborType);
            Console.WriteLine("Harbor Types: Sheep = 'S', Wheat = 'H', Ore = 'O', Brick = 'B', Wood = 'W', Any = 'A'");
            Console.Write("Enter a new char for harbor type: ");
            return ParseHarborType(Console.ReadLine());
        }
        private string VerifyColorInGame(string col, List<Player> players)
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
        private string VerifyColorIsAllowed(string col)
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
        private void PrintHand(Player player)
        {
            var orderedHand = player.Hand.OrderBy(h => h).ToList();
            Console.Write("{0}", orderedHand.FirstOrDefault().ToString() ?? "No cards");
            for (int i = 1; i < orderedHand.Count(); i++)
                Console.Write(", {0}", orderedHand[i]);
            Console.WriteLine();
        }
        private void PrintHex(Board board, int hexNumber)
        {
            if (board.Hexes.Count == 19 && board.Vertices.Count == 54 && board.Edges.Count == 72)
            {
                Console.WriteLine("{0,25}", board.Vertices[_gameService.GetBoardIndex(hexNumber, 1)]);
                Console.WriteLine("{0,15}{1,17}", board.Edges[_gameService.GetBoardIndex(hexNumber, 6)], board.Edges[_gameService.GetBoardIndex(hexNumber, 1)]);
                Console.WriteLine("{0,0}{1,30}", board.Vertices[_gameService.GetBoardIndex(hexNumber, 6)], board.Vertices[_gameService.GetBoardIndex(hexNumber, 2)]);
                Console.WriteLine("{0,0}{1,15}{2,15}", board.Edges[_gameService.GetBoardIndex(hexNumber, 5)], board.Hexes[hexNumber - 1], board.Edges[_gameService.GetBoardIndex(hexNumber, 2)]);
                Console.WriteLine("{0,0}{1,30}", board.Vertices[_gameService.GetBoardIndex(hexNumber, 5)], board.Vertices[_gameService.GetBoardIndex(hexNumber, 3)]);
                Console.WriteLine("{0,15}{1,17}", board.Edges[_gameService.GetBoardIndex(hexNumber, 4)], board.Edges[_gameService.GetBoardIndex(hexNumber, 3)]);
                Console.WriteLine("{0,25}", board.Vertices[_gameService.GetBoardIndex(hexNumber, 4)]);
            }
            else
                Console.WriteLine("Board not fully setup");
        }
        private void PrintBoard(Board board)
        {
            if (board.Hexes.Count > 0)
            {
                PrintRow(board.Hexes.Take(3), 6);
                PrintRow(board.Hexes.Skip(3).Take(4), 3);
                PrintRow(board.Hexes.Skip(7).Take(5), 0);
                PrintRow(board.Hexes.Skip(12).Take(4), 3);
                PrintRow(board.Hexes.Skip(16).Take(3), 6);
            }
            else
            {
                Console.WriteLine("Board is not set up. Try setting it up with the command 's b'");
                Console.WriteLine();
            }
        }
        private void PrintRow(IEnumerable<BoardHex> hexLine, int startSpaces)
        {
            Console.Write(new string(' ', startSpaces));
            foreach (var hex in hexLine)
                Console.Write(hex + " ");
            Console.WriteLine('\n');
        }
        private int GetNextRobberPosition()
        {
            Console.Write("Move robber to hex position(1-19): ");
            return ParseIntBetweenValues(Console.ReadLine(), "Robber position", 1, 19);
        }
        private void PromptToBuildBoard()
        {
            Console.Write("Open saved board, if not random board will be built? (Y/N) ");
            var response = Console.ReadLine();
            Console.WriteLine();
            if (response == "Y")
            {
                _game.Board.Hexes = new List<BoardHex>(); //TODO add board file open thing
            }
            else
            {
                _game.Board = _gameService.BuildRandomBoard();
            }
        }
        private void PromptToAddHarbor()
        {
            Console.WriteLine("Harbor Types: Sheep = 'S', Wheat = 'H', Ore = 'O', Brick = 'B', Wood = 'W', Any = 'A'");
            Console.Write("To add a harbor, provide hex number, edge index, and type like 'h,e,t'");

            int hexNumber, edgeIndex;
            HarborType harborType;

            var input = Console.ReadLine();
            var splitInput = input.Replace(' ', '\0').Split(",");
            do {
                hexNumber = ParseIntBetweenValues(splitInput[0], "Hex", 1, 19);
                edgeIndex = ParseIntBetweenValues(splitInput[1], "Edge", 1, 6);
                harborType = ParseHarborType(splitInput[2]);
            } while (splitInput.Count() != 3);

            Console.WriteLine("Adding harbor {0} {1} to hex {2}, edge {3}",
                harborType.ToString(), harborType == HarborType.Any ? "3:1" : "2:1", hexNumber, edgeIndex);

            throw new NotImplementedException();
            //_gameService.AddHarbor(game, hexNumber, edgeIndex, harborType);
        }

    }
}
