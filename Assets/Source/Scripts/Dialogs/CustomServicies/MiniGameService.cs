using System;
using Naninovel;
using Object = UnityEngine.Object;

namespace Dialogs
{
    [InitializeAtRuntime]
    public class MiniGameService : IEngineService
    {
        private GameBuilder _gameBuilder;

        public event Action Won;
        public event Action Lost;

        public UniTask InitializeServiceAsync()
        {
            _gameBuilder = Object.FindObjectOfType<GameBuilder>();
            return UniTask.CompletedTask;
        }

        public void StartGame()
        {
            _gameBuilder.Won += OnWin;
            _gameBuilder.Lost += OnLost;
            _gameBuilder.BuildBoard();
        }

        private void OnWin()
        {
            _gameBuilder.ResetBoard();
            Won?.Invoke();
        }

        private void OnLost()
        {
            _gameBuilder.ResetBoard();
            Lost?.Invoke();
        }

        public void ResetService()
        {
            _gameBuilder.Won -= OnWin;
            _gameBuilder.Lost -= OnLost;
            _gameBuilder.ResetBoard();
        }

        public void DestroyService()
        {
            ResetService();
            Object.Destroy(_gameBuilder);
        }
    }
}