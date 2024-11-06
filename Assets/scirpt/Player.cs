using System.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1f; // ขนาดของกริด
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่

    private bool isMoving = false; // ตรวจสอบว่ากำลังเคลื่อนที่อยู่หรือไม่
    private Vector3 targetPosition; // ตำแหน่งที่จะเคลื่อนไป
    private Vector3 startPosition; // ตำแหน่งเริ่มต้น
    private Vector3 previousPosition; // ตำแหน่งก่อนชน
    public float bounceBackDistance = 0.1f; // ระยะที่ถอยกลับเมื่อชน

    private bool canPlayAnimation = true; // ตัวแปรเพื่อควบคุมว่าควรเล่นอนิเมชันหรือไม่
    private bool canMove = true;
    private void Start()
    {
        targetPosition = transform.position; // กำหนดตำแหน่งเริ่มต้น
        previousPosition = transform.position; // กำหนดตำแหน่งก่อนชน
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
        else
        {
            GetInput();
        }
    }

    void GetInput()
    {
        if (canMove)
        {


            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerState.count++;
                SetTargetPosition(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerState.count++;
                SetTargetPosition(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerState.count++;
                SetTargetPosition(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerState.count++;
                SetTargetPosition(Vector3.right);
            }
        }
    }

    void SetTargetPosition(Vector3 direction)
    {
        if (!isMoving)
        {
            startPosition = transform.position;
            targetPosition = startPosition + direction * gridSize;
            previousPosition = startPosition; // บันทึกตำแหน่งก่อนเคลื่อนที่
            isMoving = true;
        }
    }

    // เคลื่อนไปยังตำแหน่งที่ตั้งเป้าหมายไว้
    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    // ตรวจสอบการชน
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // ตรวจสอบชนกับแท็ก "Wall"
        {
            Debug.Log("ชนกับกำแพง!");
            BounceBackFromCollision(collision.contacts[0].normal); // ถอยกลับเล็กน้อยจากจุดชน
        }

        if (collision.gameObject.CompareTag("hello")) // ตรวจสอบชนกับแท็ก "hello"
        {
            Debug.Log("ชนกับวัตถุที่มีแท็ก 'hello'!");
            BounceBackFromCollision(collision.contacts[0].normal); // ถอยกลับเล็กน้อยจากจุดชน
        }
        // ตรวจสอบว่าชนกับวัตถุที่ต้องการหยุด
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(StopMovementForSeconds(1f)); // เริ่ม Coroutine เพื่อหยุดการควบคุมเป็นเวลา 5 วินาที
        }
    }

    // ฟังก์ชันหยุดตัวละครที่ตำแหน่งก่อนชนและถอยกลับเล็กน้อย
    void BounceBackFromCollision(Vector3 collisionNormal)
    {
        // ถอยกลับเล็กน้อยจากจุดชน
        Vector3 bounceBack = previousPosition - collisionNormal * bounceBackDistance;
        transform.position = bounceBack;
        isMoving = false; // หยุดการเคลื่อนที่
    }
    private IEnumerator StopMovementForSeconds(float seconds)
    {
        canMove = false; // หยุดการควบคุมผู้เล่น
        yield return new WaitForSeconds(seconds); // รอ 5 วินาที
        canMove = true; // เปิดการควบคุมกลับ
    }
} 

