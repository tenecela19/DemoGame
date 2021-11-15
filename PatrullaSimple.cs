using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaSimple : MonoBehaviour
{
    public float patrolspeed = 0f;
    public float changeTargetDistance = 0.1f;
    public Transform[] patrolPoints;

    int currentTarget = 0;



    void Update()
    {
        if (MoveToTarget())
        {
            currentTarget = GetNextTarget();
        }
    }

    private bool MoveToTarget()
    {
        Vector3 distanceVector = patrolPoints[currentTarget].position - transform.position;
        if (distanceVector.magnitude < changeTargetDistance)
        {
            return true;
        }

        Vector3 velocityVector = distanceVector.normalized;
        transform.position += velocityVector * patrolspeed * Time.deltaTime;

        return false;

    }

    private int GetNextTarget()
    {
        currentTarget++;
        if (currentTarget >= patrolPoints.Length)
        {
            currentTarget = 0;
        }

        return currentTarget;
    }
}
