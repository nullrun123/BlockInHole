using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCar : MonoBehaviour
{
    public float minSpeed, maxspeed;
    private Rigidbody rb;
    private Vector3 newVelocaity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newVelocaity = new Vector3(0,0, Random.Range(minSpeed, maxspeed));
        Invoke("DestoryCar", 10f);

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = newVelocaity; 
    }

    void  DestoryCar()
    {
        Destroy(gameObject);
    }


}
