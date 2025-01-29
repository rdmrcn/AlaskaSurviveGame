using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlaskaSurviveGame
{
    public class GameForm : Form
    {
        private UIComponents uiComponents;
        private GameState gameState;
        private NPC npc;
        public GameActions gameActions; // Erişim düzeyi public olarak ayarlandı

        public GameForm()
        {
            try
            {
                new MenuComponents(this); // Menü bileşenlerini başlat
                gameState = new GameState();
                uiComponents = new UIComponents(this, gameState);
                npc = new NPC(gameState, uiComponents);
                gameActions = new GameActions(gameState, uiComponents, npc);
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateUI()
        {
            uiComponents.UpdateUI();
        }
    }

    public class GameState
    {
        public int PlayerHealth { get; set; }
        public List<string> Inventory { get; private set; }
        public string CurrentLocation { get; set; }
        public bool HasMap { get; set; }
        public int NpcDialogueStep { get; set; }

        public GameState()
        {
            PlayerHealth = 100;
            Inventory = new List<string>();
            CurrentLocation = "wreckage";
            HasMap = false;
            NpcDialogueStep = 0;
        }
    }
}