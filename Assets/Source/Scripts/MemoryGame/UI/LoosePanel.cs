namespace Source.Scripts.MemoryGame
{
    public class LoosePanel : GameEndPanel
    {
        protected override void Initialize(IGameBuilderInfo gameBuilder)
        {
            gameBuilder.Lost += ShowPanel;
        }
    }
}