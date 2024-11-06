using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WIngame : MonoBehaviour
{
    public Transform player;

    AudioManager audioManager;

    public GameObject gameWinUI;
    public MonoBehaviour PlayerController;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            
            Invoke("ShowWINUI", 2f);
            audioManager.PlaySFX(audioManager.mons);
            Invoke("playerDestroy", 2.2f);
            Invoke("_stop", 2f);
            Invoke("playerDestroy", 2.2f);
            PlayerController.enabled = false;
        }
    }

   

    void playerDestroy()
    {
        player.gameObject.SetActive(false);
    }

    void ShowWINUI()
    {
        gameWinUI.SetActive(true);
    }

    public void _stopme()
    {
        Time.timeScale = 0f;
    }
}

