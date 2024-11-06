using UnityEngine;
using System.Collections;

public class ToggleOtherObject : MonoBehaviour
{
    public GameObject targetObject; // อ้างอิงไปยัง GameObject ที่ต้องการเปิด/ปิด
    public float open = 5f;
    public float close = 2f;
     void Start()
    {
       
        
        if (targetObject != null) // ตรวจสอบว่า targetObject ถูกตั้งค่า
        {
            StartCoroutine(ToggleCoroutine());
        }
       
    }

    private IEnumerator ToggleCoroutine()
    {
        while (true) // วนลูปตลอดไป
        {
            targetObject.SetActive(false);
            yield return new WaitForSeconds(close); // รอ 4 วินาที

            targetObject.SetActive(true); // เปิด GameObject
            yield return new WaitForSeconds(open); // รอ 5 วินาที

            targetObject.SetActive(false); // ปิด GameObject
            yield return new WaitForSeconds(close); // รอ 4 วินาที

            targetObject.SetActive(true); // เปิด GameObject
            yield return new WaitForSeconds(open); // รอ 5 วินาที
        }
    }
}
