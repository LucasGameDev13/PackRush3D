using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameGuiController : MonoBehaviour
{
    private ObjectsCount objectsCount;
    [SerializeField] private float timer;
    private float timerController;
    [SerializeField] private TextMeshProUGUI gameTimerText;
    [SerializeField] private TextMeshProUGUI gameSalaryText;
    [SerializeField] private TextMeshProUGUI gameFinalSalaryText;
    [SerializeField] private Color[] salaryColors;
    [SerializeField] private Image deliveryTimeImage;
    [SerializeField] private GameObject gameGuiInfos;
    [SerializeField] private GameObject gameOverTimeUp;
    [SerializeField] private GameObject[] gameOverScoresText;   
    private bool isOver;
    private bool isPlaying;
    

    private void Awake()
    {
        objectsCount = FindObjectOfType<ObjectsCount>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isOver = false;
        timerController = timer;
        deliveryTimeImage.fillAmount = 1;
        GameElementsGui();
        gameGuiInfos.SetActive(true);
        gameOverTimeUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetGameTimer();
        GameElementsGui();

        if (!isOver)
        {
            deliveryTimeImage.fillAmount = objectsCount.GetTimer();
        }
    }

    public bool GetIsOver()
    {
        return isOver;
    }

    private void SetGameTimer()
    {
        if (timerController > 0)
        {
            timerController -= Time.deltaTime;      
        }
        else
        {
            timerController = 0;
            isOver = true;
            gameOverTimeUp.SetActive(true);
            gameGuiInfos.SetActive(false);

            if(gameOverTimeUp != null)
            {
                if (objectsCount.GetSalary() >= 0)
                {
                    gameOverScoresText[0].gameObject.SetActive(true);
                    gameOverScoresText[1].gameObject.SetActive(false);

                    if (!isPlaying)
                    {
                        
                        GameSoundController.instance.EndOfGameScorePositive();
                        Invoke("GetApplauses", 1f);
                        isPlaying = true;
                    }
                }
                else
                {
                    gameOverScoresText[0].gameObject.SetActive(false);
                    gameOverScoresText[1].gameObject.SetActive(true);

                    if (!isPlaying)
                    {
                        
                        GameSoundController.instance.EndOfGameScoreNegative();
                        Invoke("GetBools", 1f);
                        isPlaying = true;
                    }
                }
            }
        }
    }

    private void GameElementsGui()
    {
        int minutes = Mathf.FloorToInt(timerController / 60);
        int seconds = Mathf.FloorToInt(timerController % 60);
        gameTimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(objectsCount.GetSalary() >= 0)
        {
            gameSalaryText.color = salaryColors[0];
            gameFinalSalaryText.color = salaryColors[0];
        }
        else
        {
            gameSalaryText.color = salaryColors[1];
            gameFinalSalaryText.color = salaryColors[1];
        }

        gameSalaryText.text = objectsCount.GetSalary().ToString("F2");
        gameFinalSalaryText.text = "$ " + objectsCount.GetFinalSalary().ToString("F2");
    }

    private void GetApplauses()
    {
        GameSoundController.instance.ApplausesSound();
    }

    private void GetBools()
    {
        GameSoundController.instance.BoosSounds();
    }
}
