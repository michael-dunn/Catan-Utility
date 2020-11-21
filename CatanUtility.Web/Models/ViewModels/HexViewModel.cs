using CatanUtility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanUtility.Web.Models.ViewModels
{
    public class HexViewModel
    {
        public List<EdgeViewModel> Edges { get; set; }
        public List<VertexViewModel> Vertices { get; set; }
        public string Value { get; set; }
        public string ResourceType { get; set; }

        public HexViewModel()
        {
            Edges = new List<EdgeViewModel>();
            Vertices = new List<VertexViewModel>();
        }
        public HexViewModel(int number, string type)
        {
            Edges = new List<EdgeViewModel>();
            Vertices = new List<VertexViewModel>();
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

    public class EdgeViewModel
    {
        public string Color { get; set; }
        public string Position { get; set; }
        public string EdgeClass { get; set; }

        public EdgeViewModel() { }
        public EdgeViewModel(Edge _edge, int edgePosition)
        {
            Position = GetEdgePosition(edgePosition);
            Color = _edge.Color.ToLower();
            EdgeClass = "road " + Color + " " + Position;
        }
        private string GetEdgePosition(int position)
        {
            if (position == 0)
                return "tl";
            if (position == 1)
                return "tr";
            if (position == 2)
                return "r";
            if (position == 3)
                return "br";
            if (position == 4)
                return "bl";
            if (position == 5)
                return "l";
            return "";
        }
    }

    public class VertexViewModel
    {
        public string Color { get; set; }
        public string Position { get; set; }
        public string BuildingType { get; set; }
        public string VertexClass { get; set; }

        public VertexViewModel() { }
        public VertexViewModel(Vertex _vertex, int vertexPosition)
        {
            Position = GetVertexPosition(vertexPosition);
            Color = _vertex.Color.ToLower();
            BuildingType = _vertex.BuildingType.ToString().ToLower();
            VertexClass = BuildingType + " " + Color + " " + Position;
        }
        private string GetVertexPosition(int position)
        {
            if (position == 0)
                return "t";
            if (position == 1)
                return "tr";
            if (position == 2)
                return "br";
            if (position == 3)
                return "b";
            if (position == 4)
                return "bl";
            if (position == 5)
                return "tl";
            return "";
        }
    }
}
