using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Respawn1 : MonoBehaviour
{

    public float threshold;
    public float highhold;
    public Quaternion respawnRotation = Quaternion.Euler(0f, 0f, -19f);

     void Update()
    {
        if(transform.position.y < threshold || transform.position.y > highhold)
        {
            transform.position = new Vector3(60f, 18f, -72.91f);
           
            transform.rotation = respawnRotation;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            transform.position = new Vector3(60f, 18f, -72.91f);
            transform.rotation = respawnRotation;
        }
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState.Lives -= 2;
        }
    }
}
