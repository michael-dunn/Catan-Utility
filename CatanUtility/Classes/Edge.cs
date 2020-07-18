using System.Collections.Generic;

namespace CatanUtility.Classes
{
    public class Edge
    {
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public List<int> LinkedEdges { get; set; }
        public Edge()
        {
        }
        public override string ToString()
        {
            return (Color ?? "No") + " road";
        }
    }
}