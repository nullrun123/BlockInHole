using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    public float highhold;
    public Quaternion respawnRotation = Quaternion.Euler(0f, 0f, -19f);
    void Update()
    {
        if(transform.position.y < threshold || transform.position.y > highhold)
        {
            transform.position = new Vector3(-208.46f,3.9f,6.1f);    
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            transform.position = new Vector3(-208.46f, 3.9f, 6.1f);
            transform.rotation = respawnRotation;
        }

    }
}
