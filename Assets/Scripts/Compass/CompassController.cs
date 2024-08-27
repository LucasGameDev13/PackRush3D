using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    private GameGuiController gameGuiController;
    private ObjectsCount objectsCount;
    private GameObject packetPrefabPos;
    private GameObject deliveryPrefabPos;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Material[] material;
    [SerializeField] private MeshRenderer[] meshRenderer;
    private bool isTarget;


    public GameObject PacketPrefabPos
    {
        get { return packetPrefabPos; }
        set { packetPrefabPos = value; }
    }

    public GameObject DeliveryPrefabPos
    {
        get { return deliveryPrefabPos; }
        set { deliveryPrefabPos = value; }
    }

    public bool IsTarget
    {
        get { return isTarget; }
        set { isTarget = value; }
    }

    private void Awake()
    {
        objectsCount = FindObjectOfType<ObjectsCount>();
        gameGuiController = FindObjectOfType<GameGuiController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < meshRenderer.Length; i++)
        {
            meshRenderer[i].material = material[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameGuiController.GetIsOver())
        {
            if (packetPrefabPos != null)
            {
                if (!objectsCount.GetIsPicked() && !isTarget)
                {
                    GetObstaclesPositions(packetPrefabPos);

                    for (int i = 0; i < meshRenderer.Length; i++)
                    {
                        meshRenderer[i].material = material[i];
                    }
                }
            }

            if (deliveryPrefabPos != null)
            {
                if (objectsCount.GetIsPicked() && isTarget)
                {
                    GetObstaclesPositions(deliveryPrefabPos);

                    for (int i = 0; i < meshRenderer.Length; i++)
                    {
                        meshRenderer[i].material = material[i + 2];
                    }
                }
            }
        }
    }

    private void GetObstaclesPositions(GameObject objectPosition)
    {
        Vector3 target = objectPosition.transform.position;
        Vector3 direction = (target - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
