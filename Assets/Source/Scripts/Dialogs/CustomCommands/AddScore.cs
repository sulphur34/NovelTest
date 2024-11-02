using Naninovel;

namespace Dialogs.CustomCommands
{
    [CommandAlias(CommandNames.AddScore)]
    public class AddScore : Command
    {
        private readonly int _addAmount = 10;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            var currentScore = variableManager.VariableExists(VariableNames.PlayerScore) ?
                int.Parse(variableManager.GetVariableValue(VariableNames.PlayerScore)) : 0;
            currentScore += _addAmount;
            variableManager.SetVariableValue(VariableNames.PlayerScore, currentScore.ToString());
            return UniTask.CompletedTask;
        }
    }
}