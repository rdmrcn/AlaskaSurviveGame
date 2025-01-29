using System;
using System.Windows.Forms;

namespace AlaskaSurviveGame
{
    public class MenuComponents
    {
        private Form parentForm;

        public MenuComponents(Form form)
        {
            parentForm = form;
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            // Create a menu strip
            MenuStrip menuStrip = new MenuStrip();

            // Create the main menu items
            ToolStripMenuItem gameMenuItem = new ToolStripMenuItem("Game");
            ToolStripMenuItem newGameMenuItem = new ToolStripMenuItem("New Game");
            ToolStripMenuItem creditsMenuItem = new ToolStripMenuItem("Credits");

            // Add event handlers for menu items
            newGameMenuItem.Click += new EventHandler(OnNewGameClick);
            creditsMenuItem.Click += new EventHandler(OnCreditsClick);

            // Add the menu items to the game menu
            gameMenuItem.DropDownItems.Add(newGameMenuItem);
            gameMenuItem.DropDownItems.Add(creditsMenuItem);

            // Add the game menu to the menu strip
            menuStrip.Items.Add(gameMenuItem);

            // Add the menu strip to the parent form
            parentForm.MainMenuStrip = menuStrip;
            parentForm.Controls.Add(menuStrip);
        }

        private void OnNewGameClick(object sender, EventArgs e)
        {
            // Start a new game
            if (parentForm is MainMenuForm mainMenuForm)
            {
                mainMenuForm.Hide();
                GameForm gameForm = new GameForm();
                gameForm.FormClosed += (s, args) => mainMenuForm.Close();
                gameForm.Show();
            }
        }

        private void OnCreditsClick(object sender, EventArgs e)
        {
            // Show credits
            MessageBox.Show("Game Developer: Reha Demircan", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}