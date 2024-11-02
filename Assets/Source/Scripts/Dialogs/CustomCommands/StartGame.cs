using Dialogs.CustomServices;
using Naninovel;

namespace Dialogs.CustomCommands
{
    [CommandAlias(CommandNames.StartGame)]
    public class StartGame : Command
    {
        private UniTaskCompletionSource _taskCompletionSource;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            _taskCompletionSource = new UniTaskCompletionSource();
            var miniGameService = Engine.GetService<MiniGameService>();
            miniGameService.StartGame();
            miniGameService.Lost += OnLoose;
            miniGameService.Won += OnWin;
            await _taskCompletionSource.Task;
        }

        private void OnLoose()
        {
            OnGameEnd(false);
        }

        private void OnWin()
        {
            OnGameEnd(true);
        }

        private void OnGameEnd(bool isWon)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            variableManager.SetVariableValue(VariableNames.IsGameWon, isWon.ToString());
            _taskCompletionSource.TrySetResult();
        }
    }
}