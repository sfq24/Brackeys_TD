﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject BulletEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        // 保险起见所有transform需要world space的时候都要明确化
        transform.Translate(dir.normalized * distancePerFrame, Space.World);


    }

    void HitTarget()
    {
        GameObject bulletEffect = Instantiate(BulletEffect, transform.position, transform.rotation);
        Destroy(bulletEffect, 2f);
        Destroy(gameObject);
    }

}
