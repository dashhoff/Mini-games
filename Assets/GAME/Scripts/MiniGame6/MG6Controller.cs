using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MG6Controller : MonoBehaviour
{
    [SerializeField] private int _countCorrect = 0;
    [SerializeField] private int _randomNumber;

    [SerializeField] private Transform _numberStartPos;
    [SerializeField] private Vector2 _randomPos;

    [SerializeField] private TMP_Text _randomNumberText;

    [SerializeField] private TMP_InputField _inputField;

    [SerializeField] private Image _shine;
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _wrongColor;

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        _inputField.onEndEdit.AddListener(Try);
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        NewNumber();
    }

    private void NewNumber()
    {
        _randomNumber = Random.Range(100000, 999999);
        _randomNumberText.text = _randomNumber.ToString();

        Vector2 newPos = new Vector2(
            _numberStartPos.localPosition.x + Random.Range(-_randomPos.x, _randomPos.x),
            _numberStartPos.localPosition.y + Random.Range(-_randomPos.y, _randomPos.y)
        );
        _randomNumberText.transform.localPosition = newPos;

        StartCoroutine(NewNumberCoroutine());
    }

    private IEnumerator NewNumberCoroutine()
    {
        _randomNumberText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _randomNumberText.gameObject.SetActive(false);
    }

    public void Try(string text)
    {
        int number = int.Parse(text);

        if (number == _randomNumber)
            Correct();
        else
            Wrong();
    }

    public void Pause()
    {
        MG6EventBus.InvokePause();
    }

    public void UnPause()
    {
        MG6EventBus.InvokeUnPause();
    }

    private void Correct()
    {
        _countCorrect++;

        if(_countCorrect == 5)
            Victory();

        DOTween.Sequence()
            .Append(_shine.DOColor(_correctColor, 0))
            .Append(_shine.DOFade(1, 0.2f))
            .Append(_shine.DOFade(0, 0.2f));

        _inputField.text = "";

        NewNumber();

        MG6EventBus.InvokeCorrect();
    }

    private void Wrong()
    {
        _inputField.text = "";

        DOTween.Sequence()
            .Append(_shine.DOColor(_wrongColor, 0))
            .Append(_shine.DOFade(1, 0.2f))
            .Append(_shine.DOFade(0, 0.2f));

        MG6EventBus.InvokeWrong();
    }

    private void Victory()
    {
        MG6EventBus.InvokeVictory();
    }
}
