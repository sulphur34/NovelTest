using System;

namespace Source.Scripts.MemoryGame
{
    public class WinPanel : GameEndPanel
    {
        protected override void Initialize()
        {
            GameBuilderInfo.Won += ShowPanel;
        }

        private void OnDestroy()
        {
            GameBuilderInfo.Won -= ShowPanel;
        }
    }
}