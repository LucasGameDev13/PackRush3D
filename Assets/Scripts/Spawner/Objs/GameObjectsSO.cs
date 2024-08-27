using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Object", menuName = "New Object / Object")]
public class GameObjectsSO : ScriptableObject
{
    [Header("Game Objects")]
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private Transform packetPositions;
    [SerializeField] private Transform deliveryPositions;

    public GameObject GetObjectsPrefab(int index)
    {
        return gameObjects[index];
    }

    public List<Transform> GetPacketsPositions()
    {
        List<Transform> packetPosition = new List<Transform>();

        foreach(Transform packetPos in packetPositions)
        {
            packetPosition.Add(packetPos);
        }

        return packetPosition;
    }

    public List<Transform> GetDeliveryPositions()
    {
        List<Transform> deliveryPosition = new List<Transform>();

        foreach (Transform deliveryPos in deliveryPositions)
        {
            deliveryPosition.Add(deliveryPos);
        }

        return deliveryPosition;
    }

}
