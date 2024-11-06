using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
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
            playerController.OnMoveLeft();

        }
    }

    //skill left 1
    public void Twowalkleft1()
    {
        StartCoroutine(MoveLeftWithDelay1());
    }

    private IEnumerator MoveLeftWithDelay1()
    {
        playerController.OnMoveLeft();
        yield return new WaitForSeconds(0.4f);
        
    }
    //skill left 2
    public void Twowalkleft2()
    {
        StartCoroutine(MoveLeftWithDelay2());
    }

    private IEnumerator MoveLeftWithDelay2()
    {
        playerController.OnMoveLeft();
        yield return new WaitForSeconds(0.4f);
        playerController.OnMoveLeft();
    }
}
