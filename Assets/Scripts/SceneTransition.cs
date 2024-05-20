using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private CanvasGroup grp;

    private void Start()
    {
        grp = GetComponent<CanvasGroup>();
    }

    public void LoadScene(int buildIndex)
    {
        LeanTween.alphaCanvas(grp, 1, 0.5f).setOnComplete(() =>
        {
            StartCoroutine(StartLoading(buildIndex));
        });
    }

    private IEnumerator StartLoading(int buildIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}