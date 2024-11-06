using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 15f;

    private Rigidbody rb;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioManager.PlaySFX(audioManager.bulletgun);
        Impulse();
        Invoke("Destroybullet", 4f);
    }

    void Destroybullet()
    {
        Destroy(gameObject);
    }
    private void Impulse()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerState.Lives -= 1;
            audioManager.PlaySFX(audioManager.enemyattack);
        }

    }
}
