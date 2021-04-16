using CatanUtility.Models.Enums;
using System.Collections.Generic;

namespace CatanUtility.Classes.OLD
{
    public class BoardHex
    {
        public int Id { get; set; }
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


}
