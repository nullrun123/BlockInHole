using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLocked : MonoBehaviour
{
    [SerializeField] private Animator locked = null;

    [SerializeField]  private bool openlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            locked.Play("loackedtext", 0, 0.0f);
            gameObject.SetActive(false);
        }
    }
}
