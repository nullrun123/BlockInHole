using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingcarLeft : MonoBehaviour
{
    public float minSpeed, maxspeed;
    private Rigidbody rb;
    private Vector3 newVelocaity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newVelocaity = new Vector3(Random.Range(minSpeed, maxspeed), 0, 0);
        Invoke("DestoryCar", 10f);

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = newVelocaity;
    }
    void DestoryCar()
    {
        Destroy(gameObject);
    }
}
