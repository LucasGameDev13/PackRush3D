using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private CompassController compassController;
    private GameGuiController gameGuiController;

    [Header("Game Objects Settings")]
    [SerializeField] private GameObjectsSO gameObjectsSO;
    private ObjectsCount objectsCount;
    private List<Transform> boxPos;
    private List<Transform> delivPos;

    [Header("Game Obstacles Settings")]
    [SerializeField] private List<ObstaclesControllerSO> obstaclesCarsPrefabs = new List<ObstaclesControllerSO>();
    private ObstaclesControllerSO currentCarPrefab;

    private bool isSpawned;

    public bool IsSpawned
    {
        get { return isSpawned; }
        set { isSpawned = value; }  
    }

    private void Awake()
    {
        objectsCount = FindObjectOfType<ObjectsCount>();
        compassController = FindObjectOfType<CompassController>();
        gameGuiController = FindObjectOfType<GameGuiController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        boxPos = gameObjectsSO.GetPacketsPositions();
        delivPos = gameObjectsSO.GetDeliveryPositions();

        SpawnerObstaclesController();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameGuiController.GetIsOver())
        {
            SpawnerObjectsController();
        }
    }

    

    #region Box And Delivery Objects Controller

    private void SpawnerObjectsController()
    {
        if (!objectsCount.GetIsPicked() && !isSpawned)
        {
            Invoke("SpawnerObjects", 3f);

            isSpawned = true;
        }
    }

    private void SpawnerObjects()
    {
        GameSoundController.instance.SpawnerSound();
        int newBoxPos = Random.Range(0, boxPos.Count);
        int newDelivPos = Random.Range(0, delivPos.Count);
        GameObject packet = Instantiate(gameObjectsSO.GetObjectsPrefab(0), boxPos[newBoxPos].position, Quaternion.identity, transform);
        GameObject Delivery = Instantiate(gameObjectsSO.GetObjectsPrefab(1), delivPos[newDelivPos].position, Quaternion.identity, transform);
        compassController.PacketPrefabPos = packet;
        compassController.DeliveryPrefabPos = Delivery;
    }

    #endregion


    #region Cars Obstacles Controller

    public ObstaclesControllerSO GetCurrentCarPrefab()
    {
        return currentCarPrefab;
    }

    private void SpawnerObstaclesController()
    {
        foreach (ObstaclesControllerSO objCarPref in obstaclesCarsPrefabs)
        {
            currentCarPrefab = objCarPref;

            Instantiate(currentCarPrefab.GetCarPrefab());
        }          
    }

    #endregion
}
