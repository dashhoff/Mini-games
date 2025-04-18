using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MG3Obj : MonoBehaviour
{
    public int Id;
    public string Name;

    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _wrongColor;

    [SerializeField] private Image _shine;
    [SerializeField] private float _shineDuration;

    public void Select()
    {
        DOTween.Sequence()
            .Append(_shine.DOColor(_selectedColor, 0))
            .Append(_shine.DOFade(1, _shineDuration));
    }

    public void Deselect()
    {
        DOTween.Sequence()
            .Append(_shine.DOFade(0, _shineDuration));
    }

    public void Wrong()
    {
        DOTween.Sequence()
            .Append(_shine.DOColor(_wrongColor, 0))
            .Append(_shine.DOFade(1, _shineDuration))
            .Append(_shine.DOFade(0, _shineDuration));
    }
}
