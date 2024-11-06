using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Respawn2 : MonoBehaviour
{
   
    public float threshold;
    public float highhold;
    public Quaternion respawnRotation = Quaternion.Euler(0f, 0f, -19f);

     void Update()
    {
        if(transform.position.y < threshold || transform.position.y > highhold)
        {
            transform.position = new Vector3(96.69f, 1.07f, -33.82f);
           
            transform.rotation = respawnRotation;
            
        }
    }
   
}
