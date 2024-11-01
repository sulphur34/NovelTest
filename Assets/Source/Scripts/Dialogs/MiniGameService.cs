using Naninovel;
using UnityEditor;
using UnityEngine;

namespace Dialogs
{
    [InitializeAtRuntime]
    public class MiniGameService : IEngineService
    {
        private GameBuilder _gameBuilder;

        public UniTask InitializeServiceAsync()
        {
            _gameBuilder = Object.FindObjectOfType<GameBuilder>();
            return UniTask.CompletedTask;
        }

        public void StartGame()
        {
            _gameBuilder.BuildBoard();
        }

        public void ResetService()
        {
            _gameBuilder.ResetBoard();
        }

        public void DestroyService()
        {
            Object.Destroy(_gameBuilder);
        }
    }
}