using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Vector3 nextDir;
    public float jumpforce = 100;
    Rigidbody rb;
    public float speed = 5;
    public float speedRotation = 5;
    public Vector3 curPosition;
    public float rotationOffset;

    private bool active = false;

    [SerializeField]
    public UnityEvent myEvents;


    [SerializeField]
    public ParticleSystem walkpartW;
    public ParticleSystem walkpartS;
    public ParticleSystem walkpartA;
    public ParticleSystem walkpartD;



    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curPosition = transform.position;

        // ลด drag เพื่อให้การล่วงเร็วขึ้น
        rb.drag = 0;
        rb.angularDrag = 0; // ป้องกันการหมุนช้า

    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0); // ล็อกการหมุน

        if (!active)
        {
            MovePlayer();
        }

        ApplyStrongGravity();
    }

    void MovePlayer()
    {

        Vector3 targetPosition = new Vector3(curPosition.x, transform.position.y, curPosition.z) + nextDir;
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // เคลื่อนที่ไปยังตำแหน่งเป้าหมาย
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // หมุนตัวละครให้หันไปทางที่ต้องการ
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Quaternion.Euler(0, rotationOffset, 0) * nextDir), speedRotation * Time.deltaTime);
        }
        else
        {
            nextDir = Vector3.zero;
            curPosition = transform.position;
            curPosition.x = Mathf.Round(curPosition.x);
            curPosition.y = Mathf.Round(curPosition.y);
            curPosition.z = Mathf.Round(curPosition.z);

            HandleInput(); // รอรับการเคลื่อนไหวครั้งต่อไป
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerState.count++;
            nextDir = new Vector3(0, 0, -1);
            walkpartD.Play();
            audioManager.PlaySFX(audioManager.walk);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerState.count++;
            nextDir = new Vector3(0, 0, 1);
            walkpartA.Play();
            audioManager.PlaySFX(audioManager.walk);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerState.count++;
            nextDir = new Vector3(-1, 0, 0);
            walkpartS.Play();
            audioManager.PlaySFX(audioManager.walk);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerState.count++;
            nextDir = new Vector3(1, 0, 0);
            walkpartW.Play();
            audioManager.PlaySFX(audioManager.walk);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {

            audioManager.PlaySFX(audioManager.enemyattack);

            Vector3 knockbackDirection = (transform.position - collision.transform.position).normalized;
            knockbackDirection.y = 0; // ป้องกันไม่ให้กระเด็นในทิศทางแนวตั้ง

            Vector3 knockbackPosition = curPosition + knockbackDirection;
            knockbackPosition.x = Mathf.Round(knockbackPosition.x);
            knockbackPosition.z = Mathf.Round(knockbackPosition.z);

            curPosition = knockbackPosition;
            nextDir = knockbackDirection;

            rb.AddForce(0, jumpforce, 0); // เพิ่มแรงกระโดดเล็กน้อย
        }

        if (collision.collider.CompareTag("Wall"))
        {
            audioManager.PlaySFX(audioManager.wallTouch);
            Vector3 knockbackDirection = (transform.position - collision.transform.position).normalized;
            knockbackDirection.y = 0;

            Vector3 knockbackPosition = curPosition + knockbackDirection;
            knockbackPosition.x = Mathf.Round(knockbackPosition.x);
            knockbackPosition.z = Mathf.Round(knockbackPosition.z);

            curPosition = knockbackPosition;
            nextDir = knockbackDirection;


        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("car"))
        {
            active = true;
            PlayerState.Lives -= 3;
            audioManager.PlaySFX(audioManager.carattack);
        }
    }

    void ApplyStrongGravity()
    {

        rb.AddForce(Vector3.down * 50f, ForceMode.Acceleration);
    }

    void Move()
    {
        rb.AddForce(0, jumpforce, 0); // เพิ่มแรงกระโดด
    }




    public void OnMoveRight()
    {
        PlayerState.count++;
        nextDir = new Vector3(0, 0, -1);
        walkpartD.Play();
        audioManager.PlaySFX(audioManager.walk);
    }
    public void OnMoveLeft()
    {
        PlayerState.count++;
        nextDir = new Vector3(0, 0, 1);
        walkpartA.Play();
        audioManager.PlaySFX(audioManager.walk);
    }
    public void OnMoveForward()
    {
        PlayerState.count++;
        nextDir = new Vector3(1, 0, 0);
        walkpartS.Play();
        audioManager.PlaySFX(audioManager.walk);
    }
    public void OnMoveBackward()
    {
        PlayerState.count++;
        nextDir = new Vector3(-1, 0, 0);
        walkpartW.Play();
        audioManager.PlaySFX(audioManager.walk);
    }
}
