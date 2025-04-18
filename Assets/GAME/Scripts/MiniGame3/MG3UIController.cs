using UnityEngine;

public class MG3UIController : MonoBehaviour
{
    [SerializeField] private UI_Panel _mainPanel;
    [SerializeField] private UI_Panel _pausePanel;
    [SerializeField] private UI_Panel _victoryPanel;
    [SerializeField] private UI_Panel _defeatPanel;

    private void OnEnable()
    {
        MG3EventBus.OnPause += Pause;
        MG3EventBus.OnUnPause += UnPause;

        MG3EventBus.OnVictory += Victory;
        MG3EventBus.OnDefeat += Defeat;
    }

    private void OnDisable()
    {
        MG3EventBus.OnPause -= Pause;
        MG3EventBus.OnUnPause -= UnPause;

        MG3EventBus.OnVictory -= Victory;
        MG3EventBus.OnDefeat -= Defeat;
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
