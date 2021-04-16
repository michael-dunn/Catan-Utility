using CatanUtility.Models.Enums;
using System.Collections.Generic;

namespace CatanUtility.Models
{
    public class Vertex
    {
        public int Id { get; set; }
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public BuildType BuildingType { get; set; }

        public Vertex() { }

        public override string ToString()
        {
            return Occupied ? Color + " " + BuildingType.ToString() : "Unoccupied";
        }
    }
}