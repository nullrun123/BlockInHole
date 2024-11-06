using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoor : MonoBehaviour
{
    public UnityEvent walkopen;
    [SerializeField] private Animator Door = null;
    [SerializeField] private Animator Door1 = null;
    [SerializeField] private bool openDoor = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Door.Play("leveropen", 0, 0.0f);
            walkopen.Invoke();
            Invoke("unlockdoor",2f);
            
            gameObject.SetActive(false);
        }
           }

   
    
    void unlockdoor()
    {
        Door1.Play("Dooropen01", 0, 0.0f);
    }
}


