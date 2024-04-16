using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] Transform firingPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] static float fireRate = 0.2f;
    float lastTimeShot = 0;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (lastTimeShot + fireRate <= Time.time)
            {
                lastTimeShot = Time.time;
                Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            }
        }
    }
}
