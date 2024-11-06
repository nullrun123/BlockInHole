using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGrid : MonoBehaviour
{
    public Transform teleportDestination; 

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoveToGrid"))
        {
           
            transform.position = teleportDestination.position;
        }
    }
}
