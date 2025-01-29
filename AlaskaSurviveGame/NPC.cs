namespace AlaskaSurviveGame
{
    public class NPC
    {
        private GameState gameState;
        private UIComponents uiComponents;

        public NPC(GameState gameState, UIComponents uiComponents)
        {
            this.gameState = gameState;
            this.uiComponents = uiComponents;
        }

        public void HandleConversation()
        {
            if (gameState.NpcDialogueStep < 4)
            {
                gameState.NpcDialogueStep++;
            }
            uiComponents.UpdateUI();
        }
    }
}