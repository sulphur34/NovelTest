using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.MemoryGame;
using UnityEngine;
using UnityEngine.UI;

public class GameBuilder : MonoBehaviour, IGameBuilderInfo
{
    private readonly int _attemptsAddStep = 1;

    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private GameConfig _config;
    [SerializeField] private GridLayoutGroup _gameBoard;
    [SerializeField] private Image _lockScreen;

    private List<PairButton> _buttonsToPair;
    private int _pairCount;
    private PairButton _openButton;
    private Coroutine _coroutine;
    private int _attemptsLeft;

    public event Action<int> AttemptsChanged;
    public event Action Won;
    public event Action Lost;

    public void BuildBoard()
    {
        _gameCanvas.enabled = true;
        SetAttempts(_config.AttemptsNumber);
        BuildButtons();
        PlaceOnBoard();
    }

    public void ResetBoard()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if(_gameCanvas != null)
            _gameCanvas.enabled = false;

        SetAttempts(_config.AttemptsNumber);
        _pairCount = 0;

        if (_buttonsToPair == null)
            return;

        foreach (var pair in _buttonsToPair)
            Destroy(pair.gameObject);

        _buttonsToPair = null;
    }

    private void BuildButtons()
    {
        _buttonsToPair = new List<PairButton>();

        for (int i = 0; i < _config.PairsCount; i++)
        {
            var sprite = _config.OpenSprites[i];
            var firstPair = Instantiate(_config.PairButtonPrefab).GetComponent<PairButton>();
            var secondPair = Instantiate(_config.PairButtonPrefab).GetComponent<PairButton>();

            firstPair.Initialize(sprite, secondPair);
            secondPair.Initialize(sprite, firstPair);

            _buttonsToPair.Add(firstPair);
            _buttonsToPair.Add(secondPair);
        }
    }

    private void PlaceOnBoard()
    {
        _buttonsToPair.Shuffle();

        foreach (var pair in _buttonsToPair)
        {
            pair.transform.SetParent(_gameBoard.transform, false);
            pair.Opened += OnButtonPressed;
        }
    }

    private void OnButtonPressed(PairButton button)
    {
        if (_openButton == null)
        {
            _openButton = button;
            return;
        }

        if (button.IsPaired)
        {
            _openButton = null;
            _pairCount++;
            SetAttempts(_attemptsAddStep);

            if (_pairCount >= _config.PairsCount)
                Won?.Invoke();

            return;
        }

        SetAttempts(-_attemptsAddStep);

        if (_attemptsLeft <= 0)
            Lost?.Invoke();

        LockButtons(button);
    }

    private void LockButtons(PairButton button)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ShowRoutine(button));
    }

    private IEnumerator ShowRoutine(PairButton button)
    {
        _lockScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _openButton.Close();
        button.Close();
        _openButton = null;
        _lockScreen.gameObject.SetActive(false);
    }

    private void SetAttempts(int value)
    {
        _attemptsLeft += value;
        AttemptsChanged?.Invoke(_attemptsLeft);
    }
}