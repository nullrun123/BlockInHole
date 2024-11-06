using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
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
            playerController.OnMoveForward();

        }
    }
    //skill Up 1
    public void TwowalkUp1()
    {
        StartCoroutine(MoveUpWithDelay1());
    }

    private IEnumerator MoveUpWithDelay1()
    {
        playerController.OnMoveForward();
        yield return new WaitForSeconds(0.4f);
      
    }
    //skill Up 2
    public void TwowalkUp2()
    {
        StartCoroutine(MoveUpWithDelay2());
    }

    private IEnumerator MoveUpWithDelay2()
    {
        playerController.OnMoveForward();
        yield return new WaitForSeconds(0.4f);
        playerController.OnMoveForward();
    }
}
