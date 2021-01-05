using System;
using CatanUtility.Classes.Enums;

namespace CatanUtility.Classes
{
    public class Harbor
    {
        public int Id { get; set; }
        public Edge Position { get; set; }
        public HarborType Type { get; set; }

        public Harbor() { }
        public Harbor(Edge edge, HarborType type)
        {
            Position = edge;
            Type = type;
        }
    }
}
