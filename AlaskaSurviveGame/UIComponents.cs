using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlaskaSurviveGame
{
    public class UIComponents
    {
        private GameForm gameForm;
        private GameState gameState;

        public Label StoryLabel { get; private set; }
        public ListBox ChoicesListBox { get; private set; }
        public Button ActionButton { get; private set; }
        public Button TalkButton { get; private set; }
        public TextBox InventoryTextBox { get; private set; }
        public ProgressBar HealthBar { get; private set; }

        public UIComponents(GameForm gameForm, GameState gameState)
        {
            this.gameForm = gameForm;
            this.gameState = gameState;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form Settings
            gameForm.Text = "Alaska Survival Game";
            gameForm.Size = new Size(800, 600);
            gameForm.StartPosition = FormStartPosition.CenterScreen;
            gameForm.BackColor = Color.LightBlue;

            // Story Label
            StoryLabel = new Label()
            {
                Text = "Your plane has crashed in Alaska. You're at the wreckage. What do you do?",
                Location = new Point(20, 20),
                Size = new Size(740, 60),
                Font = new Font("Arial", 12),
                BackColor = Color.White,
                Padding = new Padding(10),
            };
            gameForm.Controls.Add(StoryLabel);

            // Choices ListBox
            ChoicesListBox = new ListBox()
            {
                Location = new Point(20, 100),
                Size = new Size(300, 200),
                Font = new Font("Arial", 10),
            };
            gameForm.Controls.Add(ChoicesListBox);

            // Action Button
            ActionButton = new Button()
            {
                Text = "Take Action",
                Location = new Point(20, 320),
                Size = new Size(100, 30),
            };
            ActionButton.Click += new EventHandler(OnActionButtonClick);
            gameForm.Controls.Add(ActionButton);

            // Talk Button
            TalkButton = new Button()
            {
                Text = "Talk to NPC",
                Location = new Point(130, 320),
                Size = new Size(100, 30),
            };
            TalkButton.Click += new EventHandler(OnTalkButtonClick);
            gameForm.Controls.Add(TalkButton);

            // Inventory TextBox
            InventoryTextBox = new TextBox()
            {
                Location = new Point(350, 100),
                Size = new Size(400, 200),
                Multiline = true,
                Font = new Font("Arial", 10),
                ReadOnly = true,
                Text = "Inventory: None",
            };
            gameForm.Controls.Add(InventoryTextBox);

            // Health Bar
            HealthBar = new ProgressBar()
            {
                Location = new Point(20, 380),
                Size = new Size(300, 30),
                Maximum = 100,
                Value = gameState.PlayerHealth,
            };
            gameForm.Controls.Add(HealthBar);
        }

        public void UpdateUI()
        {
            ChoicesListBox.Items.Clear();

            switch (gameState.CurrentLocation)
            {
                case "wreckage":
                    StoryLabel.Text = "You are at the wreckage of the plane. It's cold and snowing. What do you do?";
                    ChoicesListBox.Items.Add("Search the wreckage for supplies");
                    ChoicesListBox.Items.Add("Move to the forest");
                    break;

                case "forest":
                    StoryLabel.Text = "You are in a dense forest. It's eerily quiet. What do you do?";
                    ChoicesListBox.Items.Add("Look for wood to build a fire");
                    ChoicesListBox.Items.Add("Move to the cave");
                    break;

                case "cave":
                    StoryLabel.Text = "You are in a dark, cold cave. You hear strange noises. What do you do?";
                    ChoicesListBox.Items.Add("Rest and regain health");
                    ChoicesListBox.Items.Add("Move to the frozen lake");
                    break;

                case "frozen lake":
                    StoryLabel.Text = "You are at a frozen lake. The ice looks thin in some areas. What do you do?";
                    ChoicesListBox.Items.Add("Walk carefully across the lake");
                    ChoicesListBox.Items.Add("Move back to the wreckage");
                    ChoicesListBox.Items.Add("Move to Old Town");
                    break;

                case "old town":
                    StoryLabel.Text = "You have reached Old Town. It is abandoned, but there are signs of life. You see an NPC. What do you do?";
                    ChoicesListBox.Items.Add("Talk to the NPC");
                    ChoicesListBox.Items.Add("Search the town for supplies");
                    break;

                case "npc_conversation":
                    UpdateNPCConversationUI();
                    break;

                case "treasure_hunt":
                    StoryLabel.Text = "The NPC's map has led you to a hidden treasure chest! What do you do next?";
                    ChoicesListBox.Items.Add("Go to the North Way Road");
                    ChoicesListBox.Items.Add("Leave the chest and return to town");
                    break;

                case "north_war_road":
                    StoryLabel.Text = "You have reached the North Way Road. There's a treasure chest right in front of you!";
                    ChoicesListBox.Items.Add("Take the treasure");
                    ChoicesListBox.Items.Add("Leave the treasure and return to town");
                    break;
            }

            InventoryTextBox.Text = "Inventory: " + (gameState.Inventory.Count > 0 ? string.Join(", ", gameState.Inventory) : "None");
            HealthBar.Value = gameState.PlayerHealth;
        }

        private void UpdateNPCConversationUI()
        {
            switch (gameState.NpcDialogueStep)
            {
                case 0:
                    StoryLabel.Text = "The NPC says, 'Hello there, are you okay?'";
                    break;
                case 1:
                    StoryLabel.Text = "The NPC says, 'I am an old man, looking for myself.'";
                    break;
                case 2:
                    StoryLabel.Text = "The NPC says, 'This town has a long history...'";
                    break;
                case 3:
                    StoryLabel.Text = "The NPC says, 'Alright, here you go, take this map for good use.'";
                    break;
                default:
                    StoryLabel.Text = "You have finished talking with the NPC.";
                    break;
            }

            ChoicesListBox.Items.Clear();
            if (gameState.NpcDialogueStep < 4)
            {
                ChoicesListBox.Items.Add("Continue talking");
            }
            else
            {
                ChoicesListBox.Items.Add("Leave NPC");
            }
        }

        private void OnActionButtonClick(object sender, EventArgs e)
        {
            gameForm.gameActions.HandleAction();
        }

        private void OnTalkButtonClick(object sender, EventArgs e)
        {
            gameForm.gameActions.HandleTalk();
        }
    }
}