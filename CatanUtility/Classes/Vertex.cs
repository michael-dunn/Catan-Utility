using System.Collections.Generic;

namespace CatanUtility.Classes
{
    public class Vertex
    {
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public BuildType BuildingType { get; set; }
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