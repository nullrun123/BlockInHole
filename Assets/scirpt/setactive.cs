using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class setactive : MonoBehaviour
{
    public UnityEvent leftopen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          leftopen.Invoke();    
        }

    }
}
