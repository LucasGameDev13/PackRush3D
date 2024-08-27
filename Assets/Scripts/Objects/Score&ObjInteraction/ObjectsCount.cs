using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCount : MonoBehaviour
{
    private GameGuiController gameGuiController;
    private CompassController compassController;
    private SpawnerController spawnerController;
    private int packetsCount;
    private bool isPicked;
    [SerializeField] private float scoreSalary;
    private float finalSalary;
    [SerializeField] private float timeToDelivery;
    private float timerValue;

    private void Awake()
    {
        spawnerController = FindObjectOfType<SpawnerController>();
        compassController = FindObjectOfType<CompassController>();
        gameGuiController = FindObjectOfType<GameGuiController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        finalSalary = scoreSalary;
        timerValue = timeToDelivery;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameGuiController.GetIsOver())
        {
            finalSalary = scoreSalary;
        }
    }

    public bool GetIsPicked()
    {
        return isPicked;
    }

    public void Score(float Score)
    {
        scoreSalary += Score;
    }

    public float GetTimer()
    {
        return timeToDelivery/timerValue;
    }

    public float GetSalary()
    {
        return scoreSalary;
    }

    public float GetFinalSalary()
    {
        return finalSalary;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!gameGuiController.GetIsOver())
        {
            if (other != null)
            {
                if (other.gameObject.CompareTag("Packet") && !isPicked)
                {
                    GameSoundController.instance.PickUpBoxSound();
                    packetsCount++;
                    timeToDelivery = timerValue;
                    StartCoroutine("TimerCounting");
                    Destroy(other.gameObject);
                    isPicked = true;
                    compassController.IsTarget = true;
                }

                if (other.gameObject.CompareTag("Delivery") && isPicked)
                {
                    GameSoundController.instance.DeliveryBoxSound();
                    packetsCount--;
                    timeToDelivery = timerValue;
                    float randoSalary = Random.Range(50f, 100f);
                    Score(randoSalary);
                    StopCoroutine("TimerCounting");
                    Destroy(other.gameObject);
                    isPicked = false;
                    spawnerController.IsSpawned = false;
                    compassController.IsTarget = false;
                    Debug.Log("Entraga realizada");
                }
            }
        }
    }

    IEnumerator TimerCounting()
    {
        if (!gameGuiController.GetIsOver())
        {
            while (timeToDelivery > 0)
            {
                timeToDelivery -= Time.deltaTime;
                yield return null;
            }

            GameSoundController.instance.NotDeliveryBoxSound();
            packetsCount--;
            float randoSalary = Random.Range(-10f, -20f);
            Score(randoSalary);
            timeToDelivery = timerValue;
            ObjectHitDelivery deliveryPoint = FindObjectOfType<ObjectHitDelivery>();
            deliveryPoint.DestroyMe();
            isPicked = false;
            spawnerController.IsSpawned = false;
            compassController.IsTarget = false;
            Debug.Log("Entraga não realizada");
        }
    }
}
