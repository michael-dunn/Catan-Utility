using CatanUtility.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatanUtility.Classes.OLD
{
    public class Vertex
    {
        public int Id { get; set; }
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public BuildType BuildingType { get; set; }
        [NotMapped]
        public List<int> LinkedVertices { get; set; }
        public int Index { get; set; }

        public Vertex()
        {
            BuildingType = BuildType.None;
        }
        public Vertex(int i)
        {
            Index = i;
        }

        public override string ToString()
        {

            return Occupied ? Color + " " + BuildingType.ToString() : "Unoccupied";
        }
    }
}