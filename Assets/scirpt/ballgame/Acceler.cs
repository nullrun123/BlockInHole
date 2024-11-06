using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceler : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    public float speed = 10f;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tile = Input.acceleration;

        if (isFlat)
            tile = Quaternion.Euler(90, 0, 0) * tile;


        rigid.AddForce(tile * speed);
        //Debug.DrawRay(transform.position + Vector3.up, tile, Color.cyan);
    }
}