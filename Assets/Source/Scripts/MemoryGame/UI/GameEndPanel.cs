using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.MemoryGame
{
    public abstract class GameEndPanel : MonoBehaviour
    {
        [SerializeField] private GameBuilder _gameBuilder;
        [SerializeField] private Image _gameEndPanel;

        private void Awake()
        {
            Initialize(_gameBuilder);
        }

        protected abstract void Initialize(IGameBuilderInfo gameBuilder);

        protected void ShowPanel()
        {
            _gameEndPanel.enabled = true;
        }
    }
}