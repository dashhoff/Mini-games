using System;
using DG.Tweening;
using UnityEngine;

public class DOPulse : MonoBehaviour
{
    [SerializeField] private bool _autoStart = false;
    [SerializeField] private bool _loop = false;
    [SerializeField] private bool _timeUnscaled = true;

    [SerializeField] private Transform _obj;

    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _endScale;

    [SerializeField] private float _delayToEndScale;
    [SerializeField] private float _timeToEndScale;
    [SerializeField] private float _delayToStartScale;
    [SerializeField] private float _timeToStartScale;

    [SerializeField] private Ease _ease;

    private Sequence _sequence;

    private void Start()
    {
        if (_obj == null)
            _obj = GetComponent<Transform>();

        if (_autoStart)
            Pulse();
    }

    private void Pulse(Action callback = null)
    {
        _sequence = DOTween.Sequence();

        int loops = _timeUnscaled ? -1 : 1;

        _sequence
            .SetEase(_ease)
            .SetUpdate(_timeUnscaled)
            .SetLoops(loops)
            .AppendInterval(_delayToEndScale)
            .Append(_obj.DOScale(_endScale, _timeToEndScale))
            .AppendInterval(_delayToStartScale)
            .Append(_obj.DOScale(_startScale, _timeToStartScale));
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}
