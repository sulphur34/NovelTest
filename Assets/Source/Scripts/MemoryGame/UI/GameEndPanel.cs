using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Scripts.MemoryGame
{
    public abstract class GameEndPanel : MonoBehaviour
    {
        [SerializeField] private GameBuilder _gameBuilder;
        [SerializeField] private Image _gameEndPanel;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Button _button;

        protected IGameBuilderInfo GameBuilderInfo => _gameBuilder;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
            Initialize();
        }

        private void OnButtonClick()
        {
            SceneManager.LoadScene("MainScene");
        }

        protected abstract void Initialize();

        protected void ShowPanel()
        {
            _gameEndPanel.enabled = true;
            _label.gameObject.SetActive(true);
            _button.gameObject.SetActive(true);
        }
    }
}