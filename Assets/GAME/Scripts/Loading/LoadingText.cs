using System.Collections;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    [SerializeField] private TMP_Text _loadingText;

    private void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }

    private IEnumerator LoadingCoroutine()
    {
        int index = 0;

        while (true)
        {
           yield return new WaitForSecondsRealtime(0.2f);

            switch (index)
            {
                case (0):
                    _loadingText.text = "«¿√–”« ¿";
                    break;

                case (1):
                    _loadingText.text = "«¿√–”« ¿.";
                    break;

                case (2):
                    _loadingText.text = "«¿√–”« ¿..";
                    break;

                case (3):
                    _loadingText.text = "«¿√–”« ¿...";
                    break;
            }
            index++;

            if (index == 4)
                index = 0;
        }
    }
}
