using System.Collections.Generic;

namespace AlaskaSurviveGame
{
    public class Player
    {
        public int Health { get; set; }
        public List<string> Inventory { get; private set; }

        public Player()
        {
            Health = 100;
            Inventory = new List<string>();
        }

        public void AddToInventory(string item)
        {
            Inventory.Add(item);
        }

        public void RemoveFromInventory(string item)
        {
            Inventory.Remove(item);
        }
    }
}