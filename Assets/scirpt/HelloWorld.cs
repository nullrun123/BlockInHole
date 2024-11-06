using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text helloText; 

    void Start()
    {
        StartCoroutine(ShowAndHideText()); 
    }

    IEnumerator ShowAndHideText()
    {
        helloText.text = "Hello World"; 
        Debug.Log("test");
        yield return new WaitForSeconds(10f); 
        helloText.text = "";
        Debug.Log("test");
        gameObject.SetActive(false); 
    }
}
