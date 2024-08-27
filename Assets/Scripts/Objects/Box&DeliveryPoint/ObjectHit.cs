using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnMoviment();

    }

    public virtual void OnMoviment()
    {
        float counting = speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, counting, 0));
    }
}
