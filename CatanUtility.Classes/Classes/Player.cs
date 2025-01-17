﻿using System;
using System.Collections.Generic;
using System.Linq;
using CatanUtility.Classes.Enums;

namespace CatanUtility.Classes
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
            Hand = new List<Card>();
        }
    }
}