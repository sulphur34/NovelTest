namespace MemoryGame.UI
{
    public class LoosePanel : GameEndPanel
    {
        protected override void Initialize()
        {
            GameBuilderInfo.Lost += ShowPanel;
        }

        private void OnDestroy()
        {
            GameBuilderInfo.Lost -= ShowPanel;
        }
    }
}