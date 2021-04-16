﻿using System.Collections.Generic;

namespace CatanUtility.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Card> Hand { get; set; }
        public int VictoryPoints { get; set; }

        public Player()
        {
        }
    }
}