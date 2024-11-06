using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 1f;

    [SerializeField] Transform gunPoint;    


    private void Start()
    {
        if (gunPoint == null)
            gunPoint = GetComponentInChildren<GunPoint>().transform;
    }
    public float GetRateOfFire()
    {
        return rateOfFire;
    }

    public void Fire()
    {
        Instantiate(projectile, gunPoint.position, transform.rotation);
  
    }
}