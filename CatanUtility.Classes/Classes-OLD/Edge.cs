﻿using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Classes.OLD
{
    public class Edge
    {
        public int Id { get; set; }
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public List<int> LinkedEdges { get; set; }
        public int Index { get; set; }
        public Edge() { }
        public Edge(int i)
        {
            Index = i;
        }

        public override string ToString()
        {
            return (!string.IsNullOrWhiteSpace(Color) ? Color : "No") + " road";
        }
    }

    public class ListEdgeComparer : IEqualityComparer<List<Edge>>
    {
        public bool Equals(List<Edge> x, List<Edge> y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
            {
                return true;
            } else if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            else if (ReferenceEquals(x, y)) return true;

            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode(List<Edge> edges)
        {
            int num = 0;
            var orderedEdges = edges.OrderBy(e => e.Index).Select(e=>e.Index).ToList();
            for (int i = 0; i < orderedEdges.Count; i++){
                num += orderedEdges[i] * i;
            }
            return num;
        }
    }
}