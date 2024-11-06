using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnFall1 : MonoBehaviour
{
    public UnityEvent myevent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myevent.Invoke();
        }
    }
}
