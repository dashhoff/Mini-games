using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image _imageBar;

    private void Start()
    {
        StartCoroutine(LoadMenu());
    }

    private IEnumerator LoadMenu()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("Menu");

        while (!loading.isDone) 
        {
            float progress = Mathf.Clamp01(loading.progress / 0.9f);

            _imageBar.fillAmount = progress;

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
