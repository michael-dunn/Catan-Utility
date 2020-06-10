using System;

namespace CatanUtility.Classes
{
    public class BoardHex
    {
        public CatanResourceType Resource { get; set; }
        public int Number { get; set; }
        public bool Robber { get; set; }

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
