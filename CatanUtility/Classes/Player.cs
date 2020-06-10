using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Card> Hand { get; set; }
        public int VictoryPoints { get; set; }

        public Player()
        {
            Hand = new List<Card>();
        }

        public void PrintHand()
        {
            var orderedHand = Hand.OrderBy(h => h.Type).ToList();
            Console.Write("{0}", orderedHand.FirstOrDefault()?.Type.ToString() ?? "No cards");
            for (int i = 1; i < orderedHand.Count(); i++)
                Console.Write(", {0}",orderedHand[i].Type);
            Console.WriteLine();
        }
    }
}