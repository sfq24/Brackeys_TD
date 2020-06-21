using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity setup fields")]
    public float rotationSpeed = 10f;
    public Transform RotationPoint;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(RotationPoint.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        RotationPoint.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if(fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    public void Shoot()
    {
        //直接用Instantiate会以firePoint作为parent创建obj
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, range);
        
    }

    void UpdateTarget()
    {
        float neareastDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        GameObject[] enermies = GameObject.FindGameObjectsWithTag("Enemy");
        float enemyDistance = Mathf.Infinity;
        foreach(GameObject enemy in enermies)
        {
            enemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if ( enemyDistance < neareastDistance)
            {
                neareastDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && neareastDistance < range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
