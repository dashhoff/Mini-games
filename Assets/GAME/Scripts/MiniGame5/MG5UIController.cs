using UnityEngine;

public class MG5UIController : MonoBehaviour
{
    [SerializeField] private UI_Panel _mainPanel;
    [SerializeField] private UI_Panel _pausePanel;
    [SerializeField] private UI_Panel _victoryPanel;
    [SerializeField] private UI_Panel _defeatPanel;

    private void OnEnable()
    {
        MG5EventBus.OnPause += Pause;
        MG5EventBus.OnUnPause += UnPause;

        MG5EventBus.OnVictory += Victory;
        MG5EventBus.OnDefeat += Defeat;
    }

    private void OnDisable()
    {
        MG5EventBus.OnPause -= Pause;
        MG5EventBus.OnUnPause -= UnPause;

        MG5EventBus.OnVictory -= Victory;
        MG5EventBus.OnDefeat -= Defeat;
    }

    private void Pause()
    {
        _pausePanel.gameObject.SetActive(true);

        _pausePanel.Open();
        _mainPanel.Close();
    }

    private void UnPause()
    {
        _mainPanel.gameObject.SetActive(true);

        _mainPanel.Open();
        _pausePanel.Close();
    }

    private void Victory()
    {
        _victoryPanel.gameObject.SetActive(true);

        _victoryPanel.Open();
        _mainPanel.Close();
    }

    private void Defeat()
    {
        _defeatPanel.gameObject.SetActive(true);

        _defeatPanel.Open();
        _mainPanel.Close();
    }
}
