using Naninovel;
using UnityEngine;

namespace Dialogs.CustomCommands
{
    [CommandAlias("addScore")]
    public class AddScore : Command
    {
        private readonly int _addAmount = 10;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            int currentScore = variableManager.VariableExists("playerScore") ?
                int.Parse(variableManager.GetVariableValue("playerScore")) : 0;
            currentScore += _addAmount;
            variableManager.SetVariableValue("playerScore", currentScore.ToString());
            PlayerPrefs.SetInt("playerScore", currentScore);
            return UniTask.CompletedTask;
        }
    }
}