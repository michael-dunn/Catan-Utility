using System.Collections.Generic;
using CatanUtility.Models.Enums;

namespace CatanUtility.Models
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
        public override string ToString()
        {
            return Resource.ToString() + "," + Number;
        }
        
    }


}
