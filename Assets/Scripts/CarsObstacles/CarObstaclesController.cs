using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarObstaclesController : MonoBehaviour
{
    private ObjectsCount objectsCount;
    private GameGuiController gameGuiController;
    private SpawnerController spawnerController;
    private ObstaclesControllerSO carValues;


    [SerializeField] private Transform paths;
    private List<Transform> pathsWay = new List<Transform>();

    private int pathsIndex;

    private void Awake()
    {
        spawnerController = FindObjectOfType<SpawnerController>();
        gameGuiController = FindObjectOfType<GameGuiController>();
        objectsCount = FindObjectOfType<ObjectsCount>();
    }

    // Start is called before the first frame update
    void Start()
    {
        carValues = spawnerController.GetCurrentCarPrefab();

        GetCarPaths();

    }

    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        if (!gameGuiController.GetIsOver())
        {
            if (pathsIndex < pathsWay.Count)
            {
                Vector3 target = pathsWay[pathsIndex].position;
                float speed = carValues.GetSpeed() * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, speed);

                Vector3 direction = (target - transform.position).normalized;

                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, carValues.GetSpeedRotation());
                }

                if (transform.position == target)
                {
                    pathsIndex++;
                }
            }
            else
            {
                pathsIndex = 0;
            }
        }
    }

    private void GetCarPaths()
    {
        transform.position = paths.GetChild(0).position;

        foreach (Transform child in paths)
        {
            pathsWay.Add(child);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                GameSoundController.instance.HitCarSound();
                float randoSalary = Random.Range(-20f, -30f);
                objectsCount.Score(randoSalary);
            }
        }
    }
}
