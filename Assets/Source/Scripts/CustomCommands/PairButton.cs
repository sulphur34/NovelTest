using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.CustomCommands
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class PairButton : MonoBehaviour
    {
        [SerializeField] private Sprite _hideSprite;

        private PairButton _pair;
        private Button _button;
        private Sprite _openSprite;
        private Image _image;

        public event Action Opened;

        public bool IsOpen { get; private set; }
        public bool IsPaired { get; private set; }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (IsPaired)
                return;

            IsOpen = !IsOpen;

            if (IsOpen)
                Opened?.Invoke();

            _image.sprite = IsOpen ? _openSprite : _hideSprite;

            if (_pair.IsOpen)
            {
                IsPaired = true;
            }
        }
    }
}