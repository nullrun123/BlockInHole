using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject player1;
    public GameObject carmra1;
    public GameObject player2;
    public GameObject carmra2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player1.SetActive(false);
            carmra1.SetActive(false);
            player2.SetActive(true);
            carmra2.SetActive(true);
        }
    }
}
