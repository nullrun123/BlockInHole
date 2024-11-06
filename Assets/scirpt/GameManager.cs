using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameoverUi;
    public GameObject player;
    //public GameObject completeLevelUI;
    //public GameObject SoundGameOver;
    //public GameObject SoundWin;
    public UnityEvent myEvents;
    void Start()
    {
       
        GameIsOver = false;

        Time.timeScale = 1f;
    }
    void Update()
    {
        

        if (GameIsOver)
        {

            Endgame();
        }


     
        if (PlayerState.Lives <= 0)
        {
            Endgame();
        }
    }
    void Endgame()
    {
        if (PlayerState.Lives <= 0)
        {
            GameIsOver = true;
            Debug.Log("Game over!");
            //SoundGameOver.SetActive(true);
            myEvents.Invoke();
            Invoke("ShowGameOverUI", 2f);
            Invoke("playerDestroy", 2f);
           
            Invoke("_stopme", 2f);
  
         
        }


    }
    void playerDestroy()
    {
        player.gameObject.SetActive(false);
    }

    void ShowGameOverUI()
    {
        gameoverUi.SetActive(true);
    }

    public void _stopme()
    {
        Time.timeScale = 0f;
    }
    public void Menu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Winlevel()
    {

        GameIsOver = true;
        //completeLevelUI.SetActive(true);
    }
   
}
