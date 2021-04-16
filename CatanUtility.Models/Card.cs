using System;
using CatanUtility.Models.Enums;

namespace CatanUtility.Models
{
    public class Card
    {
        public int Id { get; set; }
        public CatanResourceType Type { get; set; }
        public Card()
        {
        }
    }
}
