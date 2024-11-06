using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    public Transform player;
    private PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ballcontrol"))
        {
            playerController.OnMoveBackward();

        }
    }
    //skill down 1
    public void TwowalkBack1()
    {
        StartCoroutine(MoveBackWithDelay1());
    }

    private IEnumerator MoveBackWithDelay1()
    {
        playerController.OnMoveBackward();
        yield return new WaitForSeconds(0.4f);

    }
    //skill down 2
    public void TwowalkBack2()
    {
        StartCoroutine(MoveBackWithDelay2());
    }

    private IEnumerator MoveBackWithDelay2()
    {
        playerController.OnMoveBackward(); 
        yield return new WaitForSeconds(0.4f);
        playerController.OnMoveBackward();
    }
}
