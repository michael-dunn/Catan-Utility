using System.Collections.Generic;

namespace CatanUtility.Models
{
    public class Edge
    {
        public int Id { get; set; }
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public Edge() { }

        public override string ToString()
        {
            return (!string.IsNullOrWhiteSpace(Color) ? Color : "No") + " road";
        }
    }
}
