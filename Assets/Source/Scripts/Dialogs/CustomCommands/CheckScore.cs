using Naninovel;

namespace Dialogs.CustomCommands
{
    [CommandAlias("checkScore")]
    public class CheckScore : Command
    {
        [field: ParameterAlias("result")] public BooleanParameter Result { get; private set; }

        private readonly int _threshold = 10;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            int currentScore = variableManager.VariableExists("playerScore") ?
                int.Parse(variableManager.GetVariableValue("playerScore")) : 0;

            Result = currentScore >= _threshold;

            return UniTask.CompletedTask;
        }
    }
}