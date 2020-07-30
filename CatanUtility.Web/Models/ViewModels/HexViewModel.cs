using CatanUtility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanUtility.Web.Models.ViewModels
{
    public class HexViewModel
    {
        public HexViewModel()
        {
            VertexColor = new List<string>();
            VertexType = new List<string>();
            VertexPosition = new List<string>();
            EdgeColor = new List<string>();
            EdgePosition = new List<string>();
        }
        public HexViewModel(BoardHex hex, Game game)
        {
            var value = "number ";
            switch (hex.Number)
            {
                case 2:
                    value = value + "two";
                    break;
                case 3:
                    value = value + "three";
                    break;
                case 4:
                    value = value + "four";
                    break;
                case 5:
                    value = value + "five";
                    break;
                case 6:
                    value = value + "six";
                    break;
                case 8:
                    value = value + "eight";
                    break;
                case 9:
                    value = value + "nine";
                    break;
                case 10:
                    value = value + "ten";
                    break;
                case 11:
                    value = value + "eleven";
                    break;
                case 12:
                    value = value + "twelve";
                    break;
            }
            if (hex.Robber)
            {
                value = value + " robber";
            }

            HexResource = hex.Resource.ToString();
            HexValue = value;
            EdgePosition = new List<string>() { "tl", "tr", "r", "br", "bl", "l" };
            EdgeColor = hex.EdgeIndices.Select(e => string.IsNullOrWhiteSpace(game.Board.Edges[e].Color) ? "target" : game.Board.Edges[e].Color).ToList();
        }
        public string HexResource { get; set; }
        public string HexValue { get; set; }
        public List<string> VertexColor { get; set; }
        public List<string> VertexType { get; set; }
        public List<string> VertexPosition { get; set; }
        public List<string> EdgeColor { get; set; }
        public List<string> EdgePosition { get; set; }
    }
}
