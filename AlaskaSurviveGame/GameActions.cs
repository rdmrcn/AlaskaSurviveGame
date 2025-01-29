using System;
using System.Windows.Forms;

namespace AlaskaSurviveGame
{
    public class GameActions
    {
        private GameState gameState;
        private UIComponents uiComponents;
        private NPC npc;

        public GameActions(GameState gameState, UIComponents uiComponents, NPC npc)
        {
            this.gameState = gameState;
            this.uiComponents = uiComponents;
            this.npc = npc;
        }

        public void HandleAction()
        {
            if (uiComponents.ChoicesListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an action.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string choice = uiComponents.ChoicesListBox.SelectedItem.ToString();

            switch (gameState.CurrentLocation)
            {
                case "wreckage":
                    HandleWreckageAction(choice);
                    break;
                case "forest":
                    HandleForestAction(choice);
                    break;
                case "cave":
                    HandleCaveAction(choice);
                    break;
                case "frozen lake":
                    HandleFrozenLakeAction(choice);
                    break;
                case "old town":
                    HandleOldTownAction(choice);
                    break;
                case "npc_conversation":
                    HandleNPCConversationAction(choice);
                    break;
                case "treasure_hunt":
                    HandleTreasureHuntAction(choice);
                    break;
                case "north_war_road":
                    HandleNorthWarRoadAction(choice);
                    break;
            }

            if (gameState.PlayerHealth <= 0)
            {
                MessageBox.Show("You have perished in the wilderness.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            uiComponents.UpdateUI();
        }

        private void HandleWreckageAction(string choice)
        {
            if (choice == "Search the wreckage for supplies")
            {
                gameState.Inventory.Add("First Aid Kit");
                MessageBox.Show("You found a First Aid Kit!");
            }
            else if (choice == "Move to the forest")
            {
                gameState.CurrentLocation = "forest";
            }
        }

        private void HandleForestAction(string choice)
        {
            if (choice == "Look for wood to build a fire")
            {
                gameState.Inventory.Add("Wood");
                MessageBox.Show("You collected wood for a fire.");
            }
            else if (choice == "Move to the cave")
            {
                gameState.CurrentLocation = "cave";
            }
        }

        private void HandleCaveAction(string choice)
        {
            if (choice == "Rest and regain health")
            {
                gameState.PlayerHealth = Math.Min(100, gameState.PlayerHealth + 20);
                MessageBox.Show("You rested and regained some health.");
            }
            else if (choice == "Move to the frozen lake")
            {
                gameState.CurrentLocation = "frozen lake";
            }
        }

        private void HandleFrozenLakeAction(string choice)
        {
            if (choice == "Walk carefully across the lake")
            {
                Random rand = new Random();
                if (rand.Next(2) == 0)
                {
                    gameState.PlayerHealth -= 30;
                    MessageBox.Show("The ice cracked! You lost some health.");
                }
                else
                {
                    MessageBox.Show("You crossed the lake safely.");
                }
            }
            else if (choice == "Move back to the wreckage")
            {
                gameState.CurrentLocation = "wreckage";
            }
            else if (choice == "Move to Old Town")
            {
                gameState.CurrentLocation = "old town";
            }
        }

        private void HandleOldTownAction(string choice)
        {
            if (choice == "Talk to the NPC")
            {
                gameState.CurrentLocation = "npc_conversation";
            }
            else if (choice == "Search the town for supplies")
            {
                gameState.Inventory.Add("Rations");
                MessageBox.Show("You found some rations in the town.");
            }
        }

        private void HandleNPCConversationAction(string choice)
        {
            if (choice == "Leave NPC")
            {
                if (!gameState.HasMap)
                {
                    gameState.HasMap = true;
                    gameState.Inventory.Add("Map");
                    MessageBox.Show("The NPC gives you a map. You can now search for the treasure.");
                }
                gameState.CurrentLocation = "treasure_hunt";
            }
            else
            {
                npc.HandleConversation();
            }
        }

        private void HandleTreasureHuntAction(string choice)
        {
            if (choice == "Go to the North Way Road")
            {
                gameState.CurrentLocation = "north_war_road";
            }
            else if (choice == "Leave the chest and return to town")
            {
                gameState.CurrentLocation = "old town";
            }
        }

        private void HandleNorthWarRoadAction(string choice)
        {
            if (choice == "Take the treasure")
            {
                gameState.Inventory.Add("Treasure");
                MessageBox.Show("Congratulations! You found the treasure!");
                MessageBox.Show("You completed the game! Congratulations!");
                Application.Exit();
            }
            else if (choice == "Leave the treasure and return to town")
            {
                gameState.CurrentLocation = "old town";
            }
        }

        public void HandleTalk()
        {
            npc.HandleConversation();
        }
    }
}