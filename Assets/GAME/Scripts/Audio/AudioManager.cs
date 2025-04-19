using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;

    [SerializeField] private AudioSource _correctSound;
    [SerializeField] private AudioSource _wrongSound;

    [SerializeField] private AudioSource _victorySound;
    [SerializeField] private AudioSource _defeatSound;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        EventBus.OnCorrect += PlayCorrectSound;
        EventBus.OnWrong += PlayWrongSound;

        EventBus.OnVictory += PlayVictorySound;
        EventBus.OnDefeat += PlayDefeatSound;
    }

    private void OnDisable()
    {
        EventBus.OnCorrect -= PlayCorrectSound;
        EventBus.OnWrong -= PlayWrongSound;

        EventBus.OnVictory -= PlayVictorySound;
        EventBus.OnDefeat -= PlayDefeatSound;
    }

    public void PlayClickSound()
    {
        _clickSound.Play();
    }

    public void PlayCorrectSound()
    {
        _correctSound.Play();
    }

    public void PlayWrongSound()
    {
        _wrongSound.Play();
    }

    public void PlayVictorySound()
    {
        _clickSound.Play();
    }

    public void PlayDefeatSound()
    {
        _clickSound.Play();
    }
}
