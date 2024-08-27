using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CallCoroutine", 2f);
    }

    private void CallCoroutine()
    {
        StartCoroutine(LoadingGame());
    }

    IEnumerator LoadingGame()
    {
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync("GamePlay");

        while(!asynLoad.isDone)
        {
            yield return null;
        }
    }
}
