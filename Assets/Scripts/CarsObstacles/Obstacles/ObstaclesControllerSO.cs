using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "New Obstacle / Obstacle")]
public class ObstaclesControllerSO : ScriptableObject
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;


    public GameObject GetCarPrefab()
    {
        return carPrefab;
    }

    public float GetSpeedRotation()
    {
        return speedRotation * Time.deltaTime;
    }


    public float GetSpeed()
    {
        return speed;
    }

}
