using System.Collections.Generic;

namespace CatanUtility.Classes
{
    public class Edge
    {
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public List<int> LinkedEdges { get; set; }
        public int Index { get; set; }
        public Edge()
        {
        }
        public Edge(int i)
        {
            Index = i;
        }
        //CAN'T FIGURE OUT HOW TO OVERRIDE THE DEFAULT COMPARER
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Edge e = (Edge)obj;
                return Index == e.Index;
            }
        }

        public override int GetHashCode()
        {
            return Index;
        }

        public override string ToString()
        {
            return (Color ?? "No") + " road";
        }
    }
}