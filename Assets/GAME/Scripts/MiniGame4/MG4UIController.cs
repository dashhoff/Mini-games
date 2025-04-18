using UnityEngine;

public class MG4UIController : MonoBehaviour
{
    [SerializeField] private UI_Panel _mainPanel;
    [SerializeField] private UI_Panel _pausePanel;
    [SerializeField] private UI_Panel _victoryPanel;
    [SerializeField] private UI_Panel _defeatPanel;

    private void OnEnable()
    {
        MG4EventBus.OnPause += Pause;
        MG4EventBus.OnUnPause += UnPause;

        MG4EventBus.OnVictory += Victory;
        MG4EventBus.OnDefeat += Defeat;
    }

    private void OnDisable()
    {
        MG4EventBus.OnPause -= Pause;
        MG4EventBus.OnUnPause -= UnPause;

        MG4EventBus.OnVictory -= Victory;
        MG4EventBus.OnDefeat -= Defeat;
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
