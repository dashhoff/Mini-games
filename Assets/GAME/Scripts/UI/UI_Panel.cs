using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Panel : MonoBehaviour
{
    [SerializeField] private Image _backgroud;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private float _openDuration;
    [SerializeField] private float _closeDuration;

    public void Open()
    {
        _backgroud.gameObject.SetActive(true);  

        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_canvasGroup.DOFade(1, _openDuration));
    }

    public void Close()
    {
        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_canvasGroup.DOFade(0, _closeDuration)).OnComplete(() =>
            {
                _backgroud.gameObject.SetActive(false);
                gameObject.SetActive(false);
            });
    }
}