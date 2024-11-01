namespace Source.Scripts.MemoryGame
{
    public class WinPanel : GameEndPanel
    {
        protected override void Initialize(IGameBuilderInfo gameBuilder)
        {
            gameBuilder.Won += ShowPanel;
        }
    }
}