using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = WayPoints.points[wavepointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(dir.magnitude < 0.2f)
        {
            if (wavepointIndex >= WayPoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            wavepointIndex++;
            target = WayPoints.points[wavepointIndex];

        }

    }
}
