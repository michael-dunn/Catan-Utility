using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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

        public override string ToString()
        {
            return (Color ?? "No") + " road";
        }
    }

    public class ListEdgeComparer : IEqualityComparer<List<Edge>>
    {
        public bool Equals([AllowNull] List<Edge> x, [AllowNull] List<Edge> y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
            {
                return true;
            }
            if (ReferenceEquals(x, y)) return true;

            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode([DisallowNull] List<Edge> obj)
        {
            int num = 0;
            for (int i = 0; i<obj.Count; i++){
                num += obj[i] == null ? 0 : obj[i].Index.GetHashCode() * i.GetHashCode();
            }
            return num;
        }
    }
}