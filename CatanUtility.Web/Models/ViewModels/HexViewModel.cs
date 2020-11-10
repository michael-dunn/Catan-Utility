using CatanUtility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanUtility.Web.Models.ViewModels
{
    public class HexViewModel
    {
        public List<Edge> Edges { get; set; }
        public List<Vertex> Vertices { get; set; }
        public string Value { get; set; }
        public string ResourceType { get; set; }

        public HexViewModel()
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
        }
        public HexViewModel(int number, string type)
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
            ResourceType = type;
            switch (number)
            {
                case 2:
                    Value = "two";
                    break;
                case 3:
                    Value = "three";
                    break;
                case 4:
                    Value = "four";
                    break;
                case 5:
                    Value = "five";
                    break;
                case 6:
                    Value = "six";
                    break;
                case 8:
                    Value = "eight";
                    break;
                case 9:
                    Value = "nine";
                    break;
                case 10:
                    Value = "ten";
                    break;
                case 11:
                    Value = "eleven";
                    break;
                case 12:
                    Value = "twelve";
                    break;
            }
        }
    }
}
