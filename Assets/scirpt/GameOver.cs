using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI RoundsText;

   
    void Update()
    {
        RoundsText.text = PlayerState.count.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}