using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider Scale;

    public void Loading()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("game");
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            Scale.value = loadAsync.progress;

            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
