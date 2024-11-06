using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class laserConillder : MonoBehaviour
{
    public float timecount = 3.0f;
   
    private Coroutine damageCoroutine;
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            audioManager.PlaySFX(audioManager.enemyattack);
            PlayerState.Lives -= 1;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    
}
