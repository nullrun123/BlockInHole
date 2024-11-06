using System.Collections;
using UnityEngine;

public class right : MonoBehaviour
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
            playerController.OnMoveRight();

        }
    }
    //skill right 1
    public void TwowalkRight1()
    {
        StartCoroutine(MoveRightWithDelay1());
    }

    private IEnumerator MoveRightWithDelay1()
    {
        playerController.OnMoveRight();
        yield return new WaitForSeconds(0.4f);
      
    }


    //skill right 2
    public void TwowalkRight2()
    {
        StartCoroutine(MoveRightWithDelay2());
    }

    private IEnumerator MoveRightWithDelay2()
    {
        playerController.OnMoveRight();
        yield return new WaitForSeconds(0.4f);
        playerController.OnMoveRight();
    }
}

