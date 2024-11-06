using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float speed = 3f;
    public float knockbackForce = 300f;
    public float knockbackVerticalForce = 150f;
    private bool attack = true;
    public GameObject gameOverUI;

    private bool playerIsDead = false;
    public MonoBehaviour PlayerController;
    public UnityEvent myEvents;
    public UnityEvent myEvents1;
    private Rigidbody playerRb;


    private float timer = 2f; 
    public float delay = 1.5f; 


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    [SerializeField]
    public float gridSize = 1f;
 
    private bool isKnockedBack = false;
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>(); // เรียก Rigidbody ของ Player\

       
    }

    void Update()
    {
        if (!playerIsDead)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < detectionRadius)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(player);

                //Dog bark
                timer += Time.deltaTime;

                if (timer >= delay)
                {
                    myEvents1.Invoke();
                    dogbark();
                    timer = 0f;
                }

            }


        }
    }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Barrier"))
            {
                StartCoroutine(StopMovement(10f));
            }
        }

        private void OnCollisionEnter(Collision collision)
    {
        
        if (attack)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerState.Lives -= 1;
               
                StartCoroutine(SpeedDelayEnemy());
                

                if (PlayerState.Lives <= 0 && !playerIsDead)
                {
                    playerIsDead = true;
                    audioManager.PlaySFX(audioManager.death);
                    myEvents.Invoke();

                    Invoke("ShowGameOverUI", 2f);
                    Invoke("playerDestroy", 2.2f);
                    Invoke("_stop", 2f);
                    Invoke("playerDestroy", 2.2f);
                    PlayerController.enabled = false;
                }
            }
        }
    }

    
    private IEnumerator MovePlayerToGrid(Vector3 targetPosition)
    {
        float moveTime = 0.2f; 
        float elapsedTime = 0f;

        Vector3 startPosition = player.position;

        while (elapsedTime < moveTime)
        {
            player.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.position = targetPosition;
    }

    IEnumerator StopMovementForSeconds(float seconds)
    {
        attack = false; 
        yield return new WaitForSeconds(seconds); 
        attack = true; 
    }

IEnumerator SpeedDelayEnemy()
    {
        speed -= 3;
        Debug.Log("22");
        yield return new WaitForSeconds(4f);
        speed += 3;
        Debug.Log("stop");
    }
    void playerDestroy()
    {
        player.gameObject.SetActive(false);
    }

    void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void _stopme()
    {
        Time.timeScale = 0f;
    }

    void dogbark()
    {
        audioManager.PlaySFX(audioManager.mons);
    }
   
    IEnumerator StopMovement(float duration)
    {
        float originalSpeed = speed;
        speed = 0f; 
        yield return new WaitForSeconds(duration); 
        speed = originalSpeed; 
    }

  
}
