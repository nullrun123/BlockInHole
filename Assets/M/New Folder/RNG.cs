using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomImageObjectDisplay : MonoBehaviour
{
    public Image[] imageObjects;                
      
    private int[] stackCounts;                 
    public float interval = 10f;              
    private Image ActiveImage = null;
    public Transform ball;
    public float stopcount = 7f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void Start()
    {
        stackCounts = new int[imageObjects.Length]; // กำหนดขนาด array stackCounts ให้เท่ากับจำนวน Image
        StartCoroutine(DisplayRandomImageObject());
    }

    IEnumerator DisplayRandomImageObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

       
            
            int randomIndex = Random.Range(0, imageObjects.Length);
            ActiveImage = imageObjects[randomIndex];
            ActiveImage.gameObject.SetActive(true); 

           
        }
    }
    public void stopball01()
    {
        StartCoroutine(stopball());
    }
    IEnumerator stopball()
    {
        ball.gameObject.SetActive(false);
        audioManager.PlaySFX(audioManager.ballActive);
        yield return new WaitForSeconds(stopcount);
        audioManager.PlaySFX(audioManager.ballActive);
        ball.gameObject.SetActive(true);
    }
}
