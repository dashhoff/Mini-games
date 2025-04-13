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
        loading.allowSceneActivation = false;

        while (loading.progress < 0.9f) 
        {
            float progress = Mathf.Clamp01(loading.progress);

            _imageBar.fillAmount = progress;
        }

        _imageBar.fillAmount = 1;

        yield return new WaitForSecondsRealtime(2.5f);

        loading.allowSceneActivation = true;

    }
}
