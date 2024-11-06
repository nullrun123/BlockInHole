using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCarWOOD : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    private float moveSpeed;

    void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        Invoke("DestroyCar", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void DestroyCar()
    {
        Destroy(gameObject);
    }
}
