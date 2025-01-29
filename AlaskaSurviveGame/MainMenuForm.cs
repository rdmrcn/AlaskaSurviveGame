using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlaskaSurviveGame
{
    public class MainMenuForm : Form
    {
        private Button newGameButton;
        private Button loadGameButton;
        private Button creditsButton;
        private Button exitButton;
        private Label titleLabel;

        public MainMenuForm()
        {
            InitializeComponents();
            new MenuComponents(this); // Menü bileşenlerini başlat
        }

        private void InitializeComponents()
        {
            // Form Settings
            this.Text = "Main Menu";
            this.Size = new Size(1200, 900); // Pencere boyutunu 3 katına çıkar
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(43, 43, 43); // Gri-siyah arka plan (Darcula teması)

            // Title Label
            titleLabel = new Label()
            {
                Text = "ALASKA SURVIVOR",
                Font = new Font("Arial", 32, FontStyle.Bold), // Yazı fontunu 2 katına büyüt
                ForeColor = Color.FromArgb(0, 120, 215), // Açık mavi renk (düğme yazılarından biraz daha koyu)
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(titleLabel);

            // New Game Button
            newGameButton = new Button()
            {
                Text = "New Game",
                Size = new Size(300, 80), // Tuş boyutunu büyüt
                BackColor = Color.LightBlue, // Tuş rengini açık mavi yap
                Font = new Font("Arial", 16, FontStyle.Bold) // Yazı fontunu 2 katına büyüt
            };
            newGameButton.Click += new EventHandler(OnNewGameClick);
            this.Controls.Add(newGameButton);

            // Load Game Button
            loadGameButton = new Button()
            {
                Text = "Load Game",
                Size = new Size(300, 80), // Tuş boyutunu büyüt
                BackColor = Color.LightBlue, // Tuş rengini açık mavi yap
                Font = new Font("Arial", 16, FontStyle.Bold) // Yazı fontunu 2 katına büyüt
            };
            loadGameButton.Click += new EventHandler(OnLoadGameClick);
            this.Controls.Add(loadGameButton);

            // Credits Button
            creditsButton = new Button()
            {
                Text = "Credits",
                Size = new Size(300, 80), // Tuş boyutunu büyüt
                BackColor = Color.LightBlue, // Tuş rengini açık mavi yap
                Font = new Font("Arial", 16, FontStyle.Bold) // Yazı fontunu 2 katına büyüt
            };
            creditsButton.Click += new EventHandler(OnCreditsClick);
            this.Controls.Add(creditsButton);

            // Exit Game Button
            exitButton = new Button()
            {
                Text = "Exit Game",
                Size = new Size(300, 80), // Tuş boyutunu büyüt
                BackColor = Color.LightBlue, // Tuş rengini açık mavi yap
                Font = new Font("Arial", 16, FontStyle.Bold) // Yazı fontunu 2 katına büyüt
            };
            exitButton.Click += new EventHandler(OnExitGameClick);
            this.Controls.Add(exitButton);

            // Center the title and buttons
            this.Load += new EventHandler(CenterComponents);
        }

        private void CenterComponents(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            titleLabel.Location = new Point((formWidth - titleLabel.Width) / 2, formHeight / 4 - titleLabel.Height);
            newGameButton.Location = new Point((formWidth - newGameButton.Width) / 2, (formHeight - newGameButton.Height) / 2 - 150);
            loadGameButton.Location = new Point((formWidth - loadGameButton.Width) / 2, (formHeight - loadGameButton.Height) / 2 - 50);
            creditsButton.Location = new Point((formWidth - creditsButton.Width) / 2, (formHeight - creditsButton.Height) / 2 + 50);
            exitButton.Location = new Point((formWidth - exitButton.Width) / 2, (formHeight - exitButton.Height) / 2 + 150);
        }

        private void OnNewGameClick(object sender, EventArgs e)
        {
            // Start a new game
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void OnLoadGameClick(object sender, EventArgs e)
        {
            // Show load game message
            MessageBox.Show("You don't have any saved progress", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnCreditsClick(object sender, EventArgs e)
        {
            // Show credits
            MessageBox.Show("Game Developer: Reha Demircan\nMade in: 18.01.2025\nIntermediate Level C# Project\nVisual Studio 2022\n.NET 9.0 used", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnExitGameClick(object sender, EventArgs e)
        {
            // Exit the game
            Application.Exit();
        }
    }
}