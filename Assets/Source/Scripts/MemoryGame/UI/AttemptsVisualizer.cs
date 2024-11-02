using TMPro;
using UnityEngine;

namespace MemoryGame.UI
{
    public class AttemptsVisualizer : MonoBehaviour
    {
        [SerializeField] private string _predicateText;
        [SerializeField] private GameBuilder _gameBuilder;
        [SerializeField] private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _gameBuilder.AttemptsChanged += OnAttemptsChange;
        }

        private void OnAttemptsChange(int attempts)
        {
            _textMesh.text = _predicateText + attempts;
        }
    }
}