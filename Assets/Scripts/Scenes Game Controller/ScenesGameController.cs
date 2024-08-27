using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesGameController : MonoBehaviour
{
    private bool isTrigged;
    [SerializeField] private GameObject[] translates;
    [SerializeField] private GameObject gameCommands;



    private void Start()
    {
        translates[0].gameObject.SetActive(true);
        translates[1].gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isTrigged)
        {
            gameCommands.SetActive(true);
        }
        else
        {
            gameCommands.SetActive(false);
        }
    }

    public void SceneDesteny(string _sceneName)
    {
        GameSoundController.instance.ButtonSound();

        SceneManager.LoadScene(_sceneName);
    }

    public void GetCommans()
    {
        GameSoundController.instance.ButtonSound();

        isTrigged = !isTrigged;
    }

    public void SelectLanguage(int _index)
    {
        GameSoundController.instance.ButtonSound();

        if (_index == 0)
        {
            translates[0].gameObject.SetActive(true);
            translates[1].gameObject.SetActive(false);
        }
        else if (_index == 1)
        {
            translates[0].gameObject.SetActive(false);
            translates[1].gameObject.SetActive(true);
        }
    }

    public void GameExit()
    {
        GameSoundController.instance.ButtonSound();

        StartCoroutine(ExitGame());
        
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(.2f);
        Application.Quit();
    }
}
