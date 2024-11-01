using Naninovel;

namespace Dialogs.CustomCommands
{
    [CommandAlias("startGame")]
    public class StartGame: Command
    {
        [field: ParameterAlias("gameWon")] public BooleanParameter GameWon { get; private set; }

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var miniGameService = Engine.GetService<MiniGameService>();
            miniGameService.StartGame();
            return UniTask.CompletedTask;
        }
    }
}