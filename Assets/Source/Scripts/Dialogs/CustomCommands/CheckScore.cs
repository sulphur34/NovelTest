using Naninovel;

namespace Dialogs.CustomCommands
{
    [CommandAlias(CommandNames.CheckScore)]
    public class CheckScore : Command
    {
        private readonly int _threshold = 10;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            bool result = int.Parse(variableManager.GetVariableValue(VariableNames.PlayerScore)) >= _threshold;
            variableManager.SetVariableValue(VariableNames.Result, result.ToString());
            return UniTask.CompletedTask;
        }
    }
}