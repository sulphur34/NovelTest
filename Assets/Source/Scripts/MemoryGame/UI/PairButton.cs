using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.MemoryGame
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class PairButton : MonoBehaviour
    {
        [SerializeField] private Sprite _hideSprite;

        private PairButton _pair;
        private Button _button;
        private Sprite _openSprite;
        private Image _image;

        public event Action<PairButton> Opened;

        public bool IsOpen { get; private set; }
        public bool IsPaired { get; private set; }

        private void OnDestroy()
        {

            _button.onClick.RemoveListener(OnButtonClick);
            _pair.Opened -= OnPairOpen;
        }

        public void Initialize(Sprite openSprite, PairButton pair)
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(OnButtonClick);
            _openSprite = openSprite;
            _pair = pair;
            _pair.Opened += OnPairOpen;
        }

        public void Close()
        {
            _image.sprite = _hideSprite;
            IsOpen = false;
        }

        private void OnPairOpen(PairButton pair)
        {
            if (IsOpen)
                IsPaired = true;
        }

        private void OnButtonClick()
        {
            if (IsOpen || IsPaired)
                return;

            IsOpen = true;

            _image.sprite = IsOpen ? _openSprite : _hideSprite;

            if (_pair.IsOpen)
                IsPaired = true;

            Opened?.Invoke(this);
        }
    }
}