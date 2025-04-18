using System.Collections;
using TMPro;
using UnityEngine;

public class MG5Timer : MonoBehaviour
{
    [SerializeField] private bool _timerActive;

    [SerializeField] private int _startTime;
    [SerializeField] private int _time;
    [SerializeField] private TMP_Text _timerText;

    private void OnEnable()
    {
        MG5EventBus.OnStartGame += () => { _timerActive = true; };

        MG5EventBus.OnPause += () => { _timerActive = false; };
        MG5EventBus.OnUnPause += () => { _timerActive = true; };

        MG5EventBus.OnVictory += () => { _timerActive = false; };
        MG5EventBus.OnDefeat += () => { _timerActive = false; };
    }   

    private void OnDisable()
    {
        MG5EventBus.OnStartGame -= () => { _timerActive = true; };

        MG5EventBus.OnPause -= () => { _timerActive = false; };
        MG5EventBus.OnUnPause -= () => { _timerActive = true; };

        MG5EventBus.OnVictory -= () => { _timerActive = false; };
        MG5EventBus.OnDefeat -= () => { _timerActive = false; };
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
                    MG5EventBus.InvokeDefeat();
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
