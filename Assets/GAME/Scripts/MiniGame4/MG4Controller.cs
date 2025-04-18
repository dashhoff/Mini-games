using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MG4Controller : MonoBehaviour
{
    [System.Serializable]
    public class Phrase
    {
        public string text;
        public string answer;
    }

    [SerializeField] private int _countCorrect;
    [SerializeField] private float _duration;
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _wrongColor;

    [SerializeField] private TMP_Text _mainText;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Image _shine;

    [SerializeField] private List<Phrase> _phrases;

    private int _currentIndex;
    private List<Phrase> _shuffled;

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        _countCorrect = 0;
        _currentIndex = 0;
        _inputField.text = "";
        _inputField.interactable = true;

        _shuffled = new List<Phrase>(_phrases);
        Shuffle(_shuffled);
        NewPhrase();
    }

    public void Pause()
    {
        MG4EventBus.InvokePause();
    }

    public void UnPause()
    {
        MG4EventBus.InvokeUnPause();
    }

    private void Shuffle(List<Phrase> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    public void Try()
    {
        string input = _inputField.text.Trim().ToLower();
        string correct = _shuffled[_currentIndex].answer.ToLower();

        if (input == correct)
        {
            Correct();
        }
        else
        {
            Wrong();
        }

        _inputField.text = "";
    }

    private void NewPhrase()
    {
        if (_currentIndex < _shuffled.Count)
        {
            _mainText.text = _shuffled[_currentIndex].text;
        }
        else
        {
            Victory();
        }
    }

    private void Correct()
    {
        _countCorrect++;

        DOTween.Sequence()
            .Append(_shine.DOColor(_correctColor, 0))
            .Append(_shine.DOFade(1, _duration))
            .Append(_shine.DOFade(0, _duration));

        _currentIndex++;
        NewPhrase();

        MG4EventBus.InvokeCorrect();
    }

    private void Wrong()
    {
        DOTween.Sequence()
            .Append(_shine.DOColor(_wrongColor, 0))
            .Append(_shine.DOFade(1, _duration))
            .Append(_shine.DOFade(0, _duration));

        MG4EventBus.InvokeWrong();
    }

    private void Victory()
    {
        MG4EventBus.InvokeVictory();
    }
}
