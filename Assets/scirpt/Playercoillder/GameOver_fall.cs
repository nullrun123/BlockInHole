using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOver_fall : MonoBehaviour
{
    public Transform player;


    AudioManager audioManager;
    public GameObject gameOverUI;

    private bool playerIsDead = false;
    public MonoBehaviour PlayerController;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Player"))
            {
                PlayerState.Lives -= 5;

                if (PlayerState.Lives <= 0 && !playerIsDead)
                {
                    playerIsDead = true;

                audioManager.PlaySFX(audioManager.fallwater);
                Invoke("ShowGameOverUI", 2f);
                    Invoke("playerDestroy", 2.2f);
                    Invoke("_stop", 2f);
                    Invoke("playerDestroy", 2.2f);
                    PlayerController.enabled = false;
                }
            }
        }
  
    void playerDestroy()
    {
        player.gameObject.SetActive(false);
    }

    void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void _stopme()
    {
        Time.timeScale = 0f;
    }
}

