using System.Collections;
using TMPro;
using UnityEngine;

public class MG4Timer : MonoBehaviour
{
    [SerializeField] private bool _timerActive;

    [SerializeField] private int _startTime;
    [SerializeField] private int _time;
    [SerializeField] private TMP_Text _timerText;

    private void OnEnable()
    {
        MG4EventBus.OnPause += () => { _timerActive = false; };
        MG4EventBus.OnUnPause += () => { _timerActive = true; };

        MG4EventBus.OnVictory += () => { _timerActive = false; };
        MG4EventBus.OnDefeat += () => { _timerActive = false; };
    }

    private void OnDisable()
    {
        MG4EventBus.OnPause -= () => { _timerActive = false; };
        MG4EventBus.OnUnPause -= () => { _timerActive = true; };

        MG4EventBus.OnVictory -= () => { _timerActive = false; };
        MG4EventBus.OnDefeat -= () => { _timerActive = false; };
    }

    public void Start()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Init()
    {
        _time = _startTime;

        StartCoroutine(TimerCoroutine());
    }

    /// <summary>
    /// Таймер
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            if (_timerActive)
            {
                if (_time <= 0)
                {
                    MG4EventBus.InvokeDefeat();
                    yield break;
                }

                yield return new WaitForSecondsRealtime(1);

                _time--;

                int minutes = _time / 60;
                int seconds = _time % 60;

                _timerText.text = minutes + ":" + seconds;
            }
            else yield return null;
        }
    }
}
