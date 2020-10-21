using CatanUtility.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CatanUtility.Web.Models.ViewModels
{
    public class GameViewModel
    {
        public List<List<HexViewModel1>> HexRows { get; set; }

        public GameViewModel() { }
        public GameViewModel(Game game)
        {
            var waterHex = new HexViewModel1() { HexResource = "water" };
            var spacerHex = new HexViewModel1() { HexResource = "spacer" };
            var waterRows = new List<HexViewModel1>() { spacerHex, waterHex, waterHex, waterHex, waterHex };
            HexRows = new List<List<HexViewModel1>>() {
                waterRows,
                new List<HexViewModel1>() {spacerHex, waterHex},
                new List<HexViewModel1>() {waterHex},
                new List<HexViewModel1>() {waterHex},
                new List<HexViewModel1>() {waterHex},
                new List<HexViewModel1>() {spacerHex, waterHex},
                waterRows
            };
            int i = 0;
            foreach (var hex in game.Board.Hexes) {
                var newHexValues = new HexViewModel1(hex, game);
                
                if (i >=0 && i <= 2)
                {
                    HexRows[1].Add(newHexValues);
                }
                else if (i >= 3 && i <= 6)
                {
                    HexRows[2].Add(newHexValues);
                }
                else if (i >= 7 && i <= 11)
                {
                    HexRows[3].Add(newHexValues);
                }
                else if (i >= 12 && i <= 15)
                {
                    HexRows[4].Add(newHexValues);
                }
                else if (i >= 16 && i <= 18)
                {
                    HexRows[5].Add(newHexValues);
                }
                i++;
            }
            for (int j = 1; j<6; j++)
            {
                HexRows[j].Add(waterHex);
            }
        }
    }
}
