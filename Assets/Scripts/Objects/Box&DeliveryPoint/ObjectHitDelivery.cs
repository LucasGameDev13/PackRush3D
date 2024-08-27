using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitDelivery : ObjectHit
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMoviment();
    }

    public override void OnMoviment()
    {
        base.OnMoviment();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
