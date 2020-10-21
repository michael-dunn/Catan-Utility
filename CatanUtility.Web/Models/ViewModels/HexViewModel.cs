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

        public HexViewModel()
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
        }
    }
}
