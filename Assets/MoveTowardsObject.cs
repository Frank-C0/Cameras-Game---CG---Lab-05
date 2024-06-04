using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour
{
    public Transform target;
    public float speed = 30f; 
    [SerializeField] public bool follow = true;

    void Update()
    {
        if (target == null || !follow) return;

        Vector3 direction = target.position - transform.position;

        float distanceToTarget = direction.magnitude;

        if (distanceToTarget > 0.01f)
        {
            float step = speed * Time.deltaTime;
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, step / distanceToTarget);
            transform.position = newPosition;
        }
    }
}