using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public GameObject ui;
    public Respawn re1;
    public Respawn1 re2;
    public Respawn2 re3;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
    }
   public void test1()
    {
        Time.timeScale = 0f;
    }
    public void test2()
    {
        Time.timeScale = 1f;
        re1.highhold += 0.001f;
        re2.highhold += 0.001f;
        re3.highhold += 0.001f;
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
