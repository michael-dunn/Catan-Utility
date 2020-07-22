using System;
using System.Collections.Generic;

namespace CatanUtility.Classes
{
    public class BoardHex
    {
        public CatanResourceType Resource { get; set; }
        public int Number { get; set; }
        public bool Robber { get; set; }
        public List<int> EdgeIndices {get;set;}
        public List<int> VertexIndices { get; set; }

        public BoardHex()
        {
        }
        public BoardHex(CatanResourceType _resource, int _number, bool _robber)
        {
            Resource = _resource;
            Number = _number;
            Robber = _robber;
        }
        public override string ToString()
        {
            return Resource.ToString() + "," + Number;
        }
        
    }

    public enum CatanResourceType
    {
        Wheat = 'H',
        Ore = 'O',
        Brick = 'B',
        Wood = 'W',
        Sheep = 'S',
        Desert = 'D'
    };

}
